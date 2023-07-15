using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonForAllObjects : MonoBehaviour
{
    public string type;
    public int typeID;
    public int level;
    public int damage;
    public int resistance;
    public char mode;
    public int price;
    public int weight;

    public void WeaponSetCaracteristics(char mode, int damage, int level, int typeID, string type)
    {
        this.mode = mode;
        if (mode == 'L')
        {
            this.damage = damage + 5;
            this.level = level;
            this.typeID = typeID;
            price = level * damage * typeID * 4;
            this.type = type;
        }
        else if (mode == 'E')
        {
            this.damage = damage + 3;
            this.level = level;
            this.typeID = typeID;
            price = level * damage * typeID * 2;
            this.type = type;

        }
        else if (mode == 'N')
        {
            this.damage = damage;
            this.level = level;
            this.typeID = typeID;
            price = level * damage * typeID;
            this.type = type;

        }
    }

    public void ArmorSetCaracteristics(char mode, int typeID, int level, int resistance, string type)
    {
        this.mode = mode;
        this.resistance = resistance;
        this.weight = resistance / level + level;
        this.level = level;
        this.typeID = typeID;
        this.price = resistance * level * weight;
        this.type = type;
    }
}
