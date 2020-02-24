using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Building
{
    public class MineDeFerScript : MonoBehaviour
    {

        private int initLvl = 0;
        private Building.BuildingTeam team = Building.BuildingTeam.Neutral;

        Building ville = new Building(Building.BuildingType.MineDeFer, initLvl, team);

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
