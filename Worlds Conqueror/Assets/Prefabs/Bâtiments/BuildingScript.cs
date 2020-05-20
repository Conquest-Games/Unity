using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

namespace Building
{

    public class BuildingScript : MonoBehaviour
    {

        #region DataEnums

        public enum BuildingType
        {
            QG, QG_Captured, Ville, MineDeFer, Caserne, TourDarcher, None
        }

        #endregion

        #region DataLists

        public BuildingType type;
        public int initialLevel;
        public GameObject CeBatiment;
        public GameObject Level1;
        public GameObject Level2;
        public GameObject Level3;
        public GameObject UpgradeBouton;
        public GameObject TextLevel;
        public GameObject HpLevel;

        protected int[] orIncomeList = { 1, 2, 3 };
        protected int[] orQGIncomeList = { 4, 8, 12 };
        protected int[] ferIncomeList = { 1, 2, 3 };
        protected int[] dommageList = { 10, 15, 25 };
        protected int[] dommageQGList = { 20, 30, 50 };

        protected int[] healsListVille = { 200, 400, 800 };
        protected int[] healsListMineDeFer = { 250, 500, 1000 };
        protected int[] healsListTourDarcher = { 150, 300, 600 };
        protected int[] healsListCaserne = { 500, 750, 1000 };
        protected int[] healsListQG = { 1000, 2000, 5000 };
        protected int[] healsListQG_Captured = { 500, 1000, 1500 };

        protected float[] RangeTourDarcher = { 15f, 30f, 45f };

        protected int[] upgradePrice = { 200, 500 };

        #endregion

        #region Initialisateur

        public int orIncome = 0;
        public int ferIncome = 0;
        public bool spawnUnit = false;
        public int actualLevel = 0;
        public int maxHeals = 0;
        public int maxNeutralHeals = 0;
        public int heals = 0;
        public int dommage = 0;
        public float range = 0f;

        #endregion

        #region getters

        public BuildingType Type
        {
            get => type;
        }


        public int OrIncome
        {
            get => orIncome;
        }

        public int FerIncome
        {
            get => ferIncome;
        }

        public bool SpawnUnit
        {
            get => spawnUnit;
        }

        public int Dommage
        {
            get => dommage;
        }

        public int ActualLevel
        {
            get => actualLevel;
        }

        public int Heals
        {
            get => heals;
        }

        #endregion

