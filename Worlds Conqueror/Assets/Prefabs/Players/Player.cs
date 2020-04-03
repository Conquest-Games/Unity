using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    #region Varriables

    int playerNumber;
    bool is_ingame;
    bool is_computer;
    int or;
    int fer;

    public int IncomeOr;
    public int IncomeFer;

    #endregion

    #region Getters

    public int Or
    {
        get => or;
    }

    public int Fer
    {
        get => fer;
    }

    #endregion

    #region Constructeurs

    public Player (int number, int numberOfPlayer, int maxPlayer)
    {
        this.playerNumber = number;
        this.is_computer = false;
        this.is_ingame = true;
        if (number > maxPlayer)
        {
            this.is_ingame = false;
        }
        if (number > numberOfPlayer)
        {
            this.is_computer = true;
        }
    }

    public void Initialisate (int incomeOr, int incomeFer)
    {
        this.or = 100;
        this.fer = 0;
        this.IncomeFer = incomeFer;
        this.IncomeOr = incomeOr;
    }

    #endregion

    #region Ressources Actions

    public void RemoveOr(int costOr)
    {
        or -= costOr;
    }

    public void RemoveFer(int costFer)
    {
        fer -= costFer;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
