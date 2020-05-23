using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMiniMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GameObject.Find("MiniMap").transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("MiniMap").transform);
    }
}
