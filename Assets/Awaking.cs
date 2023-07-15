using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awaking : MonoBehaviour
{

    public GameObject spawn;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
