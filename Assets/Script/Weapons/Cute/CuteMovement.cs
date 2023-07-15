﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuteMovement : MonoBehaviour
{
    
    public Game game;
    public GameObject player;
    
    public bool isKeep;

    public bool isEquiped;

    public float range;
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    
    void Update()
    {
        if (!gameObject.activeInHierarchy)
            isEquiped = false;
        else
            isEquiped = true;
        if (isEquiped && isKeep)
        {
            transform.position = player.transform.position - new Vector3 (-0.22f,0.05f,0);
            game.mouse.Normalize();
            transform.position += game.mouse * range;
            if (Mathf.Abs(game.mouseAngle) > 90)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
            if (game.mouseAngle > 0)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 1;
                transform.position += new Vector3(0, 0.12f, 0);
            }
            
            else 
                GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
        
    }
}
