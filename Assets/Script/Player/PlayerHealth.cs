using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;// vie max variable
    public int currentHealth;// vie actuelle variable
    
    public Healthbar healthBar;// la bar de vie

    public int damage;// les dommages du test 

    public int care;// la puissance de soins du stimpack

    public Inventory inventory;

	public int resistance;

    public GameObject deathCanvas;


    void Start()// au debut on set la vie au max 
    {
		resistance = 5;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()// update a chaque instant
    {
        if (currentHealth <= 0)
            Death();
        
        
        resistance = 0;
        if ( inventory.casque != null)
            resistance += inventory.casque.GetComponent<ArmorsCaracteristics>().resistance;
        if ( inventory.jambiere != null)
            resistance += inventory.jambiere.GetComponent<ArmorsCaracteristics>().resistance;
        if ( inventory.plastron != null)
        resistance += inventory.plastron.GetComponent<ArmorsCaracteristics>().resistance;
		if (inventory.stimpackCount > 0)
			if (Input.GetKeyDown(KeyCode.T))
			{
				inventory.UseStimpack();
				EarnLife(20);
			}

    }

    public void TakeDamage(int damage)// method pour changer la vie et la bar de vie
    {
		int degats = damage-resistance;
		if (damage-resistance <= 0)
			degats = 0;
        currentHealth -= (degats);
        healthBar.SetHealth(currentHealth);
    }

    void EarnLife(int care)// method pour recuperer de la vie
    {
        if (currentHealth + care >= maxHealth)// si ca depasse la vie max
            currentHealth = maxHealth;
        else// sinon c bon 
            currentHealth += care;
        healthBar.SetHealth(currentHealth);
    }

    void Death()
    {
        Time.timeScale = 0;
        deathCanvas.SetActive(true);
    }
}
