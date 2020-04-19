using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldConqueror;

public class MoveTest : MonoBehaviour
{
    /*
    private bool on = false;
    Unit TheOne = new Infantry(Unit.SoldierTeam.Blue);
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject unit = GameObject.Find("Infantry");
        Vector3 spawnPos = new Vector3(-138.4f, 2, -150);
        Instantiate(unit, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("i"))
        {
            
            on = true;
        }

        if (on)
        {
            transform.Translate(Vector3.right * Time.deltaTime * TheOne.Speed, Space.Self);
            if (transform.position.x > 138)
                on = false;
            if (transform.position.x > -125 && transform.position.x < -110)
                transform.Translate(Vector3.forward * Time.deltaTime * TheOne.Speed, Space.Self);
            if (transform.position.x > 110 && transform.position.x < 125)
                transform.Translate( - Vector3.forward * Time.deltaTime * TheOne.Speed, Space.Self);

        }
    }*/
}
