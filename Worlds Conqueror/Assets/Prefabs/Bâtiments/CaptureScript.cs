using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Building;
using GameControl;
using WorldConqueror;

public class CaptureScript : MonoBehaviour
{
    public GameObject Batiment;

    private int couldown = 0;

    public void TakeDammag(int amount, string s)
    {
        if (Batiment.GetComponent<BuildingScript>().heals > amount)
        {
            Batiment.GetComponent<BuildingScript>().heals -= amount;
        }
        else
        {
            Batiment.GetComponent<BuildingScript>().heals = 0;
        }
        
        if (Batiment.GetComponent<BuildingScript>().heals <= 0)
        {
            if (transform.name == "QG_Vert" || transform.name == "QG_Bleu" || transform.name == "QG_Rouge" || transform.name == "QG_Jaune")
            {
                if (Batiment.GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG)
                {
                    Batiment.GetComponent<BuildingScript>().type = Building.BuildingScript.BuildingType.QG_Captured;

                    GameOver.EndGame = true;
                }
            }
            
            IsCaptured(s);
        }
    }

    void Update()
    {
        if (couldown > 0)
        {
            couldown -= 1;
            Batiment.GetComponent<BuildingScript>().heals = Batiment.GetComponent<BuildingScript>().maxHeals;
        }
    }
    
    void IsCaptured(string s)
    {
        transform.tag = s;
        couldown = 500;
        Batiment.GetComponent<BuildingScript>().actualLevel = Batiment.GetComponent<BuildingScript>().initialLevel;
    }
    
}
