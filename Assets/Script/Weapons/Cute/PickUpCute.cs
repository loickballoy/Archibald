using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCute : MonoBehaviour
{
    public int compteur = 1;
    private void OnTriggerEnter2D(Collider2D collider)// method générique pour prendre un joueur
    {
        if (collider.CompareTag("Player") && compteur == 1)
        {
            Inventory.instance.AddWeapons(gameObject);
            transform.SetParent(collider.transform.GetChild(0).transform);
            gameObject.GetComponent<CuteMovement>().isKeep = true;
            gameObject.SetActive(false);
            compteur--;
        }
    }
}
