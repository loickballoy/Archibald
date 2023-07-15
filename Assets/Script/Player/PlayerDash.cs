using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : Photon.MonoBehaviour
{

    //public PhotonView photonView;

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public GameObject dashEffect;
	private GameObject player;

    void Start()
    {
        /*if (photonView.isMine)
        {*/
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        /*}*/
		
    }

    void Update()
    {
        /*if (photonView.isMine)
        {*/
            if (direction == 0)
            {
                if (Input.GetKey(KeyCode.Space) && player.GetComponent<PlayerStamina>().currentStamina > 0)
                {


                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Instantiate(dashEffect, transform.position, Quaternion.identity);
                        player.GetComponent<PlayerStamina>().UseStamina(10);
                        direction = 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        Instantiate(dashEffect, transform.position, Quaternion.identity);
                        player.GetComponent<PlayerStamina>().UseStamina(10);
                        direction = 2;
                    }
                    else if (Input.GetKeyDown(KeyCode.Z))
                    {
                        Instantiate(dashEffect, transform.position, Quaternion.identity);
                        player.GetComponent<PlayerStamina>().UseStamina(10);
                        direction = 3;
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        Instantiate(dashEffect, transform.position, Quaternion.identity);
                        player.GetComponent<PlayerStamina>().UseStamina(10);
                        direction = 4;
                    }
                }


            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    if (direction == 1)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }
                    else if (direction == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed;
                    }
                    else if (direction == 3)
                    {
                        rb.velocity = Vector2.up * dashSpeed;
                    }
                    else if (direction == 4)
                    {
                        rb.velocity = Vector2.down * dashSpeed;
                    }
                }
            }
        /*}*/
        
    }
}
