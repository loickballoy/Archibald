using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Save : MonoBehaviour
{
    public Inventory inventory;

    public string filesLocation = "Saves\\";

    public void Sauvegarde(string fileName)
    {
        fileName = filesLocation + fileName;
        if (File.Exists(fileName))
        {
            File.Delete(fileName);

        }
        CreateNewFile(fileName);
    }

    public void CreateNewFile(string fileName)
    {
        using (StreamWriter sw = File.CreateText(fileName))
        {
            Debug.Log("petit poucet 1 est passé par ici");
            sw.WriteLine(Weapon1ToTxt());
            sw.WriteLine(Weapon2ToTxt());
            sw.WriteLine(HelmetToTxt());
            sw.WriteLine(ChestplateToTxt());
            sw.WriteLine(LeggingsToTxt());
            sw.WriteLine(InventoryToTxt());
            sw.WriteLine(StackableToTxt());
        }
    }

    public string Weapon1ToTxt()
    {
        if (inventory.Weapons[0] != null)
        {
            return (inventory.Weapons[0].GetComponent<CommonForAllObjects>().type + ","
                + inventory.Weapons[0].GetComponent<CommonForAllObjects>().typeID + ","
                + inventory.Weapons[0].GetComponent<CommonForAllObjects>().level + ","
                + inventory.Weapons[0].GetComponent<CommonForAllObjects>().damage + ","
                + inventory.Weapons[0].GetComponent<CommonForAllObjects>().mode);
        }
        else
        {
            return "";
        }
    }

    public string Weapon2ToTxt()
    {
        if (inventory.Weapons[1] != null)
        {
            return (inventory.Weapons[1].GetComponent<CommonForAllObjects>().type + ","
                + inventory.Weapons[1].GetComponent<CommonForAllObjects>().typeID + ","
                + inventory.Weapons[1].GetComponent<CommonForAllObjects>().level + ","
                + inventory.Weapons[1].GetComponent<CommonForAllObjects>().damage + ","
                + inventory.Weapons[1].GetComponent<CommonForAllObjects>().mode);
        }
        else
        {
            return "";
        }
    }

    public string HelmetToTxt()
    {
        if (inventory.casque != null)
        {
            return (inventory.casque.GetComponent<CommonForAllObjects>().type + ","
                + inventory.casque.GetComponent<CommonForAllObjects>().typeID + ","
                + inventory.casque.GetComponent<CommonForAllObjects>().level + ","
                + inventory.casque.GetComponent<CommonForAllObjects>().resistance + ","
                + inventory.casque.GetComponent<CommonForAllObjects>().mode);
        }
        else
        {
            return "";
        }
    }

    public string ChestplateToTxt()
    {
        if (inventory.plastron != null)
        {
            return (inventory.plastron.GetComponent<CommonForAllObjects>().type + ","
                + inventory.plastron.GetComponent<CommonForAllObjects>().typeID + ","
                + inventory.plastron.GetComponent<CommonForAllObjects>().level + ","
                + inventory.plastron.GetComponent<CommonForAllObjects>().resistance + ","
                + inventory.plastron.GetComponent<CommonForAllObjects>().mode);
        }
        else
        {
            return "";
        }
    }

    public string LeggingsToTxt()
    {
        if (inventory.jambiere != null)
        {
            return (inventory.jambiere.GetComponent<CommonForAllObjects>().type + ","
                + inventory.jambiere.GetComponent<CommonForAllObjects>().typeID + ","
                + inventory.jambiere.GetComponent<CommonForAllObjects>().level + ","
                + inventory.jambiere.GetComponent<CommonForAllObjects>().resistance + ","
                + inventory.jambiere.GetComponent<CommonForAllObjects>().mode);
        }
        else
        {
            return "";
        }
    }


    public string InventoryToTxt()
    {
        string inventoryTxt = "";
        for (int i = 0; i < inventory.Bag.Length; i++)
        {
            if (inventory.Bag[i] != null)
            {
                if (inventory.Bag[i].GetComponent<CommonForAllObjects>().type == "weapon")
                {
                    inventoryTxt += (inventory.Bag[i].GetComponent<CommonForAllObjects>().type + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().typeID + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().level + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().damage + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().mode);
                }
                else
                {
                    inventoryTxt += (inventory.Bag[i].GetComponent<CommonForAllObjects>().type + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().typeID + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().level + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().resistance + ","
                + inventory.Bag[i].GetComponent<CommonForAllObjects>().mode);
                }
            }
            inventoryTxt += ';'; // warning 1 virgule en trop à derniere boucle
        }
        return inventoryTxt;
    }

    public string StackableToTxt()
    {
        return (inventory.coinsCount + "," + inventory.stimpackCount + "," + inventory.stimiscCount + "," + inventory.componentsCount + "," + inventory.ExperienceCount);
    }

    public GameObject bolter;
    public GameObject plasma;
    public GameObject helmet;
    public GameObject chestplate;
    public GameObject leggings;

    public GameObject LoadWeapon(string[] caracteristics, GameObject weaponType)
    {
        Debug.Log("petit poucet 2 est passé par ici");
        char mode;
        int damage;
        int level;
        int typeID;
        string type;
        var newWeapon = Instantiate(weaponType) as GameObject;
        CommonForAllObjects weaponStats = newWeapon.GetComponent<CommonForAllObjects>();
        mode = caracteristics[4][0];
        damage = Convert.ToInt32(caracteristics[3]);
        level = Convert.ToInt32(caracteristics[2]);
        typeID = Convert.ToInt32(caracteristics[1]);
        type = caracteristics[0];
        weaponStats.WeaponSetCaracteristics(mode, damage, level, typeID, type);
        return newWeapon;
    }

    public GameObject LoadArmor(string[] caracteristics, GameObject armorType)
    {
        Debug.Log("petit poucet 3 est passé par ici");
        char mode;
        int resistance;
        int level;
        int typeID;
        string type;
        var newArmor = Instantiate(armorType) as GameObject;
        CommonForAllObjects armorStats = newArmor.GetComponent<CommonForAllObjects>();
        mode = caracteristics[4][0];
        resistance = Convert.ToInt32(caracteristics[3]);
        level = Convert.ToInt32(caracteristics[2]);
        typeID = Convert.ToInt32(caracteristics[1]);
        type = caracteristics[0];
        armorStats.ArmorSetCaracteristics(mode, resistance, level, typeID, type);
        return newArmor;
    }

    public void LoadStackable(string[] stackables)
    {
        inventory.coinsCount = Convert.ToInt32(stackables[0]);
        inventory.stimpackCount = Convert.ToInt32(stackables[1]);
        inventory.stimiscCount = Convert.ToInt32(stackables[2]);
        inventory.componentsCount = Convert.ToInt32(stackables[3]);
        inventory.ExperienceCount = Convert.ToInt32(stackables[4]);
    }

    public void LoadSave(string fileName)
    {
        fileName = filesLocation + fileName;
        using (StreamReader sr = new StreamReader(fileName))
        {
            string[] weapon1Caracteristics = sr.ReadLine().Split(',');
            if (weapon1Caracteristics[0] != "")
            {
                if (Convert.ToInt32(weapon1Caracteristics[1]) == 1)
                {
                    inventory.AddWeapons(LoadWeapon(weapon1Caracteristics, bolter));

                }
                else
                {
                    inventory.AddWeapons(LoadWeapon(weapon1Caracteristics, plasma));
                }
            }

            string[] weapon2Caracteristics = sr.ReadLine().Split(',');
            if (weapon2Caracteristics[0] != "")
            {
                if (Convert.ToInt32(weapon2Caracteristics[1]) == 1)
                {
                    inventory.AddWeapons(LoadWeapon(weapon2Caracteristics, bolter));

                }
                else
                {
                    inventory.AddWeapons(LoadWeapon(weapon2Caracteristics, plasma));
                }
            }

            string[] helmetCaracteristics = sr.ReadLine().Split(',');
            if (helmetCaracteristics[0] != "")
            {
                inventory.PuttOnHelmet(LoadArmor(helmetCaracteristics, helmet));
            }

            string[] chestplateCaracteristics = sr.ReadLine().Split(',');
            if (chestplateCaracteristics[0] != "")
            {
                inventory.PuttOnChestplate(LoadArmor(chestplateCaracteristics, chestplate));
            }

            string[] leggingsCaracteristics = sr.ReadLine().Split(',');
            if (leggingsCaracteristics[0] != "")
            {
                inventory.PuttOnLeggings(LoadArmor(leggingsCaracteristics, leggings));
            }

            string[] inventoryList = sr.ReadLine().Split(';');
            for (int i = 0; i < inventoryList.Length; i++)
            {
                string[] itemCaracteristics = inventoryList[i].Split(',');
                if (itemCaracteristics[0] != "")
                {
                    if (itemCaracteristics[0] == "weapon")
                    {
                        if (Convert.ToInt32(itemCaracteristics[1]) == 1)
                        {
                            inventory.Bag[i] = LoadWeapon(itemCaracteristics, bolter);

                        }
                        else
                        {
                            inventory.Bag[i] = LoadWeapon(itemCaracteristics, plasma);
                        }
                    }
                    if (itemCaracteristics[0] == "helmet")
                    {
                        inventory.Bag[i] = LoadArmor(itemCaracteristics, helmet);
                    }
                    if (itemCaracteristics[0] == "chestplate")
                    {
                        inventory.Bag[i] = LoadArmor(itemCaracteristics, chestplate);
                    }
                    if (itemCaracteristics[0] == "leggings")
                    {
                        inventory.Bag[i] = LoadArmor(itemCaracteristics, leggings);
                    }
                }
            }

            string[] stackables = sr.ReadLine().Split(',');
            LoadStackable(stackables);
        }
    }
}