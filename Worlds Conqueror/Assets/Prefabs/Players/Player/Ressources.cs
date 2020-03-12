using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{

    private int or;
    private int fer;

    public int Or
    {
        get => or;
    }

    public int Fer
    {
        get => fer;
    }

    public int IncomeOr;
    public int IncomeFer;
    public void RemoveOr (int costOr)
    {
        or -= costOr;
    }

    public void RemoveFer (int costFer)
    {
        fer -= costFer;
    }

    // Start is called before the first frame update
    void Start()
    {
        or = 100;
        fer = 0;
        IncomeOr = 0;
        IncomeFer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        or += IncomeOr;
        fer += IncomeFer;
    }
}
