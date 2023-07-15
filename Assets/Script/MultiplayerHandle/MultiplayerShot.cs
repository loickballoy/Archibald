using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerShot : MonoBehaviour
{
	public PhotonView photonView;

	public Transform shotPrefab;
	public Transform shotPrefabPlasma;
	public GameObject player;

	public float cooldown;
	public float timeleft;

	public bool isArmed;

	void Start()
	{
		timeleft = cooldown;
	}

	void Update()
	{
        if (photonView.isMine)
        {
			Timer();
			if (Input.GetKey(KeyCode.R) && timeleft <= 0 && isArmed)
				Attack();
		}
		
	}

	public void Timer()
	{
		if (timeleft >= 0)
			timeleft -= Time.deltaTime;
	}




	public void Attack()
	{
		if (player.GetComponent<PlayerWeapon>().shotPrefab.GetComponent<WeaponsCaracteristics>().type == 1)
		{
			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.position = transform.position;
			timeleft = cooldown;
		}
		else if (player.GetComponent<PlayerWeapon>().shotPrefab.GetComponent<WeaponsCaracteristics>().type == 2)
		{
			var shotTransform = Instantiate(shotPrefabPlasma) as Transform;
			shotTransform.position = transform.position;
			timeleft = cooldown;
		}


	}
}
