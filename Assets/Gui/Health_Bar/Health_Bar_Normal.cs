using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar_Normal : MonoBehaviour {
    Image Img;
    Quaternion Lock;
    GameObject Player;
    Vector3 Offect_Player;
	void Start () {
        Lock = Quaternion.Euler(0,0,0);
        transform.rotation = Lock;
        Img = transform.GetChild(1).GetComponent<Image>();
        Player = transform.parent.gameObject;
        //Offect_Player = new Vector3(-0.28f, 6.1f, 0);
        Offect_Player = transform.position - Player.transform.position;
    }
	
	void Update () {

    }

    private void LateUpdate()
    {
        transform.position = Offect_Player + Player.transform.position;
        transform.rotation = Lock;
    }

    public void Change_Amount(float _amount)
    {
        if(Img == null)
        {
            Img = transform.GetChild(1).GetComponent<Image>();
        }
        Img.fillAmount = _amount;
    }
}
