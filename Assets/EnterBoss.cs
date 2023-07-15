using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBoss : MonoBehaviour
{
    //private bool BossFight = false;

    private GameObject player;
    private PlayerWalk walk;
    private PlayerDash dash;
    //private PlayerHeart playerHeart;
    private HeartCtrl heart;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        walk = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWalk>();
        dash = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDash>();
        //playerHeart = player.GetComponent<PlayerHeart>();
        heart = player.GetComponent<HeartCtrl>();

        //player.transform.position = new Vector3(-2, 1, 0);
        
        walk.enabled = !walk.enabled;

        dash.enabled = !dash.enabled;

        heart.enabled = !heart.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            BossFight = true;
    }*/
}
