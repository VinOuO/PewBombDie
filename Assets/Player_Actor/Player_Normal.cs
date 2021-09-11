using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player_Normal : NetworkBehaviour {
    public string Player_Skin = "Player_C2";
    public int Bush_Num = 0;
    Rigidbody2D Rgdbody;
    SpriteRenderer SptRander;
    Vector2 Transform2D;
    float Move_Speed = 5;
    GameObject Health_Bar;
    public float Health = 100;
    public bool Started = false;
    [SyncVar(hook = "Check_Health")] public float health;
    public int Bullet_Amount = 99;
    bool Is_Filling_Bullet = false;
    GameObject Gaming_UI;

    void Start () {
        SptRander = GetComponent<SpriteRenderer>();
        Rgdbody = GetComponent<Rigidbody2D>();
        Gaming_UI = GameObject.Find("Gaming_UserInterface");
        Transform2D.Set(transform.position.x, transform.position.y);
        Health_Bar = transform.GetChild(1).gameObject;
        health = Health;
    }
	
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }
        if (Started)
        {
            Player_Input();
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Fire();
            }
        }
    }

    void Player_Input()
    {
        Vector2 _temp;
        _temp = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            _temp += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _temp += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _temp += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _temp += Vector2.down;
        }
        Rgdbody.MovePosition(Transform2D + _temp.normalized * Time.deltaTime * Move_Speed);
        if (_temp != Vector2.zero)
        {
            if (_temp.x > 0)
            {
                Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up)*-1);
            }
            else
            {
                Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up));
            }
        }
        

        Transform2D.Set(transform.position.x, transform.position.y);
    }

    void Check_Health(float _health)
    {
        Health_Bar.GetComponent<Health_Bar_Normal>().Change_Amount(_health / Health);
    }


    [Command]
    void CmdFire()
    {
        NetworkServer.Spawn(transform.GetChild(0).GetComponent<Gun_Normal>().Shoot());
    }
    void Fire()
    {
        if (Bullet_Amount > 0)
        {
            Bullet_Amount--;
            CmdFire();
            Gaming_UI.transform.GetChild(0).transform.GetChild(1).GetComponent<Bullet_Amount_Normal>().Set_Bullet_Num(Bullet_Amount);
        }
        if (!Is_Filling_Bullet)
        {
            StartCoroutine(Fill_Bullet_Amount());
        }
    }


    [Command]
    void CmdSetCharacter(string _Name,string _Color)
    {
        foreach(PlayerController i in NetworkManager.singleton.client.connection.playerControllers)
        {
            if(i.gameObject == this.gameObject)
            {

            }
        }
    }

    IEnumerator Fill_Bullet_Amount()
    {
        Is_Filling_Bullet = true;
        while (Bullet_Amount < 99)
        {
            Bullet_Amount++;
            Gaming_UI.transform.GetChild(0).transform.GetChild(1).GetComponent<Bullet_Amount_Normal>().Set_Bullet_Num(Bullet_Amount);
            yield return new WaitForSeconds(0.5f);
        }
        Is_Filling_Bullet = false;
        StopCoroutine(Fill_Bullet_Amount());
    }

    public void Change_Invisible_State(int _Type)
    {
        Color _temp;
        switch (_Type)
        {
            case 1:
                _temp = SptRander.color;
                _temp.a = 1f;
                SptRander.color = _temp;

                _temp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                _temp.a = 1f;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = _temp;

                _temp = transform.GetChild(1).GetChild(0).GetComponent<Image>().color;
                _temp.a = 1f;
                transform.GetChild(1).GetChild(0).GetComponent<Image>().color = _temp;

                _temp = transform.GetChild(1).GetChild(1).GetComponent<Image>().color;
                _temp.a = 1f;
                transform.GetChild(1).GetChild(1).GetComponent<Image>().color = _temp;

                _temp = transform.GetChild(2).GetChild(0).GetComponent<Text>().color;
                _temp.a = 1f;
                transform.GetChild(2).GetChild(0).GetComponent<Text>().color = _temp;
                break;
            case 2:
                _temp = SptRander.color;
                _temp.a = 0.5f;
                SptRander.color = _temp;

                _temp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                _temp.a = 0.5f;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = _temp;

                _temp = transform.GetChild(1).GetChild(0).GetComponent<Image>().color;
                _temp.a = 0.5f;
                transform.GetChild(1).GetChild(0).GetComponent<Image>().color = _temp;

                _temp = transform.GetChild(1).GetChild(1).GetComponent<Image>().color;
                _temp.a = 0.5f;
                transform.GetChild(1).GetChild(1).GetComponent<Image>().color = _temp;

                _temp = transform.GetChild(2).GetChild(0).GetComponent<Text>().color;
                _temp.a = 0.5f;
                transform.GetChild(2).GetChild(0).GetComponent<Text>().color = _temp;
                break;
            case 3:
                _temp = SptRander.color;
                _temp.a = 0f;
                SptRander.color = _temp;

                _temp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                _temp.a = 0f;
                transform.GetChild(0).GetComponent<SpriteRenderer>().color = _temp;

                _temp = transform.GetChild(1).GetChild(0).GetComponent<Image>().color;
                _temp.a = 0f;
                transform.GetChild(1).GetChild(0).GetComponent<Image>().color = _temp;

                _temp = transform.GetChild(1).GetChild(1).GetComponent<Image>().color;
                _temp.a = 0f;
                transform.GetChild(1).GetChild(1).GetComponent<Image>().color = _temp;

                _temp = transform.GetChild(2).GetChild(0).GetComponent<Text>().color;
                _temp.a = 0f;
                transform.GetChild(2).GetChild(0).GetComponent<Text>().color = _temp;
                break;
        }
    }

    [ClientRpc]
    public void RpcStartGame()
    {
        this.GetComponent<Player_Normal>().Started = true;
    }

}
