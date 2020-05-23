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

        private bool cooldownn = false;

        private int cooldown = 300;
        
        private void Start()
        {
        }

        void Update()
        {
            if (EndGame)
            {
                End();
            }

            if (cooldownn)
            {
                if (cooldown > 0)
                    cooldown--;
                else
                {
                    cooldownn = false;
                    EndGame = false;
                    GameObject.Find("Game Over").SetActive(false);
                    GameObject.Find("Upgrade").SetActive(false);
                    GameObject.Find("Unité Menu").SetActive(false);
                    GameObject.Find("Menu Basic").SetActive(false);
                    GameObject.Find("Interface Ressource").SetActive(false);
                }
            }
        }

        void End()
        {
            GO.SetActive(true);
            cooldownn = true;
        }
    }
}