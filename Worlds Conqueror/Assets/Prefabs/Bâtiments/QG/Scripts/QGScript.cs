using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class QGScript : MonoBehaviour
    {
        public GameObject CeBatiment;

        public bool dead = false;
        private Transform target;
        private float range = 0;
        private int dammage = 0;

        public float fireRate = 1f;
        private float fireCountdown = 0f;

        public Transform firePoint;
        public GameObject bullet;
        

        // Start is called before the first frame update
        void Start()
        {
            CeBatiment = gameObject;

            InvokeRepeating("UpdateTarget", 0f, 2f); //appeler la fonction tt les 2s
        }

        // Update is called once per frame
        void UpdateTarget()
        {
            GameObject[] ennemiesB = GameObject.FindGameObjectsWithTag("Blue");
            GameObject[] ennemiesR = GameObject.FindGameObjectsWithTag("Red");
            GameObject[] ennemiesY = GameObject.FindGameObjectsWithTag("Yellow");
            GameObject[] ennemiesG = GameObject.FindGameObjectsWithTag("Green");
            GameObject[] ennemies = null;

            int c = 0;

            switch (CeBatiment.tag)
            {
                case "Red":
                    ennemies = new GameObject[ennemiesB.Length + ennemiesG.Length + ennemiesY.Length];
                    for (int i = 0; i < ennemiesB.Length; i++)
                    {
                        ennemies[c] = ennemiesB[i];
                        c += 1;
                    }
                    for (int j = 0; j < ennemiesG.Length; j++)
                    {
                        ennemies[c] = ennemiesG[j];
                        c += 1;
                    }
                    for (int k = 0; k < ennemiesY.Length; k++)
                    {
                        ennemies[c] = ennemiesY[k];
                        c += 1;
                    }
                    break;


                case "Yellow":
                    ennemies = new GameObject[ennemiesB.Length + ennemiesR.Length + ennemiesG.Length];
                    for (int i = 0; i < ennemiesB.Length; i++)
                    {
                        ennemies[c] = ennemiesB[i];
                        c += 1;
                    }
                    for (int j = 0; j < ennemiesR.Length; j++)
                    {
                        ennemies[c] = ennemiesR[j];
                        c += 1;
                    }
                    for (int k = 0; k < ennemiesG.Length; k++)
                    {
                        ennemies[c] = ennemiesG[k];
                        c += 1;
                    }
                    break;

                case "Green":
                    ennemies = new GameObject[ennemiesB.Length + ennemiesR.Length + ennemiesY.Length];
                    for (int i = 0; i < ennemiesB.Length; i++)
                    {
                        ennemies[c] = ennemiesB[i];
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
                    break;

                default:
                    ennemies = new GameObject[ennemiesG.Length + ennemiesR.Length + ennemiesY.Length];
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
                    break;

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
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }

        void Update()
        {
            dammage = CeBatiment.GetComponent<BuildingScript>().dommage;
            range = CeBatiment.GetComponent<BuildingScript>().range;

            if (target == null)
            {
                return;
            }
            
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1 / fireRate;
            }

            fireCountdown -= Time.deltaTime;

            if (CeBatiment.GetComponent<BuildingScript>().Heals <= 0 && !dead)
            {
                dead = true;
                GameObject.Find("Unités").SetActive(false);
                GameObject.Find("Interface Ressource").SetActive(false);
                GameObject.Find("UnitMenu").SetActive(false);
                GameObject.Find("InfantryEnnemiChoice").SetActive(false);
                GameObject.Find("Loose").SetActive(true);


            }
        }

        /*void TakeDamage(int amount)
        {
            life -= amount;
        }*/

        void Shoot()
        {
            GameObject bulletGO = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
            Bulet bulet = bulletGO.GetComponent<Bulet>();

            if (bulet != null)
            {
                bulet.Search(target, dammage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}