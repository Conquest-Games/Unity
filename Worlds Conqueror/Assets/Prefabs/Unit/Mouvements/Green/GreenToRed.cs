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

            if (transform.position.x < -138 && transform.position.z > 130)
            {
                gameObject.AddComponent<RedToYellow>();
                Destroy(gameObject.GetComponent<GreenToRed>());
            }
            
            if (transform.position.z > -155 && transform.position.z < -145)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -30, 0));
            if (transform.position.z > -35 && transform.position.x < -34)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -30, 0));
            if (transform.position.x > 69 && transform.position.x < 71)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, -90, 0));

        }
    }
}