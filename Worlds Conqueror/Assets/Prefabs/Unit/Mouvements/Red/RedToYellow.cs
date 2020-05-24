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

    public class RedToYellow: MonoBehaviour
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
            if (transform.position.x > 138 && transform.position.z > 130)
            {
                gameObject.AddComponent<YellowToGreen>();
                Destroy(gameObject.GetComponent<RedToYellow>());
            }
            
            if (transform.position.x > -140 && transform.position.x < -135)
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 150, 0));

            if (transform.position.x > -121 && transform.position.x < -119) 
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 90, 0));
            if (transform.position.x > 122 && transform.position.x < 123) 
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 30, 0));

        }
    }
}