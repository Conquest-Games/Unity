using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;

namespace GameControl
{
    public class GameConst : MonoBehaviour
    {
        List<PunTeams.Team> color = new List<PunTeams.Team>
            {PunTeams.Team.green, PunTeams.Team.yellow, PunTeams.Team.red, PunTeams.Team.blue};

        // Start is called before the first frame update
        void Start()
        {
            Photon.Realtime.Player[] playerListOthers = PhotonNetwork.PlayerListOthers;
            foreach (var player in playerListOthers)
            {
                if (player.GetTeam() == PunTeams.Team.blue)
                    color.Remove(PunTeams.Team.blue);
                else if (player.GetTeam() == PunTeams.Team.red)
                    color.Remove(PunTeams.Team.red);
                else if (player.GetTeam() == PunTeams.Team.green)
                    color.Remove(PunTeams.Team.green);
            }

            PhotonNetwork.LocalPlayer.SetTeam(color[color.Count - 1]);
            
            switch (PhotonNetwork.LocalPlayer.GetTeam())
            {
                case PunTeams.Team.yellow:
                {
                    Vector3 pos = new Vector3(170f, 40f, 180f);
                    Camera.main.transform.SetPositionAndRotation(pos, Quaternion.Euler(40f, 222f, 0f));
                    break;
                }
                case PunTeams.Team.red:
                {
                    Vector3 pos = new Vector3(-170f, 40f, 180f);
                    Camera.main.transform.SetPositionAndRotation(pos, Quaternion.Euler(40f, 132f, 0f));
                    break;
                }
                case PunTeams.Team.green:
                {
                    Vector3 pos = new Vector3(170f, 40f, -180f);
                    Camera.main.transform.SetPositionAndRotation(pos, Quaternion.Euler(40f, -52f, 0f));
                    break;
                }
                default:
                {
                    Vector3 pos = new Vector3(-170f, 40f, -180f);
                    Camera.main.transform.SetPositionAndRotation(pos, Quaternion.Euler(40f, 42f, 0f));
                    break;
                }
            }
        }

        

        // Update is called once per frame
        void Update()
        {

        }
        
        public void TeamAsignation()
        {
            Photon.Realtime.Player[] playerListOthers = PhotonNetwork.PlayerListOthers;
            foreach (var player in playerListOthers)
            {
                if (player.GetTeam() == PunTeams.Team.blue)
                    color.Remove(PunTeams.Team.blue);
                else if (player.GetTeam() == PunTeams.Team.red)
                    color.Remove(PunTeams.Team.red);
                else if (player.GetTeam() == PunTeams.Team.green)
                    color.Remove(PunTeams.Team.green);
            }

            PhotonNetwork.LocalPlayer.SetTeam(color[color.Count - 1]);
        }
    }
}