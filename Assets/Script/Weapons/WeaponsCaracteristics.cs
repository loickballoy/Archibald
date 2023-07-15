using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsCaracteristics : MonoBehaviour
{
    public char mode;
    public int damage;
    public int price;
    public int level;
    public int type;

    public Sprite invImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetPrice()
    {
        return price;
    }

    public void LevelUp()
    {
        float newDamage = damage + Random.Range(0f, 2f) + 2;
        damage = (int) newDamage;
        level++;
        price = level * damage * type;
    }

    public int GetType()
    {
        return type;
    }
    public int GetLevel()
    {
        return level;
    }

    public void SetCaracteristics(char mode, int damage, int level, int type)
    {
        this.mode = mode;
        if (mode == 'L')
        {
            this.damage = damage + 4;
            this.level = level;
            this.type = type;
            price = level * damage * type * 4;
        }
        else if (mode == 'E')
        {
            this.damage = damage + 2;
            this.level = level;
            this.type = type;
            price = level * damage * type * 2;
        }
        else if (mode == 'N')
        {
            this.damage = damage;
            this.level = level;
            this.type = type;
            price = level * damage * type;
        }

    }
}
