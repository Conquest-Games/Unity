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

    public class GreenToYellow : MonoBehaviour
    {
        public Unit ThisOne;
        private void Start()
        {
            string nam = name;
            if(nam == "Archer")
                ThisOne = new Archer(PhotonNetwork.LocalPlayer.GetTeam());
            else if(nam == "Cavalry")
                ThisOne = new Cavalry(PhotonNetwork.LocalPlayer.GetTeam());
            else if(nam == "SiegeWeapon")
                ThisOne = new SiegeWeapon(PhotonNetwork.LocalPlayer.GetTeam());
            else if(nam == "PathFinder")
                ThisOne = new PathFinder(PhotonNetwork.LocalPlayer.GetTeam());
            else
                ThisOne = new Infantry(PhotonNetwork.LocalPlayer.GetTeam());


        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * ThisOne.Speed, Space.Self);
            if (transform.position.z > 150 && transform.position.x > 120)
            {
                Destroy(gameObject);
                GameObject.Find("QG_Jaune").GetComponent<QGScript>().life -= ThisOne.UnitDamage;
            }
            if (transform.position.z > -150 && transform.position.z < -149)
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -30, 0));
            }
            
            if (transform.position.z > -121 && transform.position.z < -119)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));

            if (transform.position.z > -61 && transform.position.z < -59)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 30, 0));
            
            if (transform.position.z > -31 && transform.position.z < -29)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
            
            if (transform.position.z > 29 && transform.position.z < 31)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -30, 0));


            if (transform.position.z > 59 && transform.position.z < 61)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));

            if (transform.position.z > 119 && transform.position.z < 121)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 30, 0));

        }
    }
}