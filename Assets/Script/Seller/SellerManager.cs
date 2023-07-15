using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellerManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public GameObject buyingCanvas;
    public GameObject sellingCanvas;
    public GameObject instructionManager;
    public GameObject selling;
	public GameObject upgrading;
    private GameObject player;

    private Inventory inv;
    public Text ErrorStims;
    public bool exit = false;

    public InventoryImage inventoryImage;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inv = player.GetComponent<Inventory>();
    }

    void Update()
    {
        exit = (dialogueCanvas.activeSelf || buyingCanvas.activeSelf || sellingCanvas.activeSelf || selling.activeSelf ||
               upgrading.activeSelf);
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (exit)
            {
                dialogueCanvas.SetActive(false);
                buyingCanvas.SetActive(false);
                sellingCanvas.SetActive(false);
                selling.SetActive(false);
            	upgrading.SetActive(false);
            }
        }
        
    }

    public void BuyingMode()
    {
        dialogueCanvas.SetActive(false);
        buyingCanvas.SetActive(true);
        ErrorStims.text = "";
    }
    public void SellingMode()
    {
        dialogueCanvas.SetActive(false);
        sellingCanvas.SetActive(true);
    }

    public void Quit()
    {
        dialogueCanvas.SetActive(false);
        if (instructionManager != null)
        {
            instructionManager.GetComponent<InstructionManager2>().SellerTest();
        }
    }

    public void QuitBuyingMode()
    {
        buyingCanvas.SetActive(false);
        if (instructionManager != null)
        {
            instructionManager.GetComponent<InstructionManager2>().SellerTest();
        }
    }
    public void QuitSellingMode()
    {
        sellingCanvas.SetActive(false);
        if (instructionManager != null)
        {
            instructionManager.GetComponent<InstructionManager2>().SellerTest();
        }
    }

    public void BuyingStimpack()
    {
        if (Inventory.instance.coinsCount < 20)
            ErrorStims.text = "Tu n'as pas assez de coins";
        else
        {
            Inventory.instance.UseCoins(20);
            Inventory.instance.AddStimpack(1);
        }
    }

    public void SellingInv()
    {
        sellingCanvas.SetActive(false);
        selling.SetActive(true);
        inventoryImage.FindSprite();
        inventoryImage.SetSprite();
    }

	public void UpgradingInv()
    {
        sellingCanvas.SetActive(false);
        upgrading.SetActive(true);
    }
}
