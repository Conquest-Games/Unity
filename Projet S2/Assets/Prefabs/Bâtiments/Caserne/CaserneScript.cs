using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class CaserneScript : MonoBehaviour
    {
        private static int initLvl = 0;
        private static Building.BuildingTeam team = Building.BuildingTeam.Neutral;

        Building ville = new Building(Building.BuildingType.Caserne, initLvl, team);
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
