using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public void MoveLeftButtom()
    {
        this.transform.Translate(-1000, 0, 0);
    }

    public void MoveRightButtom()
    {
        this.transform.Translate(1000, 0, 0);
    }

    public void MoveUpButtom()
    {
        this.transform.Translate(0, 500, 0);
    }

    public void MoveDownButtom()
    {
        this.transform.Translate(0, -500, 0);
    }
}
