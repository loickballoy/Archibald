using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public Sprite CharachterSprite;

    public void FreezePlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWalk>().enabled = false;
    }

    public void UnfreezePlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWalk>().enabled = true;
    }

    public void BlurrBackground()
    {
        GameObject.FindGameObjectWithTag("DarkPanel").GetComponent<Image>().enabled = true;
    }

    public void ClearBackground()
    {
        GameObject.FindGameObjectWithTag("DarkPanel").GetComponent<Image>().enabled = false;
    }

    public string NpcName;

    [TextArea(3, 10)]
    public string[] sentences;
}