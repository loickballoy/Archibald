using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorsCaracteristics : MonoBehaviour
{
    public char mode;
    public int resistance;
    public int weight;
    public int price;
    public int type;
    public int level;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp()
    {
        level++;
        resistance +=(int) Random.Range(0f,3f) + 2;
        weight += (int) Random.Range(0f,1f);
        price = resistance * level * weight;
    }

    public int GetResistance()
    {
        return resistance;
    }

    public int GetWeight()
    {
        return weight;
    }

    public int GetPrice()
    {
        return price;
    }

    public int GetType()
    {
        return type;
    }

    public int GetLevel()
    {
        return level;
    }
    
    public void SetCaracteristics(char mode, int type, int level, int resistance)
    {
        this.mode = mode;
        this.resistance = resistance;
        weight = resistance/level + level;
        this.level = level;
        this.type = type;
        price = resistance * level * weight;
    }
}
