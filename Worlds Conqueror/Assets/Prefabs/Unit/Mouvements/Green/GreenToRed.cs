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
            else if(nam == "PathFinder")
                ThisOne = new PathFinder(PhotonNetwork.LocalPlayer.GetTeam());
            else
                ThisOne = new Infantry(PhotonNetwork.LocalPlayer.GetTeam());


        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < -138 && transform.position.z > 130)
            {
                Destroy(gameObject);
                GameObject.Find("QG_Rouge").GetComponent<QGScript>().life -= ThisOne.UnitDamage;
            }
            if (transform.position.x > -34.6 && transform.position.x < 69.2)
                transform.Translate(-Vector3.right * Time.deltaTime * ThisOne.Speed);
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * ThisOne.Speed, Space.Self);
                transform.Translate(-Vector3.right * Time.deltaTime * ThisOne.Speed * 0.576f);
            }
        }
    }
}