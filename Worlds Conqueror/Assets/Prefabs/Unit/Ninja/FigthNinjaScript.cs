using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldConqueror
{
    public class FigthNinjaScript : MonoBehaviour
    {
        private Transform target;
        public float range = 3f;
        public int dmg = 10;

        public float fireRate = 1f;
        private float fireCountdown = 0f;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 2f);
        }

        void UpdateTarget()
        {
            int l = 0;
            GameObject[] ennemiesG = new GameObject[0];
            GameObject[] ennemiesR = new GameObject[0];
            GameObject[] ennemiesB = new GameObject[0];
            GameObject[] ennemiesY = new GameObject[0];
            GameObject[] ennemiesN = GameObject.FindGameObjectsWithTag("Neutral");
            l += ennemiesN.Length;

            if (transform.tag != "Blue")
            {
                GameObject[] ennemiesB2 = GameObject.FindGameObjectsWithTag("Blue");
                ennemiesB = ennemiesB2;
                l += ennemiesB.Length;
            }

            if (transform.tag != "Red")
            {
                GameObject[] ennemiesR2 = GameObject.FindGameObjectsWithTag("Red");
                ennemiesR = ennemiesR2;
                l += ennemiesR.Length;
            }

            if (transform.tag != "Yellow")
            {
                GameObject[] ennemiesY2 = GameObject.FindGameObjectsWithTag("Yellow");
                ennemiesY = ennemiesY2;
                l += ennemiesY.Length;
            }

            if (transform.tag != "Green")
            {
                GameObject[] ennemiesG2 = GameObject.FindGameObjectsWithTag("Green");
                ennemiesG = ennemiesG2;
                l += ennemiesG.Length;
            }

            GameObject[] ennemies = new GameObject[l];

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

            for (int n = 0; n < ennemiesN.Length; n++)
            {
                ennemies[c] = ennemiesN[n];
                c += 1;
            }

            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in ennemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                gameObject.GetComponent<Unit>().fight = true; //Variable permettant l'arret des unités lors des combats
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                //Variable permettant l'arret (ici la reprise du mouv) des unités lors des combats
                gameObject.GetComponent<Unit>().fight = false;
                return;
            }

            if (fireCountdown <= 0f)
            {
                Capture();
                fireCountdown = 1 / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        void Capture()
        {
            CaptureScript e = target.GetComponent<CaptureScript>();
            if (e != null)
            {
                e.TakeDammag(dmg, transform.tag);
            }
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
