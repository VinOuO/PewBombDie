using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Wall_Normal : MonoBehaviour {

    Vector3 Pos = Vector3.zero;
    float temp = 0;
	void Start () {
        Pos.x = (float)Math.Round(transform.position.x * 10);
        temp = Pos.x % 5;
        if (temp >= 3)
        {
            temp = 5 - temp;
            Pos.x += temp;
        }
        else
        {
            Pos.x -= temp;
        }
        Pos.x /= 10;
        Pos.y = (float)Math.Round(transform.position.y * 10);
        temp = Pos.y % 5;
        if (temp >= 3)
        {
            temp = 5 - temp;
            Pos.y += temp;
        }
        else
        {
            Pos.y -= temp;
        }
        Pos.y /= 10;
        transform.position = Pos;
    }
	
	void Update () {
		
	}
}
