using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //public Sprite image;

    private void OnTriggerEnter2D(Collider2D collider)// method générique pour prendre un joueur
    {
        if (collider.CompareTag("Player") && Inventory.instance.bagIndex < 12)
        {
            Inventory.instance.AddBag(gameObject);
            transform.SetParent(collider.transform.GetChild(0).transform);
            gameObject.SetActive(false);
        }
    }
}
