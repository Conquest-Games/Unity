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
        public GameObject unit;
        

        public void SpawnRight()
        {
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                {
                    Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                    GameObject TheOner = PhotonNetwork.Instantiate(unit.name, spawnPosr, Quaternion.identity);
                    TheOner.AddComponent<RedToBlue>();
                    TheOner.tag = "Red";
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                    GameObject TheOney = PhotonNetwork.Instantiate(unit.name, spawnPosy, Quaternion.identity);
                    TheOney.AddComponent<YellowToRed>();
                    TheOney.tag = "Yellow";
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                    GameObject TheOneg = PhotonNetwork.Instantiate(unit.name, spawnPosg, Quaternion.identity);
                    TheOneg.AddComponent<GreenToYellow>();
                    TheOneg.tag = "Green";
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(unit.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    TheOne.tag = "Blue";
                    break;
            }
        }
        
        public void SpawnLeft()
        {
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                {
                    Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                    GameObject TheOner = PhotonNetwork.Instantiate(unit.name, spawnPosr, Quaternion.identity);
                    TheOner.AddComponent<RedToYellow>();
                    TheOner.tag = "Red";
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                    GameObject TheOney = PhotonNetwork.Instantiate(unit.name, spawnPosy, Quaternion.identity);
                    TheOney.AddComponent<YellowToGreen>();
                    TheOney.tag = "Yellow";
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                    GameObject TheOneg = PhotonNetwork.Instantiate(unit.name, spawnPosg, Quaternion.identity);
                    TheOneg.AddComponent<GreenToBlue>();
                    TheOneg.tag = "Green";
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(unit.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    TheOne.tag = "Blue";
                    break;
            }
        }
        
        public void SpawnForward()
        {
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                {
                    Vector3 spawnPosr = new Vector3(-138.4f, 0, 150);
                    GameObject TheOner = PhotonNetwork.Instantiate(unit.name, spawnPosr, Quaternion.identity);
                    TheOner.AddComponent<RedToGreen>();
                    TheOner.tag = "Red";
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 0, 150);
                    GameObject TheOney = PhotonNetwork.Instantiate(unit.name, spawnPosy, Quaternion.identity);
                    TheOney.AddComponent<YellowToBlue>();
                    TheOney.tag = "Yellow";
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 0, -150);
                    GameObject TheOneg = PhotonNetwork.Instantiate(unit.name, spawnPosg, Quaternion.identity);
                    TheOneg.AddComponent<GreenToRed>();
                    TheOneg.tag = "Green";
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 0, -150);
                    GameObject TheOne = PhotonNetwork.Instantiate(unit.name, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToYellow>();
                    TheOne.tag = "Blue";
                    break;
            }
        }
    }
}