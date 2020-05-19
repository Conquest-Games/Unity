using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationText : MonoBehaviour
{
    private Transform Camera;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameObject.Find("Regarde Moi").transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("Regarde Moi").transform);
    }
}
