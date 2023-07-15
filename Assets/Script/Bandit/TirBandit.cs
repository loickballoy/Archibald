using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirBandit : MonoBehaviour
{
    public int damage;
    
    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!collider.CompareTag("Ennemis") && !collider.CompareTag("Balle") && !collider.CompareTag("Weapon") &&
                 !collider.CompareTag("Armor") && !collider.CompareTag("Coins1") && !collider.CompareTag("Coins2") &&
                 !collider.CompareTag("Coins5") && !collider.CompareTag("Component"))
            Destroy(gameObject);
    }
}
