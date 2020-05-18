using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaCScript : MonoBehaviour
{
	private Transform target;
	private Transform targetbat;
    public float range = 3f;
    public int dmg = 10;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 2f);
        InvokeRepeating("BatTarget", 0f, 2f);
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

	void BatTarget()
	{
		GameObject[] batiments = GameObject.FindGameObjectsWithTag("Neutral");
		
		float shortestDistance = Mathf.Infinity;
		GameObject nearestBat = null;

		foreach (GameObject bat in batiments)
		{
			float distanceToBat = Vector3.Distance(transform.position, bat.transform.position);
			if (distanceToBat < shortestDistance)
			{
				shortestDistance = distanceToBat;
				nearestBat = bat;
			}
		}

		if (nearestBat != null && shortestDistance <= range)
		{
			targetbat = nearestBat.transform;
		}
		else
		{
			targetbat = null;
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (target == null && targetbat == null)
	        return;
	    
        
        if (fireCountdown <= 0f)
        {
	        if (targetbat != null)
		        Capture();
	        else if (target != null)
		        Shoot(); //rajouter un try pour pas une erreur quand c un batiment ou une unité
				ShootBat();

	        fireCountdown = 1 / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

	void Shoot()
    {
        CombatScript e = target.GetComponent<CombatScript>();
        if (e != null)
        {
            e.TakeDammage(dmg);
        }
    }

	void ShootBat()
	{
		CaptureScript eee = target.GetComponent<CaptureScript>();
		if (eee != null)
		{
			eee.TakeDammag(dmg, transform.tag);
		}
	}

	void Capture()
	{
		CaptureScript ee = targetbat.GetComponent<CaptureScript>();
		if (ee != null)
		{
			ee.TakeDammag(dmg, transform.tag);
		}
	}
	

	private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
