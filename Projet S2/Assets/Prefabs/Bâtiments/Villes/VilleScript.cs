using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Ville
{

    public class VILLE : Building
    {
        private int initLvl = 0;
        private var team = Building.BuiltingTeam.Neutre;
    
        Building ville = new Building.Batiment(Building.BuildingType.Ville, initLvl, team);

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