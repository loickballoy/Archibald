using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int health;

    public float[] position;

    public PlayerData(PlayerCaracteristics player)
    {
        health = player.health;

        position = new float[3];
        position[0] = player.position.x;
        position[1] = player.position.y;
        position[2] = player.position.z;
    }
}
    

