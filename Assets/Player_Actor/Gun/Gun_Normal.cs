using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Normal : MonoBehaviour{

    public GameObject Bullet;
    Rigidbody2D Rgdbody;
    Vector2 Transform2D;
    GameObject Mouse;
    float Bullet_Speed = 10;
    void Start () {
        Rgdbody = GetComponent<Rigidbody2D>();
        Transform2D.Set(transform.position.x, transform.position.y);
        Mouse = GameObject.Find("Mouse");
    }
	
	void Update () {
        if (!transform.parent.GetComponent<Player_Normal>().isLocalPlayer)
        {
            return;
        }
        Gun_Rotate();
    }
    public GameObject Shoot()
    {
        GameObject _temp;
        _temp = Instantiate(Bullet, transform.GetChild(0).position, transform.rotation);
        //_temp.GetComponent<Bullet_Normal>().Dir = transform.up;
        _temp.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Bullet_Speed;
        return _temp;
    }

    void Gun_Rotate()
    {
        Vector2 _temp,_Mouse_Pos = Vector2.zero;

        _Mouse_Pos.Set(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)).y);
        Transform2D.Set(transform.position.x, transform.position.y);
        _temp = _Mouse_Pos - Transform2D;

        if (_temp.x > 0)
        {
            Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up) * -1);
        }
        else
        {
            Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up));
        }
        /* --------------------------------------------------------------------------限制射擊角度
        Vector2 _a = Vector2.zero, _b = Vector2.zero;
        _a.Set(transform.parent.transform.up.x, transform.parent.transform.up.y);
        _b.Set(transform.up.x, transform.up.y);
        if (_temp.x > 0)
        {
            if (_a.x - _b.x > 0)
            {
                if (Vector2.Angle(_a, _b) <= 60 || Vector2.Angle(_a, _temp) < Vector2.Angle(_a, _b))
                {
                    Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up) * -1);
                }
            }
            else
            {
                if (Vector2.Angle(_a, _b) <= 60 || Vector2.Angle(_a, _temp) < Vector2.Angle(_a, _b))
                {
                    Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up) * -1);
                }
            }

        }
        else
        {
            if (_a.x - _b.x > 0)
            {
                if (Vector2.Angle(_a, _b) <= 60 || Vector2.Angle(_a, _temp) < Vector2.Angle(_a, _b))
                {
                    Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up));
                }
            }
            else
            {
                if (Vector2.Angle(_a, _b) <= 60 || Vector2.Angle(_a, _temp) < Vector2.Angle(_a, _b))
                {
                    Rgdbody.MoveRotation(Vector2.Angle(_temp, Vector2.up));
                }
            }
        }
        */
    }
}
