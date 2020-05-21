using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldConqueror;

public class Bulet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    private int dmg;

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
    }

    void HitTarget()
    {
        Destroy(gameObject); 
        
        Unit e = target.GetComponent<Unit>();
        if (e != null)
        {
            e.TakeDammage(dmg);
        }
    }
}
