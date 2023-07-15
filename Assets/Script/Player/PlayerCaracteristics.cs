using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaracteristics : MonoBehaviour
{
    
    public int resistance;
    public int weight;
    public int damage;
    public int health;

    public Vector3 position;

    public Inventory inv;
    
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth;
        position = GameObject.FindGameObjectWithTag("Player").transform.position;


    }

    void Update()
    {
        
    }
    
    public int GetDamage()
    {
        return damage;
    }
    
    public int GetResistance()
    {
        return resistance;
    }

    public int GetWeight()
    {
        return weight;
    }

    public void SetResistance(int resistance)
    {
        this.resistance = resistance;
    }
    public void SetWeight(int weight)
    {
        this.weight = weight;
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
