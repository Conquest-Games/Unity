using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Building;
using WorldConqueror;
using UnityEngine.SceneManagement;

namespace Joueur
{
    public class Player : MonoBehaviour
    {

        #region Varriables

        private static float or = 0;
        private static float fer = 0;
        private static int incomeFer = 0;
        private static int incomeOr = 0;
        public string tag;

        public GameObject GameOver;
        public GameObject Interface;
        public GameObject Victoire;
        private bool loose;
        private int cooldown = 300;
        private int compteur = 1000;

        #endregion

        #region Text déclarateur

        public Text pOr;
        public Text pFer;
        public Text pOrIncome;
        public Text pFerIncome;

        #endregion

        #region Ressources Actions

        //Actualise les ressource avec l'income de chaque ressource
        public void AddIncome()
        {
            if (or + incomeOr * 0.05f >= 9999)
                or = 9999;
            else
                or += incomeOr * 0.05f;

            if (fer + incomeFer * 0.05f >= 9999)
                fer = 9999;
            else
                fer += incomeFer * 0.05f;
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

        private void ActualiseIncomes()
        {
            incomeOr = 0;
            incomeFer = 0;

            GameObject[] batiments = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject i in batiments)
            {
                if (i.GetComponent<BuildingScript>() != null)
                {
                    incomeFer += i.GetComponent<BuildingScript>().FerIncome;
                    incomeOr += i.GetComponent<BuildingScript>().OrIncome;
                }
            }
        }

        #endregion

        #region Reset

        private void Reset()
        {
            or = 100;
            fer = 0;
        }

        void ResetMap()
        {
            GameObject[] red = GameObject.FindGameObjectsWithTag("Red");

            foreach (GameObject i in red)
            {
                if (i.GetComponent<Unit>() != null)
                    Destroy(i);
                if (i.GetComponent<BuildingScript>() != null)
                {
                    if (i.name == "QG_Bleu")
                        i.tag = "Blue";
                    else if (i.name == "QG_Rouge")
                        i.tag = "Red";
                    else if (i.name == "QG_Jaune")
                        i.tag = "Yellow";
                    else if (i.name == "QG_Vert")
                        i.tag = "Green";
                    else
                        i.tag = "Neutral";
                }
            }

            GameObject[] blue = GameObject.FindGameObjectsWithTag("Blue");

            foreach (GameObject i in blue)
            {
                if (i.GetComponent<Unit>() != null)
                    Destroy(i);
                if (i.GetComponent<BuildingScript>() != null)
                {
                    if (i.name == "QG_Bleu")
                        i.tag = "Blue";
                    else if (i.name == "QG_Rouge")
                        i.tag = "Red";
                    else if (i.name == "QG_Jaune")
                        i.tag = "Yellow";
                    else if (i.name == "QG_Vert")
                        i.tag = "Green";
                    else
                        i.tag = "Neutral";
                }
            }

            GameObject[] yellow = GameObject.FindGameObjectsWithTag("Yellow");

            foreach (GameObject i in yellow)
            {
                if (i.GetComponent<Unit>() != null)
                    Destroy(i);
                if (i.GetComponent<BuildingScript>() != null)
                {
                    if (i.name == "QG_Bleu")
                        i.tag = "Blue";
                    else if (i.name == "QG_Rouge")
                        i.tag = "Red";
                    else if (i.name == "QG_Jaune")
                        i.tag = "Yellow";
                    else if (i.name == "QG_Vert")
                        i.tag = "Green";
                    else
                        i.tag = "Neutral";
                }
            }

            GameObject[] green = GameObject.FindGameObjectsWithTag("Green");

            foreach (GameObject i in green)
            {
                if (i.GetComponent<Unit>() != null)
                    Destroy(i);
                if (i.GetComponent<BuildingScript>() != null)
                {
                    if (i.name == "QG_Bleu")
                        i.tag = "Blue";
                    else if (i.name == "QG_Rouge")
                        i.tag = "Red";
                    else if (i.name == "QG_Jaune")
                        i.tag = "Yellow";
                    else if (i.name == "QG_Vert")
                        i.tag = "Green";
                    else
                        i.tag = "Neutral";
                }
            }

        }

        #endregion

        #region endGame

