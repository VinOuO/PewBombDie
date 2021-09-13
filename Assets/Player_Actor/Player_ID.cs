using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player_ID : NetworkBehaviour {

    [SyncVar] public string PlayerUniqueIdentity;
    [SyncVar(hook = "Change_Player_Name")] public string Player_Name;
    [SyncVar(hook = "Change_Player_Color")] public string Player_Color;

    private NetworkInstanceId PlayerNetID;
    private Transform myTransform;

    float Start_Time = 0;
    bool P = false;
    public override void OnStartLocalPlayer()
    {
        CmdRegisterIdentity(this.gameObject);
        GetNetIdentity();
        SetIdentity();
    }

    private void Awake()
    {
        myTransform = transform;
    }

    void Start () {
		
	}
	

	void Update () {
		if (myTransform.name=="" || myTransform.name== "Player_Actor(Clone)")
        {
            SetIdentity();
        }

        if (Time.time - Start_Time >= 15 && !P && isLocalPlayer)
        {
            //CmdTellSeverMyNameandColor();
            //P = true;
        }
	}

    [Client]
    void GetNetIdentity()
    {
        PlayerNetID = GetComponent<NetworkIdentity>().netId;
        CmdTellSeverMyID(MakeUniqueIdentity());
    }

    void SetIdentity()
    {
        if (!isLocalPlayer)
        {
            myTransform.name = PlayerUniqueIdentity;
        }
        else
        {
            myTransform.name = PlayerUniqueIdentity;
            //myTransform.name = MakeUniqueIdentity();
        }
        //transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = transform.name;
    }
    void Change_Player_Name(string _Player_Name)
    {
        transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = _Player_Name;
    }

    void Change_Player_Color(string _Player_Color)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/" + _Player_Color);
    }

    string MakeUniqueIdentity()
    {
        string _Name = "Player_" + PlayerNetID.ToString();
        return _Name;
    }

    [Command]
    void CmdTellSeverMyID(string _Name)
    {
        PlayerUniqueIdentity = _Name;
    }


    [Command]
    public void CmdSetMyNameandColor(string _Name,string _Color)
    {
        Player_Name = _Name;
        Player_Color = _Color;
        GameObject.Find("GM").GetComponent<GameManager_Normal>().Ready_Player_Num++;
    }

    [Command]
    public void CmdRegisterIdentity(GameObject _Player)
    {
        GameObject _GM = GameObject.Find("GM");
        _GM.GetComponent<GameManager_Normal>().Player_List.Add(_Player);
    }
}
