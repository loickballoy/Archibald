using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public AudioClip sound;
    public Image SpriteHolder;
    public Text NpcNameText;
    public Text dialogueText;

    public bool isInDialogue { get; private set; }

    public Animator animator;

    private Queue<string> sentences;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }

        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        SpriteHolder.sprite = dialogue.CharachterSprite;
        
        animator.SetBool("IsOpen", true);
        //dialogue.BlurrBackground();
        isInDialogue = true;
        NpcNameText.text = dialogue.NpcName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            DialogueSoundManager.instance.PlaySound(sound);
            yield return new WaitForSeconds(0.035f);
        }
    }

    public void EndDialogue()
    {
        isInDialogue = false;

        animator.SetBool("IsOpen", false);
    }
}