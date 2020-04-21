using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joueur
{
    public class Player : MonoBehaviour
    {

        #region Varriables

        private int or;
        private int fer;
        private int incomeFer;
        private int incomeOr;


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
            or = 100;
            fer = 0;
            incomeFer = 0;
            incomeOr = 0;
        }

        #endregion

        #region Ressources Actions

        public void AjoutOr(int costOr)
        {
            or += costOr;
        }

        public void AjoutFer(int costFer)
        {
            fer += costFer;
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