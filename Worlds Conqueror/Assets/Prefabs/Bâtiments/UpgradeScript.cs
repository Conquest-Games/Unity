using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class UpgradeScript : MonoBehaviour
    {
        public GameObject objetAUpgrade;

        void OnMouseDown()
        {
            objetAUpgrade.GetComponent<BuildingScript>().upgradeBuilding();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
