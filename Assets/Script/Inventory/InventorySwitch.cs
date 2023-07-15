using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public bool selectionned = false;
    public bool destroyItem = false;
    public int selectedSlotIndex1;
    public int selectedSlotIndex2;
    public string selectedSlotType1;
    public string selectedSlotType2;

    public Inventory instance;

    public InventoryImage inventoryImage;

    void Update()
    {

    }

    public void SlotCliquedIndex(int index)
    {
        if (selectionned)
        {
            selectedSlotIndex2 = index;
        }
        else
        {
            selectedSlotIndex1 = index;
        }
        selectionned = !selectionned;
    }

    public void SlotCliquedType(string type)
    {
        if (!selectionned)
        {
            selectedSlotType2 = type;
        }
        else
        {
            selectedSlotType1 = type;
        }
        TryChange();
        TryDestroyItem();
        inventoryImage.FindSprite();
        inventoryImage.SetSprite();
        instance.UpdateBagIndex();
    }

    public void GetUnknowType()
    {
        if (!selectionned)
        {
            if (instance.Bag[selectedSlotIndex2] != null)
            {
                selectedSlotType2 = instance.Bag[selectedSlotIndex2].GetComponent<CommonForAllObjects>().type;
            }
        }
        else
        {
            if (instance.Bag[selectedSlotIndex1] != null)
            {
                selectedSlotType1 = instance.Bag[selectedSlotIndex1].GetComponent<CommonForAllObjects>().type;
            }
        }
        TryChange();
        TryDestroyItem();
        inventoryImage.FindSprite();
        inventoryImage.SetSprite();
        instance.UpdateBagIndex();
    }

    public void TryChange()
    {
        if (!selectionned && (selectedSlotIndex1 < 100 && selectedSlotIndex2 < 100))
        {
            var temp = instance.Bag[selectedSlotIndex1];
            instance.Bag[selectedSlotIndex1] = instance.Bag[selectedSlotIndex2];
            instance.Bag[selectedSlotIndex2] = temp;
        }
        else if (!selectionned && (selectedSlotType1 == selectedSlotType2))
        {
            if (selectedSlotIndex1 < 100 && !(selectedSlotIndex2 < 100))
            {
                if (selectedSlotIndex2 == 100)
                {
                    var temp = instance.Bag[selectedSlotIndex1];
                    instance.Bag[selectedSlotIndex1] = instance.casque;
                    instance.casque = temp;
                    instance.PuttOnHelmet(instance.casque);
                }
                else if (selectedSlotIndex2 == 101)
                {
                    var temp = instance.Bag[selectedSlotIndex1];
                    instance.Bag[selectedSlotIndex1] = instance.plastron;
                    instance.plastron = temp;
                    instance.PuttOnChestplate(instance.plastron);
                }
                else if (selectedSlotIndex2 == 102)
                {
                    var temp = instance.Bag[selectedSlotIndex1];
                    instance.Bag[selectedSlotIndex1] = instance.jambiere;
                    instance.jambiere = temp;
                    instance.PuttOnLeggings(instance.jambiere);
                }
                else if (selectedSlotIndex2 == 103)
                {
                    var temp = instance.Bag[selectedSlotIndex1];
                    instance.Bag[selectedSlotIndex1] = instance.Weapons[0];
                    instance.Weapons[0] = temp;
                }
                else if (selectedSlotIndex2 == 104)
                {
                    var temp = instance.Bag[selectedSlotIndex1];
                    instance.Bag[selectedSlotIndex1] = instance.Weapons[1];
                    instance.Weapons[1] = temp;
                }
            }
            else if (selectedSlotIndex2 < 100 && !(selectedSlotIndex1 < 100))
            {
                if (selectedSlotIndex1 == 100)
                {
                    var temp = instance.casque;
                    instance.casque = instance.Bag[selectedSlotIndex2];
                    instance.Bag[selectedSlotIndex2] = temp;
                    instance.PuttOnHelmet(instance.casque);
                }
                else if (selectedSlotIndex1 == 101)
                {
                    var temp = instance.plastron;
                    instance.plastron = instance.Bag[selectedSlotIndex2];
                    instance.Bag[selectedSlotIndex2] = temp;
                    instance.PuttOnChestplate(instance.plastron);
                }
                else if (selectedSlotIndex1 == 102)
                {
                    var temp = instance.jambiere;
                    instance.jambiere = instance.Bag[selectedSlotIndex2];
                    instance.Bag[selectedSlotIndex2] = temp;
                    instance.PuttOnLeggings(instance.jambiere);
                }
                else if (selectedSlotIndex1 == 103)
                {
                    var temp = instance.Weapons[0];
                    instance.Weapons[0] = instance.Bag[selectedSlotIndex2];
                    instance.Bag[selectedSlotIndex2] = temp;
                }
                else if (selectedSlotIndex1 == 104)
                {
                  var temp = instance.Weapons[1];
                  instance.Weapons[1] = instance.Bag[selectedSlotIndex2];
                  instance.Bag[selectedSlotIndex2] = temp;
                }
            }
            else if (selectedSlotIndex2 == 103 && selectedSlotIndex1 == 104)
            {
                var temp = instance.Weapons[0];
                instance.Weapons[0] = instance.Weapons[1];
                instance.Weapons[1] = temp;
            }
            else if (selectedSlotIndex2 == 104 && selectedSlotIndex1 == 103)
            {
                var temp = instance.Weapons[1];
                instance.Weapons[1] = instance.Weapons[0];
                instance.Weapons[0] = temp;
            }
        }
    }
    public void ResetIndex()
    {
        selectedSlotIndex1 = 0;
        selectedSlotIndex2 = 0;
        selectedSlotType1 = null;
        selectedSlotType2 = null;
    }

    public void PressDestroyButton()
    {
        destroyItem = !destroyItem;
        selectionned = false;
    }

    public void TryDestroyItem()
    {
        if (destroyItem && selectedSlotIndex1 < 100)
        {
            instance.Bag[selectedSlotIndex1] = null;
            selectionned = false;
        }
        destroyItem = false;
    }
}
