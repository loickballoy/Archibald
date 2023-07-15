using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryImage : MonoBehaviour
{
    public Image[] images;

    public Sprite[] sprites;
    public GameObject Inventory;
    private Inventory inv;

    public Sprite noneSprite;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Image image in images)
        {
            image.enabled = true;
        }
        FindSprite();
        SetSprite();
    }

    public void FindSprite()
    {
        inv = Inventory.GetComponent<Inventory>();
        if (inv.casque != null)
            sprites[0] = inv.casque.GetComponent<SpriteRenderer>().sprite;
        else
            sprites[0] = null;
        if (inv.plastron != null)
            sprites[1] = inv.plastron.GetComponent<SpriteRenderer>().sprite;
        else
            sprites[1] = null;
        if (inv.jambiere != null)
            sprites[2] = inv.jambiere.GetComponent<SpriteRenderer>().sprite;
        else
            sprites[2] = null;
        if (inv.Weapons[0] != null)
            sprites[3] = inv.Weapons[0].GetComponent<WeaponsCaracteristics>().invImage;
        else
            sprites[3] = null;
        if (inv.Weapons[1] != null)
            sprites[4] = inv.Weapons[1].GetComponent<WeaponsCaracteristics>().invImage;
        else
            sprites[4] = null;

        for (int i = 0; i < inv.Bag.Length; i++)
        {
            if (inv.Bag[i] != null)
            {
              if(inv.Bag[i].GetComponent<CommonForAllObjects>().type == "weapon")
                  sprites[i+5] = inv.Bag[i].GetComponent<WeaponsCaracteristics>().invImage;
              else
                  sprites[i+5] = inv.Bag[i].GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                sprites[i + 5] = null;
            }

        }
    }

    public void SetSprite()
    {
        int i = 0;
        foreach (Image image in images)
        {
            image.sprite = sprites[i];
            if (sprites[i] == null)
            {
                image.sprite = noneSprite;
            }
            i++;
        }
    }
}
