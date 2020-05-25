using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;
using Joueur;

namespace WorldConqueror
{
    public class Spawner : MonoBehaviour
    {
        #region Déclaration des variables

        public GameObject InfantryRed;
        public GameObject ArcheryRed;
        public GameObject CavaleryRed;
        public GameObject SiegeWeaponRed;
        public GameObject NinjaRed;

        public GameObject InfantryBlue;
        public GameObject ArcheryBlue;
        public GameObject CavaleryBlue;
        public GameObject SiegeWeaponBlue;
        public GameObject NinjaBlue;

        public GameObject InfantryYellow;
        public GameObject ArcheryYellow;
        public GameObject CavaleryYellow;
        public GameObject SiegeWeaponYellow;
        public GameObject NinjaYellow;

        public GameObject InfantryGreen;
        public GameObject ArcheryGreen;
        public GameObject CavaleryGreen;
        public GameObject SiegeWeaponGreen;
        public GameObject NinjaGreen;

        #endregion

        #region Infantry

        public void SpawnInfantryLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Infantry, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Jaune").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(InfantryRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Yellow")
                        {
                            spawnPosy = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Vert").tag == "Yellow")
                                spawnPosy = new Vector3(138.4f, 0, -150);
                        }
                        GameObject TheOney = PhotonNetwork.Instantiate(InfantryYellow.name, spawnPosy, Quaternion.identity);
                        if (spawnPosy.z == 0)
                        {
                            TheOney.transform.SetPositionAndRotation(
                                TheOney.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOney.AddComponent<YellowToGreen>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Bleu").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(InfantryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("Caserne Bleu/Rouge").tag == "Blue")
                    {
                        spawnPos = new Vector3(-138.4f, 0, 0);
                        if (GameObject.Find("QG_Rouge").tag == "Blue")
                            spawnPos = new Vector3(-138.4f, 0, 150);
                    }
                    
                    GameObject TheOne = PhotonNetwork.Instantiate(InfantryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    break;
            }
        }

        public void SpawnInfantryRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Infantry, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("Caserne Bleu/Rouge").tag == "Red")
                        {
                            spawnPosr = new Vector3(-138.4f, 0, 0);
                            if (GameObject.Find("QG_Bleu").tag == "Red")
                                spawnPosr = new Vector3(-138.4f, 0, -150);
                        }
                        GameObject TheOner = PhotonNetwork.Instantiate(
                            InfantryRed.name, spawnPosr, Quaternion.identity);
                        if (spawnPosr.z == 0)
                        {
                            TheOner.transform.SetPositionAndRotation(
                                TheOner.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOner.AddComponent<RedToBlue>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Rouge").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(InfantryYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Green")
                        {
                            spawnPosg = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Jaune").tag == "Green")
                                spawnPosg = new Vector3(138.4f, 0, 150);
                        }
                        GameObject TheOneg = PhotonNetwork.Instantiate(InfantryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Vert").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(InfantryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    break;
            }
        }

