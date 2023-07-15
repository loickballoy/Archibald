using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    FinishedTurn,
    Won,
    Lost,
}

public class TurnHandle : MonoBehaviour
{
    public BattleState state;

    private float timer = 0f;
    private float startTimer = 0f;
    public float turnTime = 15f;
    public float startTime = 15f;

    public EnemyProfile[] enemiesInBattle;
    private bool enemyActed;
    private GameObject[] enemyAtks;
    //public GameObject deathCanvas;

    //public GameObject playerUI;
    private GameObject player;
    private HeartCtrl playerHeart;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        enemyActed = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHeart = player.GetComponent<HeartCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BattleState.Start)
        {
            //playerUI.SetActive(true);
            playerHeart.SetHeart();

            if (player.GetComponent<PlayerWeapon>().enabled)
                player.GetComponent<PlayerWeapon>().enabled = !player.GetComponent<PlayerWeapon>().enabled;
            if (player.GetComponent<PlayerShot>().enabled)
                player.GetComponent<PlayerShot>().enabled = !player.GetComponent<PlayerShot>().enabled;

            

            state = BattleState.PlayerTurn;
        }

        else if (state == BattleState.PlayerTurn)
        {
            //playerHeart.SetHeart();
            PlayerAct();
            timer += Time.deltaTime;
            if(timer > turnTime)
            {
                timer = 0;
                PlayerFinishedTurn();
            }
                
        }
        else if (state == BattleState.EnemyTurn)
        {
            if (enemiesInBattle.Length <= 0)
                EnemyFinishedTurn();

            else
            {
                if (!enemyActed)
                {
                    playerHeart.gameObject.SetActive(true);
                    //playerHeart.SetHeart();

                    foreach (EnemyProfile emy in enemiesInBattle)
                    {
                        int atkNumb = Random.Range(0, emy.EnemiesAttacks.Length);
                        Instantiate(emy.EnemiesAttacks[atkNumb], new Vector3(16, 2, 0), Quaternion.identity);
                    }

                    enemyAtks = GameObject.FindGameObjectsWithTag("Ennemy");
                    enemyActed = true;
                }
                else
                {
                    bool enemyfin = true;
                    foreach (GameObject emy in enemyAtks)
                    {
                        if (!emy.GetComponent<EnemyTurnHandle>().finishedTurn)
                        {
                            enemyfin = false;
                        }
                    }

                    if (enemyfin)
                    {
                        EnemyFinishedTurn();
                    }
                }

            }
        }
        else if (state == BattleState.FinishedTurn)
        {
            //playerHeart.gameObject.SetActive(false);

            bool hasWon = false;

            GameObject obj = GameObject.Find("Boss");
            hasWon = obj == null || obj.GetComponent<BossTakeDmg>().Hp <= 0;


            if (playerHeart.GetComponent<PlayerHealth>().currentHealth < 0)
            {
                //deathCanvas.SetActive(true);
                state = BattleState.Lost;
            }

            else if (!hasWon)
            {
                
                state = BattleState.Start;
            }

            else if (hasWon)
                state = BattleState.Won;
            
            

        }
        else if (state == BattleState.Won)
        {
            playerHeart.SetHeart();
            Debug.Log("you have won");
            FinishBoss();
        }

        else if (state == BattleState.Lost)
        {
            FinishBoss();
        }


    }

    public void PlayerAct()
    {
        if(!player.GetComponent<PlayerWeapon>().enabled)
            player.GetComponent<PlayerWeapon>().enabled = !player.GetComponent<PlayerWeapon>().enabled;
        if (!player.GetComponent<PlayerShot>().enabled)
            player.GetComponent<PlayerShot>().enabled = !player.GetComponent<PlayerShot>().enabled;
        
    }

    public void PlayerFinishedTurn()
    {
        if (player.GetComponent<PlayerWeapon>().enabled)
            player.GetComponent<PlayerWeapon>().enabled = !player.GetComponent<PlayerWeapon>().enabled;
        if (player.GetComponent<PlayerShot>().enabled)
            player.GetComponent<PlayerShot>().enabled = !player.GetComponent<PlayerShot>().enabled;

        state = BattleState.EnemyTurn;
    }

    public void EnemyFinishedTurn()
    {
        foreach (GameObject obj in enemyAtks)
        {
            Destroy(obj);
        }

        enemyActed = false;
        state = BattleState.FinishedTurn;
    }

    public void FinishBoss()
    {
        Destroy(GameObject.Find("Boss"));

        player = GameObject.FindGameObjectWithTag("Player");

        PlayerWalk walk = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWalk>();
        PlayerDash dash = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDash>();

        if (!player.GetComponent<PlayerWeapon>().enabled)
            player.GetComponent<PlayerWeapon>().enabled = !player.GetComponent<PlayerWeapon>().enabled;
        if (!player.GetComponent<PlayerShot>().enabled)
            player.GetComponent<PlayerShot>().enabled = !player.GetComponent<PlayerShot>().enabled;

        //PlayerHeart playerHeart = player.GetComponent<PlayerHeart>();
        HeartCtrl heart = player.GetComponent<HeartCtrl>();

        //player.transform.position = new Vector3(-2, 1, 0);

        walk.enabled = !walk.enabled;

        dash.enabled = !dash.enabled;

        heart.enabled = !heart.enabled;

        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
    }
}
