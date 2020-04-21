using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Joueur
{
    public class PlayerConstructeur : MonoBehaviour
    {
        #region création des joueurs

        public Player p1 = new Player();
        public Player p2 = new Player();
        public Player p3 = new Player();
        public Player p4 = new Player();

        #endregion

        #region Text déclarateur
        
        public Text p1Or;
        public Text p1Fer;

        public Text p2Or;
        public Text p2Fer;

        public Text p3Or;
        public Text p3Fer;

        public Text p4Or;
        public Text p4Fer;
        
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            #region Text update

            p1Or.text = p1.Or.ToString();
            p1Fer.text = p1.Fer.ToString();

            p2Or.text = p2.Or.ToString();
            p2Fer.text = p2.Fer.ToString();

            p3Or.text = p3.Or.ToString();
            p3Fer.text = p3.Fer.ToString();

            p4Or.text = p4.Or.ToString();
            p4Fer.text = p4.Fer.ToString();

            #endregion
        }

        // Update is called once per frame
        void Update()
        {
            /* En comm à cause d'erreurs de compilations
            #region Text update

            p1Or.text = p1.Or.ToString();
            p1Fer.text = p1.Fer.ToString();

            p2Or.text = p2.Or.ToString();
            p2Fer.text = p2.Fer.ToString();

            p3Or.text = p3.Or.ToString();
            p3Fer.text = p3.Fer.ToString();

            p4Or.text = p4.Or.ToString();
            p4Fer.text = p4.Fer.ToString();

            #endregion*/
        }
    }
}