        public void SpawnInfantryForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Infantry, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Vert").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, -150);
                        GameObject TheOner = PhotonNetwork.Instantiate(InfantryRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Bleu").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, -150);
                        GameObject TheOney = PhotonNetwork.Instantiate(InfantryYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Rouge").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, 150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(InfantryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Jaune").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, 150);
                    GameObject TheOne = PhotonNetwork.Instantiate(InfantryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    break;
            }
        }

        #endregion

        #region Archery

        public void SpawnArcheryLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Archery, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Jaune").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(ArcheryRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Yellow")
                        {
                            spawnPosy = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Vert").tag == "Yellow")
                                spawnPosy = new Vector3(138.4f, 0, -150);
                        }
                        GameObject TheOney = PhotonNetwork.Instantiate(ArcheryYellow.name, spawnPosy, Quaternion.identity);
                        if (spawnPosy.z == 0)
                        {
                            TheOney.transform.SetPositionAndRotation(
                                TheOney.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOney.AddComponent<YellowToGreen>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Bleu").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(ArcheryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("Caserne Bleu/Rouge").tag == "Blue")
                    {
                        spawnPos = new Vector3(-138.4f, 0, 0);
                        if (GameObject.Find("QG_Rouge").tag == "Blue")
                            spawnPos = new Vector3(-138.4f, 0, 150);
                    }
                    GameObject TheOne = PhotonNetwork.Instantiate(ArcheryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    break;
            }
        }

        public void SpawnArcheryRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Archery, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("Caserne Bleu/Rouge").tag == "Red")
                        {
                            spawnPosr = new Vector3(-138.4f, 0, 0);
                            if (GameObject.Find("QG_Bleu").tag == "Red")
                                spawnPosr = new Vector3(-138.4f, 0, -150);
                        }
                        GameObject TheOner = PhotonNetwork.Instantiate(ArcheryRed.name, spawnPosr, Quaternion.identity);
                        if (spawnPosr.z == 0)
                        {
                            TheOner.transform.SetPositionAndRotation(
                                TheOner.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOner.AddComponent<RedToBlue>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Rouge").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(ArcheryYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Green")
                        {
                            spawnPosg = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Jaune").tag == "Green")
                                spawnPosg = new Vector3(138.4f, 0, 150);
                        }
                        GameObject TheOneg = PhotonNetwork.Instantiate(ArcheryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Vert").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(ArcheryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    break;
            }
        }

        public void SpawnArcheryForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Archery, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Vert").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, -150);
                        GameObject TheOner = PhotonNetwork.Instantiate(ArcheryRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Bleu").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, -150);
                        GameObject TheOney = PhotonNetwork.Instantiate(ArcheryYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Rouge").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, 150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(ArcheryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Jaune").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, 150);
                    GameObject TheOne = PhotonNetwork.Instantiate(ArcheryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    break;
            }
        }

        #endregion

        #region Cavalery

        public void SpawnCavaleryLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Cavalery, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Jaune").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(CavaleryRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Yellow")
                        {
                            spawnPosy = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Vert").tag == "Yellow")
                                spawnPosy = new Vector3(138.4f, 0, -150);
                        }
                        GameObject TheOney = PhotonNetwork.Instantiate(CavaleryYellow.name, spawnPosy, Quaternion.identity);
                        if (spawnPosy.z == 0)
                        {
                            TheOney.transform.SetPositionAndRotation(
                                TheOney.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOney.AddComponent<YellowToGreen>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Bleu").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(CavaleryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("Caserne Bleu/Rouge").tag == "Blue")
                    {
                        spawnPos = new Vector3(-138.4f, 0, 0);
                        if (GameObject.Find("QG_Rouge").tag == "Blue")
                            spawnPos = new Vector3(-138.4f, 0, 150);
                    }
                    GameObject TheOne = PhotonNetwork.Instantiate(CavaleryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    break;
            }
        }

        public void SpawnCavaleryRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Cavalery, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("Caserne Bleu/Rouge").tag == "Red")
                        {
                            spawnPosr = new Vector3(-138.4f, 0, 0);
                            if (GameObject.Find("QG_Bleu").tag == "Red")
                                spawnPosr = new Vector3(-138.4f, 0, -150);
                        }
                        GameObject TheOner = PhotonNetwork.Instantiate(CavaleryRed.name, spawnPosr, Quaternion.identity);
                        if (spawnPosr.z == 0)
                        {
                            TheOner.transform.SetPositionAndRotation(
                                TheOner.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOner.AddComponent<RedToBlue>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Rouge").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(CavaleryYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Green")
                        {
                            spawnPosg = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Jaune").tag == "Green")
                                spawnPosg = new Vector3(138.4f, 0, 150);
                        }
                        GameObject TheOneg = PhotonNetwork.Instantiate(CavaleryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Vert").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(CavaleryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    break;
            }
        }

        public void SpawnCavaleryForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Cavalery, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Vert").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, -150);
                        GameObject TheOner = PhotonNetwork.Instantiate(CavaleryRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Bleu").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, -150);
                        GameObject TheOney = PhotonNetwork.Instantiate(CavaleryYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Rouge").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, 150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(CavaleryGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Jaune").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, 150);
                    GameObject TheOne = PhotonNetwork.Instantiate(CavaleryBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    break;
            }
        }

        #endregion

        #region SiegeWeapon

        public void SpawnSiegeWeaponLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.SiegeWeapon, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Jaune").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(SiegeWeaponRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Yellow")
                        {
                            spawnPosy = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Vert").tag == "Yellow")
                                spawnPosy = new Vector3(138.4f, 0, -150);
                        }
                        GameObject TheOney = PhotonNetwork.Instantiate(SiegeWeaponYellow.name, spawnPosy, Quaternion.identity);
                        if (spawnPosy.z == 0)
                        {
                            TheOney.transform.SetPositionAndRotation(
                                TheOney.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOney.AddComponent<YellowToGreen>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Bleu").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(SiegeWeaponGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("Caserne Bleu/Rouge").tag == "Blue")
                    {
                        spawnPos = new Vector3(-138.4f, 0, 0);
                        if (GameObject.Find("QG_Rouge").tag == "Blue")
                            spawnPos = new Vector3(-138.4f, 0, 150);
                    }
                    GameObject TheOne = PhotonNetwork.Instantiate(SiegeWeaponBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    break;
            }
        }

        public void SpawnSiegeWeaponRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.SiegeWeapon, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("Caserne Bleu/Rouge").tag == "Red")
                        {
                            spawnPosr = new Vector3(-138.4f, 0, 0);
                            if (GameObject.Find("QG_Bleu").tag == "Red")
                                spawnPosr = new Vector3(-138.4f, 0, -150);
                        }
                        GameObject TheOner = PhotonNetwork.Instantiate(SiegeWeaponRed.name, spawnPosr, Quaternion.identity);
                        if (spawnPosr.z == 0)
                        {
                            TheOner.transform.SetPositionAndRotation(
                                TheOner.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOner.AddComponent<RedToBlue>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Rouge").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(SiegeWeaponYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Green")
                        {
                            spawnPosg = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Jaune").tag == "Green")
                                spawnPosg = new Vector3(138.4f, 0, 150);
                        }
                        GameObject TheOneg = PhotonNetwork.Instantiate(SiegeWeaponGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Vert").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(SiegeWeaponBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    break;
            }
        }

        public void SpawnSiegeWeaponForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.SiegeWeapon, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Vert").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, -150);
                        GameObject TheOner = PhotonNetwork.Instantiate(SiegeWeaponRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Bleu").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, -150);
                        GameObject TheOney = PhotonNetwork.Instantiate(SiegeWeaponYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Rouge").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, 150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(SiegeWeaponGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Jaune").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, 150);
                    GameObject TheOne = PhotonNetwork.Instantiate(SiegeWeaponBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    break;
            }
        }

        #endregion

        #region Ninja

        public void SpawnNinjaLeft()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Ninja, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Jaune").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, 150);
                        GameObject TheOner = PhotonNetwork.Instantiate(NinjaRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToYellow>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Yellow")
                        {
                            spawnPosy = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Vert").tag == "Yellow")
                                spawnPosy = new Vector3(138.4f, 0, -150);
                        }
                        GameObject TheOney = PhotonNetwork.Instantiate(NinjaYellow.name, spawnPosy, Quaternion.identity);
                        
                        if (spawnPosy.z == 0)
                        {
                            TheOney.transform.SetPositionAndRotation(
                                TheOney.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOney.AddComponent<YellowToGreen>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Bleu").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, -150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(NinjaGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToBlue>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("Caserne Bleu/Rouge").tag == "Blue")
                    {
                        spawnPos = new Vector3(-138.4f, 0, 0);
                        if (GameObject.Find("QG_Rouge").tag == "Blue")
                            spawnPos = new Vector3(-138.4f, 0, 150);
                    }
                    GameObject TheOne = PhotonNetwork.Instantiate(NinjaBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    break;
            }
        }

        public void SpawnNinjaRight()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Ninja, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("Caserne Bleu/Rouge").tag == "Red")
                        {
                            spawnPosr = new Vector3(-138.4f, 0, 0);
                            if (GameObject.Find("QG_Bleu").tag == "Red")
                                spawnPosr = new Vector3(-138.4f, 0, -150);
                        }
                        GameObject TheOner = PhotonNetwork.Instantiate(NinjaRed.name, spawnPosr, Quaternion.identity);
                        if (spawnPosr.z == 0)
                        {
                            TheOner.transform.SetPositionAndRotation(
                                TheOner.transform.position, Quaternion.Euler(0, 180, 0));
                        }
                        TheOner.AddComponent<RedToBlue>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Rouge").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, 150);
                        GameObject TheOney = PhotonNetwork.Instantiate(NinjaYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToRed>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("Caserne Jaune/vert").tag == "Green")
                        {
                            spawnPosg = new Vector3(138.4f, 0, 0);
                            if (GameObject.Find("QG_Jaune").tag == "Green")
                                spawnPosg = new Vector3(138.4f, 0, 150);
                        }
                        GameObject TheOneg = PhotonNetwork.Instantiate(NinjaGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToYellow>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Vert").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(NinjaBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    break;
            }
        }

        public void SpawnNinjaForward()
        {
            (bool achete, string erreur) = Joueur.Player.Cout(UnitStats.GetPrice(UnitStats.SolderType.Ninja, GameObject.Find("Player").GetComponent<Player>().tag));
            if (!achete)
                return;
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                    {
                        Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                        if (GameObject.Find("QG_Vert").tag == "Red")
                            spawnPosr = new Vector3(138.4f, 0, -150);
                        GameObject TheOner = PhotonNetwork.Instantiate(NinjaRed.name, spawnPosr, Quaternion.identity);
                        TheOner.AddComponent<RedToGreen>();
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                        if (GameObject.Find("QG_Bleu").tag == "Yellow")
                            spawnPosy = new Vector3(-138.4f, 0, -150);
                        GameObject TheOney = PhotonNetwork.Instantiate(NinjaYellow.name, spawnPosy, Quaternion.identity);
                        TheOney.AddComponent<YellowToBlue>();
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                        if (GameObject.Find("QG_Rouge").tag == "Green")
                            spawnPosg = new Vector3(-138.4f, 0, 150);
                        GameObject TheOneg = PhotonNetwork.Instantiate(NinjaGreen.name, spawnPosg, Quaternion.identity);
                        TheOneg.AddComponent<GreenToRed>();
                        break;
                    }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    if (GameObject.Find("QG_Jaune").tag == "Blue")
                        spawnPos = new Vector3(138.4f, 0, 150);
                    GameObject TheOne = PhotonNetwork.Instantiate(NinjaBlue.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    break;
            }
        }

        #endregion
    }
}