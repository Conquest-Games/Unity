using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using WorldConqueror;

namespace WorldConqueror
{
    public class Control : MonoBehaviour
    {
        public static bool alone = false;


        public void SetAlone()
        {
            alone = true;
            PhotonNetwork.OfflineMode = true;
        }
        public void BackToMenu()
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Luncher");
        }

        public void Lunch()
        {
            alone = false;
            SceneManager.LoadScene("Lobby");
        }

        public void LunchGame()
        {
            SceneManager.LoadScene("InGame");
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Map()
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}