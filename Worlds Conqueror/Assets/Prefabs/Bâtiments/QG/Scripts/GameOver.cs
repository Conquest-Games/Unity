using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public bool EndGame = false;

    public GameObject gameOverUI;
    
    void Update()
    {
        if (EndGame)
        {
            End();
        }
    }

    void End()
    {
        GameObject.Find("GameOver").SetActive(true);
    }
}
