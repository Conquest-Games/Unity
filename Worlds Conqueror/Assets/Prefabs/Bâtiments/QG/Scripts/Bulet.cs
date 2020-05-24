using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldConqueror;

public class Bulet : MonoBehaviour
{
    private Transform target;
    public float speed = 100f;
    private int dmg;
	public string tagg;

    public void Search(Transform _target, int dammage)
    {
        target = _target;
        dmg = dammage;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
 		transform.LookAt(target);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        
        try
        {
            Unit e = target.GetComponent<Unit>();
            if (e != null)
            {
                e.TakeDammage(dmg);
            }
        }
        catch (Exception e)
        {
            
        }
    }
}
