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
            GameObject[] ennemiesG = GameObject.FindGameObjectsWithTag("Green");
            GameObject[] ennemiesR = GameObject.FindGameObjectsWithTag("Red");
            GameObject[] ennemiesY = GameObject.FindGameObjectsWithTag("Yellow");
			GameObject[] ennemiesB = GameObject.FindGameObjectsWithTag("Blue");
            GameObject[] ennemies = new GameObject[ennemiesG.Length + ennemiesR.Length + ennemiesY.Length + ennemiesB.Length];

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
			for (int l = 0; l < ennemiesB.Length; l++)
			{
				ennemies[c] = ennemiesB[l];
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
            //pour instantier et que cela soit visible par tous, faut utiliser Photon.PUN.PhotonNetwork.instantiate
            //et que l'objet en question soit dans le dossier Ressources de photonUnityNetworking
            GameObject arrowGO = Instantiate(arrow, firePoint.position, firePoint.rotation);
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