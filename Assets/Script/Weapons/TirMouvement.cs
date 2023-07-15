using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirMouvement : MonoBehaviour
{
    public float speed;

    public Game game;
    public Vector3 mouse;

    public float Ydirection;

    public float Xdirection;


    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        mouse = game.mouse;
        mouse.Normalize();
        Xdirection = mouse[1];
        Ydirection = mouse[0];
        transform.eulerAngles = new Vector3(0, 0, game.mouseAngle);
    }
    void Update()
    {
        transform.position += (Vector3) new Vector2(Ydirection*speed*Time.deltaTime,Xdirection*speed*Time.deltaTime);
    }
}
