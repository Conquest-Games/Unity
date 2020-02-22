using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MineDeFerScript : MonoBehaviour
{

    private int initLvl = 0;
    private var team = Building.BuiltingTeam.Neutral;

    Building ville = new Building.Batiment(Building.BuildingType.MineDeFer, initLvl, team);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
