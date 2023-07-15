using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaMovement : MonoBehaviour
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


            game.mouse.Normalize();

            transform.position = transform.parent.parent.position;
            transform.position -= new Vector3(0, 0.1f, 0);
            transform.position += new Vector3(game.mouse.x*0.15f, game.mouse.y*0.15f, 0);

            transform.eulerAngles = new Vector3(0, 0, game.mouseAngle);

            if (Mathf.Abs(game.mouseAngle) > 90)
                GetComponent<SpriteRenderer>().flipY = true;
            else
                GetComponent<SpriteRenderer>().flipY = false;
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
