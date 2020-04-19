using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using WorldConqueror;

public class Mouvement : MonoBehaviour
{
    
    public GameObject unit;

    private bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPos = new Vector3(-138.4f, 2, -150);
        Instantiate(unit, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 5, Space.Self);
            if (transform.position.x > 138)
                on = false;
            if (transform.position.x > -125 && transform.position.x < -110)
                transform.Translate(Vector3.forward * Time.deltaTime * 5, Space.Self);
            if (transform.position.x > 110 && transform.position.x < 125)
                transform.Translate(-Vector3.forward * Time.deltaTime * 5, Space.Self);
        }
    }

    /*
    private Player _player = PhotonNetwork.LocalPlayer;

    #region Blue

    public void MoveBlueToGreen()
    {
        
    } 

    #endregion

    public void MoveRight()
    {
        PunTeams.Team team = _player.GetTeam();
        switch (team)
        {
            case PunTeams.Team.blue:
        }
    } */
}
