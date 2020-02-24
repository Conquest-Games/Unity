using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{

    public class VILLE : MonoBehaviour
    {
        private static int initLvl = 0;
        private static Building.BuildingTeam team = Building.BuildingTeam.Neutral;
    
        Building ville = new Building(Building.BuildingType.Ville, initLvl, team);

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