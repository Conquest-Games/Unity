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

        // Start is called before the first frame update
        void Start()
        {
            choice = Random.Range(0, 100);
            if (Control.alone)
                InvokeRepeating("Spawn", 0f, 2f);
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
            Vector3 spawnPosy = new Vector3(138.4f, 0, 150);

            if (choice < 20)
            {
                GameObject TheOney = PhotonNetwork.Instantiate("Infantry Level 2", spawnPosy, Quaternion.identity);
                TheOney.AddComponent<YellowToBlue>();
                TheOney.tag = "Yellow";
            }
            else if (choice < 35)
            {
                GameObject TheOney = PhotonNetwork.Instantiate("Archer Level 2", spawnPosy, Quaternion.identity);
                TheOney.AddComponent<YellowToBlue>();
                TheOney.tag = "Yellow";
            }
            else if (choice < 45)
            {
                Debug.Log("cavalery spawned");

                //spawn cavalery
                /*GameObject TheOney = PhotonNetwork.Instantiate("Cavalery Variant", spawnPosy, Quaternion.identity);
                TheOney.AddComponent<YellowToBlue>();
                TheOney.tag = "Yellow";*/
            }
            else if (choice < 50)
            {
                Debug.Log("siegeWeapon spawned");

                //spawn SiegeWeapon
                /*GameObject TheOney = PhotonNetwork.Instantiate("SiegeWeapon Variant", spawnPosy, Quaternion.identity);
                TheOney.AddComponent<YellowToBlue>();
                TheOney.tag = "Yellow";*/
            }
            else
            {

            }
        }
    }
}