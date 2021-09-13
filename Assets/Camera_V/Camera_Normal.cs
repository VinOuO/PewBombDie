using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Normal : MonoBehaviour
{

    float Move_Speed = 5;
    public GameObject Player;
    public GameObject[] Players;
    Vector2 Pos_2D = Vector2.zero;
    Vector3 temp = Vector3.zero;
    void Start()
    {

    }

    void Update()
    {
        if (Player == null)
        {
            Players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject _Player in Players)
            {
                if (_Player.GetComponent<Player_Normal>().isLocalPlayer)
                {
                    Player = _Player;
                }
            }
        }
        else
        {
            if (Player.transform.position.x != Pos_2D.x && Player.transform.position.y != Pos_2D.y)
            {
                Pos_2D.x = Player.transform.position.x;
                Pos_2D.y = Player.transform.position.y;
                temp.x = Pos_2D.x;
                temp.y = Pos_2D.y;
                temp.z = -10;
                transform.position = temp;
            }
        }
        ZoomInOut();
    }

    void ZoomInOut()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && Camera.main.orthographicSize > 1)
        {
            Camera.main.orthographicSize -= 0.2f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && Camera.main.orthographicSize < 4)
        {
            Camera.main.orthographicSize += 0.2f;
        }
    }
    void Move()
    {
        if (Input.mousePosition.x <= Screen.width / 10)
        {
            transform.position += Vector3.left * Time.deltaTime * Move_Speed;
        }
        else if (Input.mousePosition.x >= Screen.width * 9 / 10)
        {
            transform.position += Vector3.right * Time.deltaTime * Move_Speed;
        }

        if (Input.mousePosition.y <= Screen.height / 10)
        {
            transform.position += Vector3.down * Time.deltaTime * Move_Speed;
        }
        else if (Input.mousePosition.y >= Screen.height * 9 / 10)
        {
            transform.position += Vector3.up * Time.deltaTime * Move_Speed;
        }
    }
}
