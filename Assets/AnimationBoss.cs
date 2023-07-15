using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoss : MonoBehaviour
{

    private Game game;

    public SpriteRenderer sR;
    public Sprite[] images;

    public bool isCharged;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        sR.sprite = images[System.Convert.ToInt32(game.turboBool) * 2 + System.Convert.ToInt32(isCharged)];
    }
}
