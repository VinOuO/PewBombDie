using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet_Amount_Normal : MonoBehaviour {


	void Start () {
    }
	
	void Update () {
		
	}

    public void Set_Bullet_Num(int _Bullet_Num)
    {
        Debug.Log("Shoot!");
        GetComponent<Text>().text = "X" + _Bullet_Num;
    }
}
