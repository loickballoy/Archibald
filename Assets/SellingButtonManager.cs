using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingButtonManager : MonoBehaviour
{
    private Inventory inv;

    public GameObject SellingImage;
    
    
    public void Selling(int i)
    {
        inv = Inventory.instance;
        if (inv.Bag[i] != null)
        {
            if (inv.Bag[i].GetComponent<CommonForAllObjects>().type == "weapon")
            {
                inv.AddComponents(inv.Bag[i].GetComponent<WeaponsCaracteristics>().price);
            }
            else
            {
                inv.AddComponents(inv.Bag[i].GetComponent<ArmorsCaracteristics>().price);
            }
            inv.Bag[i] = null;
            SellingImage.GetComponent<SellingImage>().ResetSprite();
        }
    }

	public void Upgrading(int i)
	{
		inv = Inventory.instance;
        if (inv.Bag[i] != null)
        {
            if (inv.Bag[i].GetComponent<CommonForAllObjects>().type == "weapon")
            {
				if (inv.componentsCount >= inv.Bag[i].GetComponent<WeaponsCaracteristics>().price)
				{
					inv.UseComponents(inv.Bag[i].GetComponent<WeaponsCaracteristics>().price);
                	inv.Bag[i].GetComponent<WeaponsCaracteristics>().LevelUp();
				}
            }
            else
            {
				if (inv.componentsCount >= inv.Bag[i].GetComponent<ArmorsCaracteristics>().price)
				{
					inv.UseComponents(inv.Bag[i].GetComponent<ArmorsCaracteristics>().price);
                	inv.Bag[i].GetComponent<ArmorsCaracteristics>().LevelUp();
				}
			}
            SellingImage.GetComponent<SellingImage>().ResetSprite();
        }
	}

    /*public void TestButton()
    {
        Debug.Log("button marche");
    }*/
}
