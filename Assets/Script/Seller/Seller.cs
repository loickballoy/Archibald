using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{

	private GameObject player;

	public GameObject canvas;

	public SellerManager sellerManager;

	public bool canTalk;

	public Game game;
	public Sprite[] images;
	public SpriteRenderer sR;
	
    void Start()
    {
	    player = GameObject.FindGameObjectWithTag("Player");
		canTalk = false;
		game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position,this.transform.position) < 3)
		{
			canTalk = true;
		}
		if (Vector3.Distance(player.transform.position,this.transform.position) > 3)
		{
			canTalk = false;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			if (canTalk && !sellerManager.exit)
			{
				canvas.SetActive(true);
			}
		}

		sR.sprite = images[System.Convert.ToInt32(canTalk) + System.Convert.ToInt32(game.turboBool)*2];
    }
}
