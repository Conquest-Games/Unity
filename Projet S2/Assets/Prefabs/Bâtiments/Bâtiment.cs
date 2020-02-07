using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public enum BuildingType
    {
        QG, QG_Captured, Ville, MineDeFer, Caserne, TourDarcher, None
    }

    protected BuildingType type;

    public BuildingType Type
    {
        get => type;
    }

    // Start is called before the first frame update
    void Start()
    {
        //nothing to do
    }

    // Update is called once per frame
    void Update()
    {
        //nothing to do
    }
}
