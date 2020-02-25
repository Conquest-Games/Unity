using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitter : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Le joueur a quitté le Jeux");
        Application.Quit();
    }
}
