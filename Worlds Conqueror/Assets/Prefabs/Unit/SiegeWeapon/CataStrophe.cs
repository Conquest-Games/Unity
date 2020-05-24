using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace WorldConqueror
{
    public class CataStrophe : MonoBehaviour
    {
        private Transform target;
        private float range;
        private int dammage;

        public float fireRate = 1f;
        private float fireCountdown = 0f;

        public Transform firePoint;
        public GameObject bullet;
        
        void Start()
        {
            range = gameObject.GetComponent<Unit>().range;
            dammage = gameObject.GetComponent<Unit>().damage;

            InvokeRepeating("UpdateTarget", 0f, 2f);
        }

        void UpdateTarget()
        {
            int l = 0;
            GameObject[] ennemiesG = new GameObject[0];
            GameObject[] ennemiesR = new GameObject[0];
            GameObject[] ennemiesB = new GameObject[0];
            GameObject[] ennemiesY = new GameObject[0];
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

            GameObject[] ennemiesN = GameObject.FindGameObjectsWithTag("Neutral");
            l += ennemiesN.Length;


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
                gameObject.GetComponent<Unit>().fight = true;
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
        
        void Update()
        {
            if (target == null)
            {
                gameObject.GetComponent<Unit>().fight = false;
                return;
            }

            if (fireCountdown <= 0f)
            {
                if (target != null)
                {
                    Shoot(); 
                    ShootBat();
                }

                fireCountdown = 1 / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        void Shoot()
        {
            GameObject bulletGO = PhotonNetwork.Instantiate(bullet.name, firePoint.position, firePoint.rotation);
            Bulet bulet = bulletGO.GetComponent<Bulet>();

            if (bulet != null)
            {
                bulet.Search(target, dammage);
            }
        }

        void ShootBat()
        {
            CaptureScript ee = target.GetComponent<CaptureScript>();
            if (ee != null)
            {
                ee.TakeDammag(dammage, transform.tag);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
