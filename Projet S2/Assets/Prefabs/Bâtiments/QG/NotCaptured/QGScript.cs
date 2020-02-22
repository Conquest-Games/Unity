using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QGScript : MonoBehaviour
{

    private int initLvl = 0;
    private var team = Building.BuiltingTeam.Neutre;

    Building ville = new Building.Batiment(Building.BuildingType.QG, initLvl, team);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
