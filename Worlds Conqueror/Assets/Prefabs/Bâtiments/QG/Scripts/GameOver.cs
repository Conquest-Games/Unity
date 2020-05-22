using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameControl
{
    public class GameOver : MonoBehaviour
    {
        public GameObject GO;
        public static bool EndGame = false;

        //public GameObject gameOverUI;

        void Update()
        {
            if (EndGame)
            {
                End();
            }
        }

        void End()
        {
            Debug.Log("end() called");
            float time = Time.time;
            GO.SetActive(true);
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("Luncher");
        }
    }
}