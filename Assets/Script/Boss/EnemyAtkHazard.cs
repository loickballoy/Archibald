using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkHazard : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            //other.GetComponent<PlayerHeart>().TakeDamage(Damage);
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
