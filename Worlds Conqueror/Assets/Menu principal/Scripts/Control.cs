using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public void BackToMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Luncher");
    }
    public void Lunch()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void Exit()
    {
        Debug.Log("Le joueur a quitté le Jeux");
        Application.Quit();
    }
    
}
