using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool inventoryOpen = false;

    public GameObject inventory;

    public GameObject inventorySwitch;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !Pause.isPaused)
        {
            if (inventoryOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    void Open()
    {
        inventory.SetActive(true);
        inventoryOpen = true;
    }

    void Close()
    {
        inventorySwitch.GetComponent<InventorySwitch>().selectionned = false;
        inventorySwitch.GetComponent<InventorySwitch>().destroyItem = false;
        inventory.SetActive(false);
        inventoryOpen = false;
    }
}