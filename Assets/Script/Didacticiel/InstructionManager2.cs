using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager2 : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] sentences;

    private GameObject player;

    public GameObject seller;

    public GameObject instructionCanvas;
    public Text dialogueText;
    private int len;
    private int index = 0;
    private int sentencesToWrite = 0;

    private bool haveMeetSeller = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        len = sentences.Length;
        dialogueText.text = sentences[sentencesToWrite];
        sentencesToWrite++;
        index++;
    }

    void Update()
    {
        
    }

    public void NextInstruction()
    {
        if (sentencesToWrite == len)
            instructionCanvas.SetActive(false);
        else
        {
            if (index == 1)
            {
                instructionCanvas.SetActive(false);
                index++;
            }
            
            else
            {
                dialogueText.text = sentences[sentencesToWrite];
                sentencesToWrite++;
                index++;
            }
        }
    }

    public void SellerTest()
    {
		instructionCanvas.SetActive(true);
        NextInstruction();
    }
}
