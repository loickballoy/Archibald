using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour


{

    //public PhotonView photonView;
    public Game game;

    public int speed;//variable vitesse
    public SpriteRenderer sR;
    public Rigidbody2D rB;
    private Vector3 velocity = Vector3.zero;
    public int runSpeed;
	  public int dashpower;
	  public int dashStaminaUsing;

    public Sprite[] images;
    private bool movement=false;
    private int zone=0;
    private float angle=0f;

    private float hM;
    private float vM;

    float doubleTapTime;
    KeyCode lastKeyCode;

	public PlayerStamina player;

    public bool bossActive;

    void Update()
    {
        /*if (photonView.isMine)
        {*/
            hM = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            vM = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftShift))//courrir ou pas courrir
            {
                hM = Input.GetAxisRaw("Horizontal") * speed * runSpeed * Time.deltaTime;
                vM = Input.GetAxisRaw("Vertical") * speed * runSpeed * Time.deltaTime;
            }

            if(hM != 0 && vM != 0)
            {
                rB.velocity = new Vector3(hM * 0.7f * speed * Time.deltaTime, vM * 0.7f * speed * Time.deltaTime);
            }
            else
            {
                rB.velocity = new Vector3(hM * speed * Time.deltaTime, vM * speed * Time.deltaTime);
            }

            

            Animation();

       /* }*/

	}

    void Animation()
    {
      angle = game.mouseAngle;

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

      movement = hM != 0 || vM != 0;
      sR.sprite = images[zone + System.Convert.ToInt32(movement) * 16 + System.Convert.ToInt32(game.turboBool)*8];
    }
}
