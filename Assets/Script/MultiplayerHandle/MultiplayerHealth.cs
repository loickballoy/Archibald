using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerHealth : MonoBehaviour
{
    public PhotonView photonView;

    public int maxHealth;// vie max variable
    public int currentHealth;// vie actuelle variable

    public Healthbar healthBar;// la bar de vie

    public int damage;// les dommages du test 

    public int care;// la puissance de soins du stimpack

    public Inventory inventory;

    public int resistance;


    void Start()// au debut on set la vie au max 
    {
        resistance = 5;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()// update a chaque instant
    {
        if (Input.GetKeyDown(KeyCode.K))//si tu appuies sur 'K' le joueur perd de la vie (c'est pour tester la bar de vie)
            TakeDamage(damage);
        if (photonView.isMine)
        {
            if (Input.GetKeyDown(KeyCode.W) && inventory.stimpackCount > 0)// si tu appuies sur 'W' et que tu as des stimpack tu gagne de la vie
            {
                EarnLife(care);// gagne de la vie
                inventory.UseStimpack();//utilise un stimpack
            }
        }
        

    }

    public void TakeDamage(int damage)// method pour changer la vie et la bar de vie
    {
        if (photonView.isMine)
        {
            currentHealth -= (damage - resistance);
            healthBar.SetHealth(currentHealth);
        }
        
    }

    void EarnLife(int care)// method pour recuperer de la vie
    {
        if (photonView.isMine)
        {
            if (currentHealth + care >= maxHealth)// si ca depasse la vie max
                currentHealth = maxHealth;
            else// sinon c bon 
                currentHealth += care;
            healthBar.SetHealth(currentHealth);
        }
        
    }
}
