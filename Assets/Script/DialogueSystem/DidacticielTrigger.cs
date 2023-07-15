using UnityEngine;
using UnityEngine.UI;

public class DidacticielTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private bool isInRange;
    void Update()
    {
        if (isInRange)
        {
            TriggerDialogue();
        }
        else if (DialogueManager.instance.isInDialogue)
        {
            dialogue.FreezePlayer();
        }
        else if (!DialogueManager.instance.isInDialogue)
        {
            //dialogue.ClearBackground();
            dialogue.UnfreezePlayer();
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