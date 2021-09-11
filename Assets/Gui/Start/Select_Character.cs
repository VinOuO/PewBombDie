using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Character : MonoBehaviour {

    public Sprite[] Character_Color;
    int i = 0;


	void Start () {
		
	}
	

	void Update () {
		
	}

    public void Change_Character(string _L_or_R)
    {
        if(_L_or_R == "Left")
        {
            i--;
            if (i < 0)
            {
                i = 2;
            }
        }
        else
        {
            i++;
            if (i > 2)
            {
                i = 0;
            }
        }
        transform.GetChild(0).GetComponent<Image>().sprite = Character_Color[i];
        transform.parent.GetComponent<Start_UI>().Character_Color = "Player_C" + i;
    }
}
