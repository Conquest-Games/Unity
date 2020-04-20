using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class TourDarcherScript : MonoBehaviour
    {
        private Transform target;
        public float range = 15f;

        public float fireRate = 1f;
        private float fireCountdown = 0f;

        public Transform firePoint;
        public GameObject arrow;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 2f); //appeler la fonction tt les 2s
        }
        
        void UpdateTarget()
        {
            GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
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

        // Update is called once per frame
        void Update()
        {
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
        }

        void Shoot()
        {
            GameObject arrowGO = (GameObject)Instantiate(arrow, firePoint.position, firePoint.rotation);
            Arow arow = arrowGO.GetComponent<Arow>();

            if (arow != null)
            {
                arow.Search(target);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}