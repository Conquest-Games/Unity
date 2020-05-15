using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;

namespace WorldConqueror
{
    public class Spawner : MonoBehaviour
    {
        #region Déclaration des variables

        private int InfantryLevel = UnitStats.GetLevel(UnitStats.SolderType.Infantry);
        private int ArcheryLevel = UnitStats.GetLevel(UnitStats.SolderType.Archery);
        private int CavaleryLevel = UnitStats.GetLevel(UnitStats.SolderType.Cavalery);
        private int SiegeWeaponLevel = UnitStats.GetLevel(UnitStats.SolderType.SiegeWeapon);

        public GameObject InfantryLevel0;
        public GameObject InfantryLevel1;
        public GameObject InfantryLevel2;
        public GameObject InfantryLevel3;

        public GameObject ArcheryLevel0;
        public GameObject ArcheryLevel1;
        public GameObject ArcheryLevel2;
        public GameObject ArcheryLevel3;

        public GameObject CavaleryLevel0;
        public GameObject CavaleryLevel1;
        public GameObject CavaleryLevel2;
        public GameObject CavaleryLevel3;

        public GameObject SiegeWeaponLevel0;
        public GameObject SiegeWeaponLevel1;
        public GameObject SiegeWeaponLevel2;
        public GameObject SiegeWeaponLevel3;

        private GameObject Infantry;
        private GameObject Archery;
        private GameObject Cavalery;
        private GameObject SiegeWeapon;

        public void ActualiseLevel()
        {
            switch(InfantryLevel)
            {
                case (0):
                    Infantry = InfantryLevel0;
                    break;
                case (1):
                    Infantry = InfantryLevel1;
                    break;
                case (2):
                    Infantry = InfantryLevel2;
                    break;
                case (3):
                    Infantry = InfantryLevel3;
                    break;
                default:
                    break;
            }
            switch (ArcheryLevel)
            {
                case (0):
                    Archery = ArcheryLevel0;
                    break;
                case (1):
                    Archery = ArcheryLevel1;
                    break;
                case (2):
                    Archery = ArcheryLevel2;
                    break;
                case (3):
                    Archery = ArcheryLevel3;
                    break;
                default:
                    break;
            }
            switch (CavaleryLevel)
            {
                case (0):
                    Cavalery = CavaleryLevel0;
                    break;
                case (1):
                    Cavalery = CavaleryLevel1;
                    break;
                case (2):
                    Cavalery = CavaleryLevel2;
                    break;
                case (3):
                    Cavalery = CavaleryLevel3;
                    break;
                default:
                    break;
            }
            switch (SiegeWeaponLevel)
            {
                case (0):
                    SiegeWeapon = SiegeWeaponLevel0;
                    break;
                case (1):
                    SiegeWeapon = SiegeWeaponLevel1;
                    break;
                case (2):
                    SiegeWeapon = SiegeWeaponLevel2;
                    break;
                case (3):
                    SiegeWeapon = SiegeWeaponLevel3;
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Infantry

        public void SpawnInfantryLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Infantry));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Infantry.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Infantry.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToGreen>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Infantry.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Infantry.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnInfantryRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Infantry));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                {
                    Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                    GameObject TheOner = PhotonNetwork.Instantiate(Infantry.name, spawnPosr, Quaternion.identity);
                    TheOner.AddComponent<RedToBlue>();
                    TheOner.tag = "Red";
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                    GameObject TheOney = PhotonNetwork.Instantiate(Infantry.name, spawnPosy, Quaternion.identity);
                    TheOney.AddComponent<YellowToRed>();
                    TheOney.tag = "Yellow";
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                    GameObject TheOneg = PhotonNetwork.Instantiate(Infantry.name, spawnPosg, Quaternion.identity);
                    TheOneg.AddComponent<GreenToYellow>();
                    TheOneg.tag = "Green";
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Infantry.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    TheOne.tag = "Blue";
                    break;
            }
        }
        
        public void SpawnInfantryForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Infantry));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                {
                    Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                    GameObject TheOner = PhotonNetwork.Instantiate(Infantry.name, spawnPosr, Quaternion.identity);
                    TheOner.AddComponent<RedToGreen>();
                    TheOner.tag = "Red";
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                    GameObject TheOney = PhotonNetwork.Instantiate(Infantry.name, spawnPosy, Quaternion.identity);
                    TheOney.AddComponent<YellowToBlue>();
                    TheOney.tag = "Yellow";
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                    GameObject TheOneg = PhotonNetwork.Instantiate(Infantry.name, spawnPosg, Quaternion.identity);
                    TheOneg.AddComponent<GreenToRed>();
                    TheOneg.tag = "Green";
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Infantry.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        #endregion

        #region Archery

        public void SpawnArcheryLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Archery));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Archery.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Archery.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToGreen>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Archery.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Archery.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnArcheryRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Archery));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Archery.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToBlue>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Archery.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Archery.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Archery.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnArcheryForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Archery));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Archery.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Archery.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Archery.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Archery.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        #endregion

        #region Cavalery

        public void SpawnCavaleryLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Cavalery));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Cavalery.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Cavalery.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToGreen>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Cavalery.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Cavalery.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnCavaleryRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Cavalery));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Cavalery.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToBlue>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Cavalery.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Cavalery.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Cavalery.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnCavaleryForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Cavalery));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Cavalery.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Cavalery.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Cavalery.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Cavalery.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        #endregion

        #region SiegeWeapon

        public void SpawnSiegeWeaponLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.SiegeWeapon));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToGreen>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnSiegeWeaponRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.SiegeWeapon));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToBlue>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnSiegeWeaponForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.SiegeWeapon));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(SiegeWeapon.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        #endregion

        void Start()
        {
            InfantryLevel = UnitStats.GetLevel(UnitStats.SolderType.Infantry);
            ArcheryLevel = UnitStats.GetLevel(UnitStats.SolderType.Archery);
            CavaleryLevel = UnitStats.GetLevel(UnitStats.SolderType.Cavalery);
            SiegeWeaponLevel = UnitStats.GetLevel(UnitStats.SolderType.SiegeWeapon);

            ActualiseLevel();
        }

        void Update()
        {
            InfantryLevel = UnitStats.GetLevel(UnitStats.SolderType.Infantry);
            ArcheryLevel = UnitStats.GetLevel(UnitStats.SolderType.Archery);
            CavaleryLevel = UnitStats.GetLevel(UnitStats.SolderType.Cavalery);
            SiegeWeaponLevel = UnitStats.GetLevel(UnitStats.SolderType.SiegeWeapon);

            ActualiseLevel();
        }
    }
}