using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Photon.MonoBehaviour
{
    private Game game;
    public GameObject player;
    public Vector3 posOffSet;
    
    public int regulator;

    private void Start()
    {
        game = (Game)GameObject.FindGameObjectWithTag("Game").GetComponent(typeof(Game));
    }

    void Update()
    {
            this.transform.position = player.transform.position + posOffSet;
            this.transform.position += game.mouse / regulator;
    }
}
