using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            //por ejemplo pintarlo azul
            return;
        }
        CmdSpawnMyUnit();

    }

    public GameObject PlayerUnitPrefab;

    [SyncVar]
    public string PlayerName = "Anonymus cumbiero";
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            CmdSpawnMyUnit();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CmdChangePlayerName("Mati " + Random.Range(1, 100));
        }
        */
    }
    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go = Instantiate(PlayerUnitPrefab);
        NetworkServer.SpawnWithClientAuthority(go,connectionToClient);
    }
    [Command]
    void CmdChangePlayerName(string nombre)
    {
        PlayerName = nombre;
    }

    /*
    [ClientRpc]
    void RpcChangePlayerName(string nombre)
    {
        PlayerName = nombre;
    }
    */
}
