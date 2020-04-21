using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Joueur
{
    public class PlayerConstructeur : MonoBehaviour
    {
        #region création des joueurs

        private Player p1 = new Player();

        #endregion

        #region Text déclarateur
        
        public Text p1Or;
        public Text p1fer;
        
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            #region Text update

            p1Or.text = p1.Or.ToString();
            p1fer.text = p1.Fer.ToString();

            #endregion
        }

        // Update is called once per frame
        void Update()
        {
            #region Text update

            p1Or.text = p1.Or.ToString();
            p1fer.text = p1.Fer.ToString();

            #endregion
        }
    }
}