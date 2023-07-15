using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    
    [TextArea(3, 10)]
    public string[] sentences;

    public GameObject instructionCanvas;
    public GameObject nextLevel;
    public GameObject bed;
    
    public Text dialogueText;

    private int len;

    private int index = 0;
    private int sentencesToWrite = 0;

    private bool moveCheckZ = false;
    private bool moveCheckQ = false;
    private bool moveCheckS = false;
    private bool moveCheckD = false;
   
    void Start()
    {
        len = sentences.Length;
        dialogueText.text = sentences[sentencesToWrite];
        sentencesToWrite++;
        index++;
    }

    void Update()
    {
        if (index == 2)
        {
            MoveInstruction();
        }
        
    }

    // Update is called once per frame
    public void NextInstruction()
    {
        if (sentencesToWrite == len)
            instructionCanvas.SetActive(false);
        else
        {
            if (index == 1)
            {
                MoveInstruction();
                index++;
            }
            else if (index == 2)
            {
                bed.SetActive(true);
                dialogueText.text = sentences[sentencesToWrite];
                sentencesToWrite++;
                index++;
            }

            else if (index == 3)
            {
                nextLevel.SetActive(true);
                dialogueText.text = sentences[sentencesToWrite];
                sentencesToWrite++;
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

    public void MoveInstruction()
    {
        instructionCanvas.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Z))
            moveCheckZ = true;
        if (Input.GetKeyDown(KeyCode.Q))
            moveCheckQ = true;
        if (Input.GetKeyDown(KeyCode.S))
            moveCheckS = true;
        if (Input.GetKeyDown(KeyCode.D))
            moveCheckD = true;
        if (moveCheckD && moveCheckS && moveCheckZ && moveCheckQ)
        {
            NextInstruction();
            instructionCanvas.SetActive(true);
        }
        
    }
}
