using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScript : MonoBehaviour
{
    public int hp = 200;

    public void TakeDammag(int amount, string s)
    {
        hp -= amount;
        if (hp <= 0)
        {
            if (transform.name == "QG_Vert" || transform.name == "QG_Bleu" || transform.name == "QG_Rouge" || transform.name == "QG_Jaune")
            {
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
        hp = 200;
        transform.tag = s;
    }
}
