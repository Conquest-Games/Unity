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

    public class BlueToRed : MonoBehaviour
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
            if (transform.position.z > 150 && transform.position.x < -120)
            {
                Destroy(gameObject);
                GameObject.Find("QG_Rouge").GetComponent<QGScript>().life -= ThisOne.UnitDamage;
            }

            if (transform.position.z > -150 && transform.position.z < -120)
            {
                transform.Translate(Vector3.right * Time.deltaTime * ThisOne.Speed * 0.5f, Space.Self);
                //Work in progress: transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 30, 0));
            }

            if (transform.position.z > -60 && transform.position.z < -30)
                transform.Translate(-Vector3.right * Time.deltaTime * ThisOne.Speed * 0.5f, Space.Self);

            if (transform.position.z > 30 && transform.position.z < 60)
                transform.Translate(Vector3.right * Time.deltaTime * ThisOne.Speed * 0.5f, Space.Self);

            if (transform.position.z > 120)
                transform.Translate(-Vector3.right * Time.deltaTime * ThisOne.Speed * 0.5f, Space.Self);

        }
    }
}