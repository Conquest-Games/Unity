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
            IsCaptured(s);
        }
    }

    void IsCaptured(string s)
    {
        hp = 200;
        transform.tag = s;
    }
}
