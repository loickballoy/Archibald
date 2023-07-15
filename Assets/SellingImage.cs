using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellingImage : MonoBehaviour
{

    public Image[] images;

    public Sprite[] sprites;

    public Text[] stats;

    public Text[] prices;
    private Inventory inv;

    private WeaponsCaracteristics WC;
    private ArmorsCaracteristics AC;
   
        
    void Start()
    {
        FindSprite();
        SetSprite();
    }

    void Update()
    {
        FindSprite();
        SetSprite();
    }

    public void FindSprite()
    {
        inv = Inventory.instance;
        for (int i = 0; i < inv.Bag.Length; i++)
        {
            if (inv.Bag[i] != null)
            {
                if (inv.Bag[i].GetComponent<CommonForAllObjects>().type == "weapon")
                {
                    WC = inv.Bag[i].GetComponent<WeaponsCaracteristics>();
                    sprites[i] = WC.invImage;
                    if (WC.type == 1)
                        stats[i].text = "Bolter: Damage " + WC.damage;
                    else 
                        stats[i].text = "PlasmaGun: Damage " + WC.damage;
                    prices[i].text = "" + WC.price;
                }

                else
                {
                    AC = inv.Bag[i].GetComponent<ArmorsCaracteristics>();
                    sprites[i] = inv.Bag[i].GetComponent<SpriteRenderer>().sprite;
                    if (AC.type == 1)
                        stats[i].text = "Helmet: Resistance " + AC.resistance;
                    else if (AC.type == 2)
                        stats[i].text = "ChestPlate: Resistance " + AC.resistance;
                    else 
                        stats[i].text = "Leggins: Resistance " + AC.resistance;
                    prices[i].text = "" + AC.price;
                }
            }
        }
        
    }

    public void SetSprite()
    {
        int i = 0;
        foreach (Image image in images)
        {
            image.sprite = sprites[i];
            i++;
            if (image.sprite != null)
                image.enabled = true;
            else
                image.enabled = false;
        }
    }

    public void ResetSprite()
    {
        for (int i = 0; i < 12; i++)
        {
            sprites[i] = null;
            stats[i].text = "";
            prices[i].text = "";
        }
        FindSprite();
        SetSprite();
    }
}
