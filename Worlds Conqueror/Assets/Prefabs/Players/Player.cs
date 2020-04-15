using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joueur
{
    public class Player : MonoBehaviour
    {

        #region Varriables

        int or;
        int fer;
        int incomeFer;
        int incomeOr;


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

        public Player()
        {
            this.or = 100;
            this.fer = 0;
            this.incomeFer = 0;
            this.incomeOr = 0;
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
}