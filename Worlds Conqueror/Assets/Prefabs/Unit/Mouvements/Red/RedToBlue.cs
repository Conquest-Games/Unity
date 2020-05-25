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

    public class RedToBlue : MonoBehaviour
    {
        public GameObject ThisUnit;
        public Unit ThisOne;

        private void Start()
        {
            ThisUnit = gameObject;
            ThisOne = ThisUnit.GetComponent<Unit>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!gameObject.GetComponent<Unit>().fight)
                transform.Translate(Vector3.forward * Time.deltaTime * ThisOne.Speed, Space.Self);
            if (transform.position.z < -150 && transform.position.x < -120)
            {
                gameObject.AddComponent<BlueToGreen>();
                Destroy(gameObject.GetComponent<RedToBlue>());
            }
            if (transform.position.z < 155 && transform.position.z > 145)
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 150, 0));
            }
            
            if (transform.position.z < 121 && transform.position.z > 119)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 180, 0));

            if (transform.position.z < 61 && transform.position.z > 59)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -150, 0));
            
            if (transform.position.z < 31 && transform.position.z > 29)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 180, 0));
            
            if (transform.position.z < -29 && transform.position.z > -31)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 150, 0));


            if (transform.position.z < -59 && transform.position.z > -61)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 180, 0));

            if (transform.position.z < -119 && transform.position.z > -121)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -150, 0));
        }
    }
}