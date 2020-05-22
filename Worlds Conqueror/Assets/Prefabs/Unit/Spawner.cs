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

        public GameObject Infantry;
        public GameObject Archery;
        public GameObject Cavalery;
        public GameObject SiegeWeapon;
        public GameObject Ninja;

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

        #region Ninja

        public void SpawnNinjaLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Ninja));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Ninja.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Ninja.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToGreen>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Ninja.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Ninja.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnNinjaRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Ninja));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Ninja.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToBlue>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Ninja.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Ninja.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Ninja.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        public void SpawnNinjaForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Ninja));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(Ninja.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        TheOner.tag = "Red";
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(Ninja.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        TheOney.tag = "Yellow";
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(Ninja.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        TheOneg.tag = "Green";
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(Ninja.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    TheOne.tag = "Blue";
                    break;
            }
        }

        #endregion
    }
}