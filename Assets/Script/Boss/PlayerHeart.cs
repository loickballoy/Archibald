using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeart : MonoBehaviour
{
    public int hP;
    public int maxHp;

    public PlayerHealth playerHealth;
    public GameObject deathScreen;


    public void TakeDamage(int dmg)
    {
        hP -= dmg;

        if (hP < 0)
        {
            Death();
        }

        

    }

    public void Death()
    {
        Debug.Log("You Have Died");
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            go.SetActive(false);
        }
        //GameObject obj = GameObject.FindGameObjectWithTag("DeathScreen");
        //obj.SetActive(true);
        deathScreen.SetActive(true);
    
    }

    void Start()
    {
        maxHp = playerHealth.maxHealth;
        hP = playerHealth.currentHealth;
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            Death();
        }
    }
    
}