        void IsLoosed()
        {
            switch (tag)
            {
                case "Red":
                    if (GameObject.Find("QG_Rouge").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
                        loose = true;
                    break;
                case "Green":
                    if (GameObject.Find("QG_Green").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
                        loose = true;
                    break;
                case "Yellow":
                    if (GameObject.Find("QG_Jaune").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
                        loose = true;
                    break;
                default:
                    if (GameObject.Find("QG_Bleu").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
                        loose = true;
                    break;
            }
        }

        void IsWin()
        {
            bool RedLoose = (GameObject.Find("QG_Rouge").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured);
            bool BlueLoose = (GameObject.Find("QG_Bleu").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured);
            bool GreenLoose = (GameObject.Find("QG_Vert").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured);
            bool YellowLoose = (GameObject.Find("QG_Jaune").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured);


            switch (tag)
            {
                case "Red":
                    if (BlueLoose && GreenLoose & YellowLoose && !RedLoose)
                        Win();
                    break;
                case "Green":
                    if (BlueLoose && RedLoose && YellowLoose && !GreenLoose)
                        Win();
                    break;
                case "Yellow":
                    if (BlueLoose && RedLoose && GreenLoose && !YellowLoose)
                        Win();
                    break;
                default:
                    if (RedLoose && GreenLoose && YellowLoose && !BlueLoose)
                        Win();
                    break;
            }

            if (BlueLoose && GreenLoose & YellowLoose && !RedLoose)
                Leave();
            if (BlueLoose && RedLoose && YellowLoose && !GreenLoose)
                Leave();
            if (BlueLoose && RedLoose && GreenLoose && !YellowLoose)
                Leave();
            if (RedLoose && GreenLoose && YellowLoose && !BlueLoose)
                Leave();
        }

        void Win()
        {
            Interface.SetActive(false);
            Victoire.SetActive(true);

            if (cooldown > 0)
                cooldown--;
            else
            {
                Victoire.SetActive(false);
            }

           
        }

        void Leave()
        {
            if (compteur > 0)
                compteur--;
            else
                SceneManager.LoadScene("Luncher");
        }
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            cooldown = 300;
            compteur = 1000;
            Reset();
            InvokeRepeating("AddIncome", 1f, 0.05f);
            this.loose = false;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    this.tag = "Red";
                    break;
                case PunTeams.Team.yellow:
                    this.tag = "Yellow";
                    break;
                case PunTeams.Team.green:
                    this.tag = "Green";
                    break;
                default:
                    this.tag = "Blue";
                    break;
            }
            ActualiseIncomes();

            ResetMap();

            #region Text update

            pOr.text = ((int) or).ToString();
            pFer.text = ((int) fer).ToString();
            pOrIncome.text = "+" + incomeOr.ToString() + "/s";
            pFerIncome.text = "+" + incomeFer.ToString() + "/s";

            #endregion
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("o"))
            {
                or = 9999;
            }
            if (Input.GetKey("p"))
            {
                fer = 9999;
            }


            IsLoosed();

            if (!loose)
            {
                gameObject.tag = this.tag;
                ActualiseIncomes();
                cooldown = 300;
                GameOver.SetActive(false);
                Interface.SetActive(true);



                #region Text update

                pOr.text = ((int)or).ToString();
                pFer.text = ((int)fer).ToString();
                pOrIncome.text = "+" + incomeOr.ToString() + "/s";
                pFerIncome.text = "+" + incomeFer.ToString() + "/s";

                #endregion
            }
            else if(loose)
            {
                Interface.SetActive(false);
                GameOver.SetActive(true);

                if (cooldown > 0)
                    cooldown--;
                else
                {
                    GameOver.SetActive(false);
                }
                
            }


            #region clean perdant

            if (GameObject.Find("QG_Rouge").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("Red"))
                    i.tag = "Neutral";
            }
            if (GameObject.Find("QG_Bleu").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("Blue"))
                    i.tag = "Neutral";
            }
            if (GameObject.Find("QG_Jaune").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("Yellow"))
                    i.tag = "Neutral";
            }
            if (GameObject.Find("QG_Vert").GetComponent<BuildingScript>().type == Building.BuildingScript.BuildingType.QG_Captured)
            {
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("Green"))
                    i.tag = "Neutral";
            }

            #endregion
        }
    }
}
