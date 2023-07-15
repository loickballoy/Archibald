using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointMaster : MonoBehaviour
{
    private static CheckpointMaster instance;
    public GameObject player;
    public Vector2 lastCheckPos;
    public string checkScene;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(checkScene);
        GameObject.Find("Player").transform.position = lastCheckPos;
        GameObject.Find("Player").GetComponent<PlayerHealth>().currentHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().maxHealth;
        GameObject.Find("Player").GetComponent<PlayerHealth>().healthBar.SetHealth(GameObject.Find("Player").GetComponent<PlayerHealth>().currentHealth);

        if (!player.GetComponent<PlayerWeapon>().enabled)
            player.GetComponent<PlayerWeapon>().enabled = !player.GetComponent<PlayerWeapon>().enabled;
        if (!player.GetComponent<PlayerShot>().enabled)
            player.GetComponent<PlayerShot>().enabled = !player.GetComponent<PlayerShot>().enabled;
        if(!player.GetComponent<PlayerWalk>().enabled)
            player.GetComponent<PlayerWalk>().enabled = !player.GetComponent<PlayerWalk>().enabled;
        if(player.GetComponent<HeartCtrl>().enabled)
            player.GetComponent<HeartCtrl>().enabled = !player.GetComponent<HeartCtrl>().enabled;
        if(!player.GetComponent<PlayerDash>().enabled)
            player.GetComponent<PlayerDash>().enabled = !player.GetComponent<PlayerDash>().enabled;

        GameObject.FindGameObjectWithTag("deathCanvas").SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Destroy(GameObject.FindGameObjectWithTag("DontDestroy"));
        GameObject.FindGameObjectWithTag("deathCanvas").SetActive(false);
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }
    
}
