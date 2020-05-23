using System;
using System.Collections;
using System.Collections.Generic;
using Building;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using WorldConqueror;

namespace WorldConqueror
{

    public class RedToGreen : MonoBehaviour
    {
        public GameObject ThisUnit;
        public Unit ThisOne;

        private void Start()
        {
            string nam = name;
            if (nam == "Archer")
                ThisUnit = GameObject.Find("Archery");
            else if (nam == "Cavalry")
                ThisUnit = GameObject.Find("Cavalery");
            else if (nam == "SiegeWeapon")
                ThisUnit = GameObject.Find("SiegeWeapon");
            else if (nam == "Ninja")
                ThisUnit = GameObject.Find("Ninja");
            else
                ThisUnit = GameObject.Find("Infantry");

            ThisOne = ThisUnit.GetComponent<Unit>();

        }

        // Update is called once per frame
        void Update()
        {
            if (!gameObject.GetComponent<Unit>().fight)
                transform.Translate(Vector3.forward * Time.deltaTime * ThisOne.Speed, Space.Self);

            if (transform.position.x > 138 && transform.position.z < -130)
            {
                gameObject.AddComponent<GreenToBlue>();
                Destroy(gameObject.GetComponent<RedToGreen>());
            }
            if (transform.position.z < 151 && transform.position.z > 149)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 150, 0));
            if (transform.position.z < -29 && transform.position.x < -34)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
            if (transform.position.x > 69 && transform.position.x < 71)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 150, 0));
        }
    }
}