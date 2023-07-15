using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBandit : MonoBehaviour
{
    public int speed;
    public Transform[] waypoints;



    public Transform Player;

    public Transform target;
    public Game game;
    private int destPoint = 0;
    public int distancetosee;

    public SpriteRenderer sR;
    public Rigidbody2D rB;
    public Sprite[] images;
    public Vector3 dir;
    private bool movement=true;
    private int zone=0;
    public float angle=0f;

    public bool IsResearchingPlayer;


    void Start()
    {
        target = waypoints[0];
        Player = GameObject.FindGameObjectWithTag("waypoints").transform;
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        IsResearchingPlayer = false;
    }


    void Update()
    {
        dir = target.position - transform.position;
        dir.Normalize();
        Animation();
        this.transform.rotation = new Quaternion(0,0,0,0);

        rB.velocity = new Vector3(dir.x * speed * Time.deltaTime,dir.y * speed * Time.deltaTime,0);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint +1 ) % waypoints.Length;
            target = waypoints[destPoint];
        }

        else if (Vector3.Distance(transform.position, Player.position) < distancetosee)
        {
            target = Player;
            IsResearchingPlayer = true;
        }

        else if (Vector3.Distance(transform.position, Player.position) > distancetosee+1 && IsResearchingPlayer)
        {
            target = waypoints[0];
            IsResearchingPlayer = false;
        }


    }

    void Animation()
    {

      angle = Vector3.Angle(dir, new Vector3(1, 0, 0));
      angle *= dir.y < 0? -1 : 1;

      if (angle >= 135)
        zone = 2;
      else if (angle >= 90)
          zone = 3;
      else if (angle >= 45)
          zone = 4;
      else if (angle >= 0)
          zone = 5;
      else if (angle >= -45)
          zone = 6;
      else if (angle >= -90)
          zone = 7;
      else if (angle >= -135)
          zone = 0;
      else
          zone = 1;

      sR.sprite = images[zone + System.Convert.ToInt32(movement) * 16 + System.Convert.ToInt32(game.turboBool)*8];
    }
}
