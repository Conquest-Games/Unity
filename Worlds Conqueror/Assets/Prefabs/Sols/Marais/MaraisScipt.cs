using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldConqueror;

public class MaraisScipt : MonoBehaviour
{
    private GameObject[] ennemies;
    private float range = 9;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 2f);
    }

    void UpdateTarget()
    {
        GameObject[] ennemiesG = GameObject.FindGameObjectsWithTag("Green");
        GameObject[] ennemiesR = GameObject.FindGameObjectsWithTag("Red");
        GameObject[] ennemiesY = GameObject.FindGameObjectsWithTag("Yellow");
        GameObject[] ennemiesB = GameObject.FindGameObjectsWithTag("Blue");

        ennemies = new GameObject[ennemiesB.Length + ennemiesG.Length + ennemiesR.Length + ennemiesY.Length];

        int c = 0;
        for (int i = 0; i < ennemiesG.Length; i++)
        {
            ennemies[c] = ennemiesG[i];
            c += 1;
        }
        for (int j = 0; j < ennemiesR.Length; j++)
        {
            ennemies[c] = ennemiesR[j];
            c += 1;
        }
        for (int k = 0; k < ennemiesY.Length; k++)
        {
            ennemies[c] = ennemiesY[k];
            c += 1;
        }
        for (int m = 0; m < ennemiesB.Length; m++)
        {
            ennemies[c] = ennemiesB[m];
            c += 1;
        }
    }

    void Update()
    {
        foreach (var ennemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, ennemy.transform.position);
            if (distanceToEnemy <= range)
            {
                ennemy.GetComponent<Unit>().speed = ennemy.GetComponent<Unit>().initialSpeed / 2;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}


