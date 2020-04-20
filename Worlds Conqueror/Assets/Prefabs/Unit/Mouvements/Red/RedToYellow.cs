using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using WorldConqueror;

namespace WorldConqueror
{

    public class RedToYellow: MonoBehaviour
    {
        public bool on = true;
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
            if (on)
            {
                transform.Translate(Vector3.right * Time.deltaTime * ThisOne.Speed, Space.Self);
                if (transform.position.x > 138)
                    on = false;
                if (transform.position.x > -125 && transform.position.x < -110)
                    transform.Translate(-Vector3.forward * Time.deltaTime * ThisOne.Speed, Space.Self);
                if (transform.position.x > 110 && transform.position.x < 125)
                    transform.Translate(Vector3.forward * Time.deltaTime * ThisOne.Speed, Space.Self);
            }
        }
    }
}