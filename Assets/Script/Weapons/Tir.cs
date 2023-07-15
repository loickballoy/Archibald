using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public int damage;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damage = player.GetComponent<PlayerCaracteristics>().GetDamage();
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ennemis"))
        {
            collider.GetComponent<BanditHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!collider.CompareTag("Player") && !collider.CompareTag("Balle") && !collider.CompareTag("Weapon")  && !collider.CompareTag("Armor"))
            Destroy(gameObject);

    }
}
