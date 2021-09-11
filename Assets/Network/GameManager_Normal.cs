using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager_Normal : NetworkBehaviour {

    public List<GameObject> Player_List;
    [SyncVar(hook = "Check_Ready_Player_Num")] public int Ready_Player_Num = 0;

	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }

	void Update () {

    }

    void Check_Ready_Player_Num(int _Ready_Player_Num)
    {
        if (_Ready_Player_Num == Player_List.Count)
        {
            foreach (GameObject i in Player_List)
            {
                i.GetComponent<Player_Normal>().RpcStartGame();
            }
        }
    }

    [ClientRpc]
    public void RpcDoOnClient(int foo)
    {
        Debug.Log("OnClient " + foo);
    }
    /*
    [ClientRpc]
    void RpcSetPlayer()
    {
        //PlayerController
        //Debug.Log(ClientScene.localPlayers); 
        if (NetworkManager.singleton.numPlayers == 1)
        {
            NetworkManager.singleton.client.connection.playerControllers[0].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/Player_C0");

        }
        else if (NetworkManager.singleton.numPlayers == 2)
        {
            NetworkManager.singleton.client.connection.playerControllers[0].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/Player_C0");
            NetworkManager.singleton.client.connection.playerControllers[1].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/Player_C1");

        }
        else if (NetworkManager.singleton.numPlayers == 3)
        {
            NetworkManager.singleton.client.connection.playerControllers[0].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/Player_C0");
            NetworkManager.singleton.client.connection.playerControllers[1].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/Player_C1");
            NetworkManager.singleton.client.connection.playerControllers[2].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Player/Player_C2");
            
        }

    }
    */
}
