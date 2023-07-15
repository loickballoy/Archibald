using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirMouvementBandit : MonoBehaviour
{
    public float speed;
    private Game game;
    public float Ydirection;
	public float angle;
    
    GameObject player;

    public float Xdirection;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        Vector3 direction = (player.transform.position - transform.position);
		direction.Normalize();
        Xdirection = direction[0];
        Ydirection = direction[1];
		angle = Vector3.Angle(new Vector3(1,0,0),direction);
		if (Ydirection < 0)
			angle *= -1;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
    void Update()
    {
        transform.position += (Vector3) new Vector2(Xdirection*speed*Time.deltaTime,Ydirection*speed*Time.deltaTime);
    }
}
