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

    public class GreenToRed : MonoBehaviour
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
            else if(nam == "Ninja")
                ThisOne = new Ninja(PhotonNetwork.LocalPlayer.GetTeam());
            else
                ThisOne = new Infantry(PhotonNetwork.LocalPlayer.GetTeam());


        }

        // Update is called once per frame
        void Update()
        {
            if (!gameObject.GetComponent<Unit>().fight)
                transform.Translate(Vector3.forward * Time.deltaTime * ThisOne.Speed, Space.Self);

            if (transform.position.x < -138 && transform.position.z > 130)
            {
                Destroy(gameObject);
                GameObject.Find("QG_Rouge").GetComponent<QGScript>().life -= ThisOne.UnitDamage;
            }
            
            if (transform.position.z > -155 && transform.position.z < -145)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 30, 0));
            if (transform.position.x > -30 && transform.position.x < -31)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
            if (transform.position.x > 69 && transform.position.x < 71)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -90, 0));

        }
    }
}