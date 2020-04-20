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
                    Vector3 spawnPosr = new Vector3(-138.4f, 2, 150);
                    GameObject TheOner = Instantiate(unit, spawnPosr, Quaternion.identity);
                    TheOner.AddComponent<RedToBlue>();
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 2, 150);
                    GameObject TheOney = Instantiate(unit, spawnPosy, Quaternion.identity);
                    TheOney.AddComponent<YellowToRed>();
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 2, -150);
                    GameObject TheOneg = Instantiate(unit, spawnPosg, Quaternion.identity);
                    TheOneg.AddComponent<GreenToYellow>();
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 2, -150);
                    GameObject TheOne = Instantiate(unit, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToGreen>();
                    break;
            }
        }
        
        public void SpawnLeft()
        {
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                {
                    Vector3 spawnPosr = new Vector3(-138.4f, 2, 150);
                    GameObject TheOner = Instantiate(unit, spawnPosr, Quaternion.identity);
                    TheOner.AddComponent<RedToYellow>();
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 2, 150);
                    GameObject TheOney = Instantiate(unit, spawnPosy, Quaternion.identity);
                    TheOney.AddComponent<YellowToGreen>();
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 2, -150);
                    GameObject TheOneg = Instantiate(unit, spawnPosg, Quaternion.identity);
                    TheOneg.AddComponent<GreenToBlue>();
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 2, -150);
                    GameObject TheOne = Instantiate(unit, spawnPos, Quaternion.identity);
                    TheOne.AddComponent<BlueToRed>();
                    break;
            }
        }
        
        public void SpawnForward()
        {
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.red:
                {
                    Vector3 spawnPosr = new Vector3(-138.4f, 2, 150);
                    GameObject TheOner = Instantiate(unit, spawnPosr, Quaternion.identity);
                    //TheOner.AddComponent<RedToGreen>();
                    break;
                }
                case PunTeams.Team.yellow:
                {
                    Vector3 spawnPosy = new Vector3(138.4f, 2, 150);
                    GameObject TheOney = Instantiate(unit, spawnPosy, Quaternion.identity);
                    //TheOney.AddComponent<YellowToBlue>();
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 spawnPosg = new Vector3(138.4f, 2, -150);
                    GameObject TheOneg = Instantiate(unit, spawnPosg, Quaternion.identity);
                    //TheOneg.AddComponent<GreenToRed>();
                    break;
                }
                default:
                    Vector3 spawnPos = new Vector3(-138.4f, 2, -150);
                    GameObject TheOne = Instantiate(unit, spawnPos, Quaternion.identity);
                    //TheOne.AddComponent<BlueToYellow>();
                    break;
            }
        }
    }
}