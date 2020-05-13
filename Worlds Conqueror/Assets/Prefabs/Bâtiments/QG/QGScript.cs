using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class QGScript : MonoBehaviour
    {
        public bool dead = false;
        public int life = 20;
        private Transform target;
        public float range = 60f;

        public float fireRate = 1f;
        private float fireCountdown = 0f;

        public Transform firePoint;
        public GameObject bullet;
        

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 2f); //appeler la fonction tt les 2s
        }

        // Update is called once per frame
        void UpdateTarget()
        {
            GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy2");
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

            if (life <= 0 && !dead)
            {
                dead = true;
                Destroy(gameObject);
                GameObject.Find("Unités").SetActive(false);
                GameObject.Find("Interface Ressource").SetActive(false);
                GameObject.Find("UnitMenu").SetActive(false);
                GameObject.Find("InfantryEnnemiChoice").SetActive(false);
                GameObject.Find("Loose").SetActive(true);


            }
        }

        void TakeDamage(int amount)
        {
            life -= amount;
        }

        void Shoot()
        {
            GameObject bulletGO = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
            Bulet bulet = bulletGO.GetComponent<Bulet>();

            if (bulet != null)
            {
                bulet.Search(target);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}