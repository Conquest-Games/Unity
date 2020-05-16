using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
	public int hp = 100;
    
	public void TakeDammage(int amount)
     	{
     		hp -= amount;
     		if (hp <= 0)
     		{
     			Destroy(gameObject);
     		}
     	}
}
