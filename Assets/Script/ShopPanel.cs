using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public Game game;
    public Sprite[] images;
    public SpriteRenderer sR;


    
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        sR.sprite = images[System.Convert.ToInt32(game.turboBool)];
    }
}
