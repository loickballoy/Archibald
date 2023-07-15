using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public int stimpackCount;
	public Text stimpackCountText;
    public int stimiscCount;
    public Text stimiscCountText;
    public int componentsCount;
    public Text componentsCountText;
    public int ExperienceCount;
    public Text ExperienceCountText;
	public GameObject[] Weapons = new GameObject[2];

	public GameObject[] Bag = new GameObject[12];

	public int weaponsIndex;
	public int bagIndex;
	public GameObject casque;
	public GameObject plastron;
	public GameObject jambiere;

	public GameObject player;

	public static Inventory instance;

	public int playerResistance;

	public InventoryImage inventoryImage;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a deja un inventaire créé");
            return;
        }

        instance = this;

        player = GameObject.FindGameObjectWithTag("Player");
        playerResistance = player.GetComponent<PlayerHealth>().resistance;
    }

    public void AddCoins(int val)
    {
        coinsCount += val;
        coinsCountText.text = coinsCount.ToString();
    }

    public void UseCoins(int val)
    {
	    coinsCount -= val;
	    coinsCountText.text = coinsCount.ToString();
    }

	public void AddComponents(int val)
	{
		componentsCount += val;
		componentsCountText.text = componentsCount.ToString();
	}

	public void UseComponents(int val)
	{
		componentsCount -= val;
		componentsCountText.text = componentsCount.ToString();
	}

  public void AddStimpack(int val)
	{
		stimpackCount += val;
		stimpackCountText.text = stimpackCount.ToString();
	}

  public void AddStimisc(int val)
	{
		stimiscCount += val;
		stimiscCountText.text = stimiscCount.ToString();
	}

  public void AddExp(int val)
	{
		ExperienceCount += val;
		ExperienceCountText.text = ExperienceCount.ToString();
	}

	public void UseStimpack()
	{
		if (stimpackCount > 0)
			stimpackCount--;
			stimpackCountText.text = stimpackCount.ToString();
	}

	public void UpdateBagIndex()
    {
		bagIndex = 0;
		foreach (GameObject item in Bag)
		{
			if (item != null)
				bagIndex++;
		}
	}

	public void AddWeapons(GameObject weapon)
	{
		if (weaponsIndex < 2)
		{
			Weapons[weaponsIndex] = weapon;
			weaponsIndex++;
		}
		else
		{
			UpdateBagIndex();
			if (bagIndex < 12)
			{
				int i = 0;
				while (Bag[i] != null)
				{
					i++;
				}
				Bag[i] = weapon;
				bagIndex++;
			}
			else
			{
				Debug.LogWarning("Your bag is already full");
			}
		}
		

		inventoryImage.FindSprite();
		inventoryImage.SetSprite();
	}

	public void AddBag(GameObject objet)
	{
		UpdateBagIndex();
		if (bagIndex < 12)
		{
			int i = 0;
            while (Bag[i] != null)
            {
				i++;
            }
			Bag[i] = objet;
			bagIndex++;
		}
		else
		{
			Debug.LogWarning("Your bag is already full");
		}

		inventoryImage.FindSprite();
		inventoryImage.SetSprite();
	}

	public void TakeOffWeapons(GameObject Weapon)
	{
		Weapons[weaponsIndex] = null;
		weaponsIndex--;
	}

	public void PuttOnHelmet(GameObject helmet)
	{
		playerResistance -= casque.GetComponent<ArmorsCaracteristics>().GetResistance();
		casque = helmet;
		playerResistance += helmet.GetComponent<ArmorsCaracteristics>().GetResistance();
	}

	public void PuttOnChestplate(GameObject chestplate)
	{
		playerResistance -= plastron.GetComponent<ArmorsCaracteristics>().GetResistance();
		plastron = chestplate;
		playerResistance += chestplate.GetComponent<ArmorsCaracteristics>().GetResistance();
	}

	public void PuttOnLeggings(GameObject leggings)
	{
		playerResistance -= jambiere.GetComponent<ArmorsCaracteristics>().GetResistance();
		jambiere = leggings;
		playerResistance += leggings.GetComponent<ArmorsCaracteristics>().GetResistance();
	}

}
