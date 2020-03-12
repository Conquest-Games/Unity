using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class LobbyScript : MonoBehaviour
{
    public Text NbPlayers;
    public Text CoInfos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoInfos.text = PhotonNetwork.NetworkClientState.ToString();
        if (PhotonNetwork.InRoom)
            NbPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        else
        {
            NbPlayers.text = "0";
        }
    }
}
