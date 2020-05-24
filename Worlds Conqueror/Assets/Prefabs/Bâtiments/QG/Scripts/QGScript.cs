using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldConqueror;

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
        }

        // Update is called once per frame
        void UpdateTarget()
        {
            int l = 0;
            GameObject[] ennemiesG = new GameObject[0];
            GameObject[] ennemiesR = new GameObject[0];
            GameObject[] ennemiesB = new GameObject[0];
            GameObject[] ennemiesY = new GameObject[0];
            if (transform.tag != "Green")
            {
                GameObject[] ennemiesG2 = GameObject.FindGameObjectsWithTag("Green");
                ennemiesG = ennemiesG2;
                l += ennemiesG.Length;
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
            if (transform.tag != "Blue")
            {
                GameObject[] ennemiesB2 = GameObject.FindGameObjectsWithTag("Blue");
                ennemiesB = ennemiesB2;
                l += ennemiesB.Length;
            }

            GameObject[] ennemieUnit = new GameObject[l];

            int c = 0;
            for (int i = 0; i < ennemiesG.Length; i++)
            {
                ennemieUnit[c] = ennemiesG[i];
                c += 1;
            }
            for (int j = 0; j < ennemiesR.Length; j++)
            {
                ennemieUnit[c] = ennemiesR[j];
                c += 1;
            }
            for (int k = 0; k < ennemiesY.Length; k++)
            {
                ennemieUnit[c] = ennemiesY[k];
                c += 1;
            }
            for (int m = 0; m < ennemiesB.Length; m++)
            {
                ennemieUnit[c] = ennemiesB[m];
                c += 1;
            }
            int lengthUnit = 0;

            foreach (var i in ennemieUnit)
            {
                if (i.GetComponent<Unit>() != null)
                    lengthUnit++;
            }

            GameObject[] ennemies = new GameObject[lengthUnit];
            int compteur = 0;

            foreach (var i in ennemieUnit)
            {
                if (i.GetComponent<Unit>() != null)
                {
                    ennemies[compteur] = i;
                    compteur++;
                }
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
            UpdateTarget();
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

            /*if (CeBatiment.GetComponent<BuildingScript>().Heals <= 0 )
            {
                dead = true;
                GameObject.Find("Unités").SetActive(false);
                GameObject.Find("Interface Ressource").SetActive(false);
                GameObject.Find("UnitMenu").SetActive(false);
                GameObject.Find("InfantryEnnemiChoice").SetActive(false);
            }*/
        }

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