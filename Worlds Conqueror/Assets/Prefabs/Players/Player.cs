using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Joueur
{
    public class Player : MonoBehaviour
    {

        #region Varriables

        private static int or = 100;
        private static int fer = 0;
        private static int incomeFer = 10;
        private static int incomeOr = 50;

        #endregion

        #region Text déclarateur

        public Text pOr;
        public Text pFer;
        public Text pOrIncome;
        public Text pFerIncome;

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

        #region Ressources Actions

        //Actualise les ressource avec l'income de chaque ressource
        public void AddIncome()
        {
            if (or + incomeOr >= 9999)
                or = 9999;
            else
                or += incomeOr;

            if (fer + incomeFer >= 9999)
                fer = 9999;
            else
                fer += incomeFer;
        }

        //Ajoute amount a Or
        public void AjoutOr(int amount)
        {
            or += amount;
        }

        //Ajoute amount a Fer
        public void AjoutFer(int amount)
        {
            fer += amount;
        }

        //Retire cout et renvoi true si le cout est inferieurs au ressourcers, sinon renvoi false et le nom de la ressource qui manque
        public static (bool, string) Cout(int costOr, int costFer = 0)
        {
            if (or < costOr && fer < costFer)
            {
                return (false, "Pas assez d'Or et de Fer");
            }
            if (or < costOr)
            {
                return (false, "Pas assez d'Or");
            }
            if (fer < costFer)
            {
                return (false, "Pas assez de Fer");
            }
            or -= costOr;
            fer -= costFer;
            return (true, "");
        }

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("AddIncome", 0f, 1);

            #region Text update

            pOr.text = or.ToString();
            pFer.text = fer.ToString();
            pOrIncome.text = "+" + incomeOr.ToString() + "/s";
            pFerIncome.text = "+" + incomeFer.ToString() + "/s";

            #endregion
        }

        // Update is called once per frame
        void Update()
        {
            #region Text update

            pOr.text = or.ToString();
            pFer.text = fer.ToString();
            pOrIncome.text = "+" + incomeOr.ToString() + "/s";
            pFerIncome.text = "+" + incomeFer.ToString() + "/s";

            #endregion
        }
    }
}