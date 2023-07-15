using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHealth : MonoBehaviour
{

	public int maxHealth;
    public int currentHealth;

	public List<Transform> loot = new List<Transform>();

	public GameObject player;

	public bool Isincontact;

	public float DistanceToBedamaging;

	public Game game;

	public float BanditLevel;

	void Awake()
	{
		BanditLevel = Random.Range(1, 10);
		Isincontact = false;
	}

    void Start()
    {
		game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
		foreach (Transform coin in game.coins)
		{
			int chance = Random.Range(0,10);
			if (chance < 7)
			{
				loot.Add(coin);
			}
		}
		foreach (Transform comp in game.components)
		{
			int chance = Random.Range(0,10);
			if (chance < 4)
			{
				loot.Add(comp);
			}
		}
		/*foreach (Transform stimpack in game.stimpacks)
		{
			int chance = Random.Range(0,10);
			if (chance < 6)
			{
				loot.Add(stimpack);
			}
		}
		foreach (Transform stimics in game.stimics)
		{
			int chance = Random.Range(0,10);
			if (chance < 6)
			{
				loot.Add(stimics);
			}
		}*/
		foreach (Transform exp in game.experiences)
		{
			int chance = Random.Range(0,10);
			if (chance < 8)
			{
				loot.Add(exp);
			}
		}
		foreach (Transform weapon in game.weapons)
		{
			int chance = Random.Range(0,10);
			if (chance < 4)
			{
				loot.Add(weapon);
			}
		}

		foreach (Transform armor in game.armures)
		{
			int chance = Random.Range(0,10);
			if (chance < 4)
			{
				loot.Add(armor);
			}
		}

		player = GameObject.FindGameObjectWithTag("Player");
		currentHealth = maxHealth;
    }

    void Update()
    {
		PlayerIsInContact();
		PlayerIsNotInContact();

		if (currentHealth <= 0)
		{
			Vector3 transformloot = new Vector3(0,0,0);
			foreach (Transform objet in loot)
			{
				char mode;
				var lootobject = Instantiate(objet) as Transform;
				if (lootobject.tag == "Weapon")
				{
					WeaponsCaracteristics weaponsscript = lootobject.GetComponent<WeaponsCaracteristics>();
					int chancemode = (int) Random.Range(BanditLevel, 50);
					if (chancemode > 40)
						mode = 'L';
					else if (chancemode > 30)
						mode = 'E';
					else
						mode = 'N';
					int damage = (int) (Random.Range(BanditLevel, BanditLevel * Random.Range(1, 3f)));
					int level = (int) Random.Range(1, BanditLevel);
					int type = weaponsscript.GetType();
					weaponsscript.SetCaracteristics(mode, damage, level, type);
				}
				else if (lootobject.tag == "Armor")
				{
					ArmorsCaracteristics armorsscript = lootobject.GetComponent<ArmorsCaracteristics>();
					int chancemode = (int) Random.Range(BanditLevel, 50);
					if (chancemode > 40)
						mode = 'L';
					else if (chancemode > 30)
						mode = 'E';
					else
						mode = 'N';
					int resistance = (int) Random.Range(BanditLevel,BanditLevel * Random.Range(1f,3f));
					int level = (int) Random.Range(1, BanditLevel);
					int type = armorsscript.GetType();
					armorsscript.SetCaracteristics(mode, type, level, resistance);
				}
				lootobject.position = this.transform.position + transformloot ;
                transformloot += new Vector3(Random.Range(-0.5f,0.5f),Random.Range(-0.5f,0.5f),0);
			}
			Destroy(this.gameObject);
		}
    }

	private void PlayerIsInContact()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < DistanceToBedamaging)
        {
            Isincontact = true;
       	}
    }

	void PlayerIsNotInContact()
    {
        if (Vector3.Distance(player.transform.position, transform.position) >= DistanceToBedamaging)
        {
            Isincontact = false;
        }
    }

	public void TakeDamage(int damage)// method pour changer la vie et la bar de vie
    {
        currentHealth -= damage;
    }
}