        private void UpdateStats()
        {
            switch (type)
            {
                case BuildingType.Ville:

                    this.orIncome = orIncomeList[ActualLevel];
                    this.maxHeals = healsListVille[ActualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    break;


                case BuildingType.MineDeFer:

                    this.ferIncome = ferIncomeList[ActualLevel];
                    this.maxHeals = healsListMineDeFer[ActualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    break;

                case BuildingType.Caserne:
                    this.maxHeals = healsListCaserne[actualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    break;

                case BuildingType.TourDarcher:

                    this.dommage = dommageList[ActualLevel];
                    this.maxHeals = healsListTourDarcher[ActualLevel];
                    this.range = RangeTourDarcher[ActualLevel];
                    this.dommage = dommageList[ActualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    break;

                case BuildingType.QG:

                case BuildingType.QG_Captured:

                    this.spawnUnit = true;
                    this.orIncome = orQGIncomeList[ActualLevel];
                    this.dommage = dommageQGList[ActualLevel];
                    break;

                default:

                    break;
            }

            if (CeBatiment.tag == "Neutral" && heals >= maxNeutralHeals)
                heals = maxNeutralHeals;
        }

        public void Initiate()
        {
            this.actualLevel = initialLevel;

            this.ferIncome = 0;
            this.orIncome = 0;
            this.spawnUnit = false;

            switch (type)
            {
                case BuildingType.Ville:

                    this.orIncome = orIncomeList[ActualLevel];
                    this.maxHeals = healsListVille[ActualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    break;


                case BuildingType.MineDeFer:

                    this.ferIncome = ferIncomeList[ActualLevel];
                    this.maxHeals = healsListMineDeFer[ActualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    break;

                case BuildingType.Caserne:

                    this.spawnUnit = true;
                    this.maxHeals = healsListCaserne[actualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    break;

                case BuildingType.TourDarcher:

                    this.maxHeals = healsListCaserne[actualLevel];
                    this.maxNeutralHeals = maxHeals / 2;
                    this.dommage = dommageList[ActualLevel];
                    break;

                case BuildingType.QG:

                case BuildingType.QG_Captured:

                    this.spawnUnit = true;
                    this.orIncome = orQGIncomeList[ActualLevel];
                    this.dommage = dommageQGList[ActualLevel];
                    break;

                default:

                    break;

            }

            if (gameObject.tag == "Neutral")
                heals = maxNeutralHeals;
            else
                 this.heals = maxHeals;

            return;
        }

        private void ActualiseLevel()
        {
            if (CeBatiment.tag == "Neutral")
                actualLevel = initialLevel;
            switch (actualLevel)
            {
                case 0:
                    Level1.SetActive(true);
                    Level2.SetActive(false);
                    Level3.SetActive(false);
                    break;
                case 1:
                    Level1.SetActive(false);
                    Level2.SetActive(true);
                    Level3.SetActive(false);
                    break;
                default:
                    Level1.SetActive(false);
                    Level2.SetActive(false);
                    Level3.SetActive(true);
                    break;
            }
        }

        private void UpdateText()
        {
            switch (CeBatiment.tag)
            {
                case "Red":
                    {
                        TextLevel.GetComponent<TextMesh>().color = Color.red;
                        HpLevel.GetComponent<TextMesh>().color = Color.red;
                        break;
                    }
                case "Yellow":
                    {
                        TextLevel.GetComponent<TextMesh>().color = Color.yellow;
                        HpLevel.GetComponent<TextMesh>().color = Color.yellow;
                        break;
                    }
                case "Green":
                    {
                        TextLevel.GetComponent<TextMesh>().color = Color.green;
                        HpLevel.GetComponent<TextMesh>().color = Color.green;
                        break;
                    }
                case "Blue":
                    {
                        TextLevel.GetComponent<TextMesh>().color = Color.cyan;
                        HpLevel.GetComponent<TextMesh>().color = Color.cyan;
                        break;
                    }
                default:
                    {
                        TextLevel.GetComponent<TextMesh>().color = Color.white;
                        HpLevel.GetComponent<TextMesh>().color = Color.white;
                        break;
                    }
            }

            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    if (CeBatiment.tag == "Red")
                        UpgradeBouton.SetActive(true);
                    else
                        UpgradeBouton.SetActive(false);
                    break;
                case PunTeams.Team.yellow:
                    if (CeBatiment.tag == "Yellow")
                        UpgradeBouton.SetActive(true);
                    else
                        UpgradeBouton.SetActive(false);
                    break;
                case PunTeams.Team.green:
                    if (CeBatiment.tag == "Green")
                        UpgradeBouton.SetActive(true);
                    else
                        UpgradeBouton.SetActive(false);
                    break;
                default:
                    if (CeBatiment.tag == "Blue")
                        UpgradeBouton.SetActive(true);
                    else
                        UpgradeBouton.SetActive(false);
                    break;
            }

            TextLevel.GetComponent<TextMesh>().text = "Lvl: " + (actualLevel + 1).ToString();

            if (CeBatiment.tag == "Neutral")
                HpLevel.GetComponent<TextMesh>().text = heals.ToString() + " / " + maxNeutralHeals.ToString();
            else
                HpLevel.GetComponent<TextMesh>().text = heals.ToString() + " / " + maxHeals.ToString();
        }

        private void HealBuilding()
        {
            if (CeBatiment.tag == "Neutral")
                return;
            if (heals >= maxHeals)
                this.heals = maxHeals;
            else
                this.heals++;
        }

        public void upgradeBuilding()
        {
            if (actualLevel >= 2)
                return;
            (bool achete, string erreur) = Joueur.Player.Cout(upgradePrice[actualLevel]);
            if (achete)
                actualLevel++;
            UpdateStats();
            heals = maxHeals;
        }

        // Start is called before the first frame update
        void Start()
        {
            Initiate();
            if (actualLevel > 2)
                actualLevel = 2;
            else if (actualLevel < 0)
                actualLevel = 0;
            ActualiseLevel();
            UpdateText();
            InvokeRepeating("HealBuilding", 1f, 1f);
            if (CeBatiment.tag == "Neutral")
            {
                heals = maxNeutralHeals;
            }
            UpdateStats();
        }

        // Update is called once per frame
        void Update()
        {
            if (actualLevel > 2)
                actualLevel = 2;
            else if (actualLevel < 0)
                actualLevel = 0;

            ActualiseLevel();
            UpdateText();
        }
    }
}