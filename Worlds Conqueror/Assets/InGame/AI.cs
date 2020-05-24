using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


namespace WorldConqueror
{
    public class AI : MonoBehaviour
    {
        private int count = 100;

        private int choice;
        private int lane;

        // Start is called before the first frame update
        void Start()
        {

            if (Control.alone)
            {
                InvokeRepeating("Spawn", 0f, 2f);
                GameObject.Find("QG_Rouge").tag = "Neutral"; 
                GameObject.Find("QG_Vert").tag = "Neutral"; 
                choice = Random.Range(0, 100);
                lane = Random.Range(0, 2);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void Spawn()
        {
            choice = Random.Range(0, 100);
            lane = Random.Range(0, 2);

            Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
            
            
            if (choice < 20)
            {
                GameObject TheOney = PhotonNetwork.Instantiate("InfantryYellow", spawnPosy, Quaternion.identity);
                if (lane == 0) 
                    TheOney.AddComponent<YellowToRed>();
                else if (lane == 1)
                    TheOney.AddComponent<YellowToBlue>();
                else
                    TheOney.AddComponent<YellowToGreen>();

            }
            else if (choice < 35)
            {
                GameObject TheOney = PhotonNetwork.Instantiate("ArcherYellow", spawnPosy, Quaternion.identity);
                if (lane == 0) 
                    TheOney.AddComponent<YellowToRed>();
                else if (lane == 1)
                    TheOney.AddComponent<YellowToBlue>();
                else
                    TheOney.AddComponent<YellowToGreen>();
            }
            else if (choice < 45)
            {
                GameObject TheOney = PhotonNetwork.Instantiate("CavaleryYellow", spawnPosy, Quaternion.identity);
                if (lane == 0) 
                    TheOney.AddComponent<YellowToRed>();
                else if (lane == 1)
                    TheOney.AddComponent<YellowToBlue>();
                else
                    TheOney.AddComponent<YellowToGreen>();
            }
            else if (choice < 50)
            {
                GameObject TheOney = PhotonNetwork.Instantiate("CatapulteYellow", spawnPosy, Quaternion.identity);
                if (lane == 0) 
                    TheOney.AddComponent<YellowToRed>();
                else if (lane == 1)
                    TheOney.AddComponent<YellowToBlue>();
                else
                    TheOney.AddComponent<YellowToGreen>();
            }
        }
    }
}