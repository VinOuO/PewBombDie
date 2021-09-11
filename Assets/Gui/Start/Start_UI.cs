using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Start_UI : MonoBehaviour {

    public string Character_Name = "Player";
    public string Character_Color = "Player_C0";

    void Start () {
		
	}
	
	void Update () {
		
	}


    public void End()
    {
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (i.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                i.GetComponent<Player_ID>().CmdSetMyNameandColor(Character_Name, Character_Color);
            }
        }

        Destroy(this.gameObject);
    }
}
