using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject shotPrefab { get; private set; }
    
    public Inventory inventory;

    private GameObject player;

    public int compteur = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

       if (inventory.Weapons[0] != null && compteur == 1)
        {
            shotPrefab = inventory.Weapons[0];
            shotPrefab.SetActive(true);
            compteur--;
            player.GetComponent<PlayerCaracteristics>().SetDamage(shotPrefab.GetComponent<WeaponsCaracteristics>().GetDamage());
            SetisArmed();
        }
        
        else if (inventory.Weapons[1] != null && Input.GetKeyDown(KeyCode.Alpha2))
        {
            shotPrefab.SetActive(false);
            shotPrefab = inventory.Weapons[1];
            player.GetComponent<PlayerCaracteristics>().SetDamage(shotPrefab.GetComponent<WeaponsCaracteristics>().GetDamage());
            shotPrefab.SetActive(true);
        }
        
        else if (inventory.Weapons[0] != null && Input.GetKeyDown(KeyCode.Alpha1))
        {
            shotPrefab.SetActive(false);
            shotPrefab = inventory.Weapons[0];
            player.GetComponent<PlayerCaracteristics>().SetDamage(shotPrefab.GetComponent<WeaponsCaracteristics>().GetDamage());
            shotPrefab.SetActive(true);
        }
       
    }

    void SetisArmed()
    {
        if (compteur != 1)
        {
            this.GetComponent<PlayerShot>().isArmed = true;
        }
    }
}
