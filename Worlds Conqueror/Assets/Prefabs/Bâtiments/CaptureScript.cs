using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Building;

public class CaptureScript : MonoBehaviour
{
    public GameObject Batiment;

    public void TakeDammag(int amount, string s)
    {
        Batiment.GetComponent<BuildingScript>().heals -= amount;
        if (Batiment.GetComponent<BuildingScript>().heals <= 0)
        {
            if (transform.name == "QG_Vert" || transform.name == "QG_Bleu" || transform.name == "QG_Rouge" || transform.name == "QG_Jaune")
            {
                if (Batiment.GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG)
                    Batiment.GetComponent<BuildingScript>().type = Building.BuildingScript.BuildingType.QG_Captured;

                GameOver e = transform.GetComponent<GameOver>();
                if (e != null)
                {
                    e.EndGame = true;
                }
            }
            else
            {
                IsCaptured(s);
            }
        }
    }

    void IsCaptured(string s)
    {
        Batiment.GetComponent<BuildingScript>().heals = Batiment.GetComponent<BuildingScript>().maxHeals;
        Batiment.GetComponent<BuildingScript>().actualLevel = Batiment.GetComponent<BuildingScript>().initialLevel;
        transform.tag = s;
    }
}
