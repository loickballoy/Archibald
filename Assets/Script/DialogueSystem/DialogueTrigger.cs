using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private bool isInRange;
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.Space) && !DialogueManager.instance.isInDialogue)
        {
            TriggerDialogue();
        }
        if (DialogueManager.instance.isInDialogue)
        {
            Time.timeScale = 0;
        }
        if (!DialogueManager.instance.isInDialogue)
        {
            //dialogue.ClearBackground();
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = false;
            DialogueManager.instance.EndDialogue();
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
   
}