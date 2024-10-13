using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;


public class PlayerHandle : NetworkBehaviour
{
    [SerializeField] GameObject[] allPlayers;
    [SerializeField] int playertoLoad;
    private void Start() {
        if(isLocalPlayer){

        }
    }
    [ClientRpc]

    void SpawnPlayer(int aPlayerNum){
        GameObject tPlayerToLoad = Instantiate(allPlayers[aPlayerNum], transform);
        tPlayerToLoad.transform.localPosition=tPlayerToLoad.transform.localEulerAngles = Vector3.zero;
    }
    public void RCPLoadPlayerToAllClients(int aPlayerNum){
        SpawnPlayer(aPlayerNum);
    }
    public void LoadPlayerToAllClients(){
        RCPLoadPlayerToAllClients(playertoLoad);
    }
}
