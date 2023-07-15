using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DidacticielEnding : MonoBehaviour
{
    public GameObject dontDestroy;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dontDestroy = GameObject.FindGameObjectWithTag("DontDestroy");
    }
    void Update()
    {
        if (this.GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            foreach (GameObject objects in dontDestroy.GetComponent<DontDestroy>().objects)
            {
                Destroy(objects);
            }
            SceneManager.LoadScene("SampleScene");
        }
    }
}
