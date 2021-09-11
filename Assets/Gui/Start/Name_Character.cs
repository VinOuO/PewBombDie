using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name_Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Send_Charater_Name()
    {
        transform.parent.GetComponent<Start_UI>().Character_Name = transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().text;
    }
}
