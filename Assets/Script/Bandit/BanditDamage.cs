using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditDamage : MonoBehaviour
{
	public bool canattack;
    public float timeleft;
    public float timer;

    public int damage;
    public int level;
    public BanditHealth banditHealth;
	public bool playerisin;

	public GameObject player;
	
	
	void Start()
	{
		level = (int) banditHealth.BanditLevel;
		damage += 5 * level;
		player = GameObject.FindGameObjectWithTag("Player");
		canattack = true;
		playerisin = false;
	}
    void Update()
    {
		if (canattack && playerisin)
		{
			timeleft = timer;
			canattack = false;
			player.GetComponent<PlayerHealth>().TakeDamage(damage);
		}
		if (!canattack)
			timeleft -= Time.deltaTime;
		if (timeleft < 0)
		{
			canattack = true;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerisin = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerisin = false;
        }
    }
}
