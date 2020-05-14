﻿using System;
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

    public class BlueToGreen : MonoBehaviour
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
            if (transform.position.x > 138 && transform.position.z < -130)
            {
                Destroy(gameObject);
                GameObject.Find("QG_Vert").GetComponent<QGScript>().life -= ThisOne.UnitDamage;
            }
            if (transform.position.x > -140 && transform.position.x < -135)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 30, 0));

            if (transform.position.x > -126 && transform.position.x < -124) 
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
            if (transform.position.x > 109 && transform.position.x < 111) 
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 150, 0));
            
        }
    }
}