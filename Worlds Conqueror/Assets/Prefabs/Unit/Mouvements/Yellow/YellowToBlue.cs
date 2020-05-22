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

    public class YellowToBlue : MonoBehaviour
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

            if (transform.position.x < -138 && transform.position.z < -130)
            {
                Destroy(gameObject);
                //GameObject.Find("QG_Bleu").GetComponent<BuildingScript>().heals -= ThisOne.UnitDamage;
            }
            if (transform.position.z < 155 && transform.position.z > 145)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -150, 0));

            if (transform.position.z > 25 && transform.position.x < -34)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -150, 0));
            
            if (transform.position.x > 67 && transform.position.x < 68)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -90, 0));
        }
    }
}