using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Debug.Log("a cliqué sur " + this.gameObject.name);
    }
}
