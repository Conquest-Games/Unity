using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arow : MonoBehaviour
{
    private Transform target;
    private int dmg;
    public float speed = 70f;

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
        
        //rotation
        transform.LookAt(target);
    }
    
    void HitTarget()
    {
        Destroy(gameObject);
        
        CombatScript e = target.GetComponent<CombatScript>();
        if (e != null)
        {
            e.TakeDammage(dmg);
        }
    }
}
