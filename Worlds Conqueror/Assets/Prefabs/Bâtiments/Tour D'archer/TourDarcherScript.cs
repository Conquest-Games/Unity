using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class TourDarcherScript : MonoBehaviour
    {
        private Transform target;
        public float range = 15f;
        public int dammage = 40;

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
                arow.Search(target, dammage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}