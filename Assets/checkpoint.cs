using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private CheckpointMaster cm;

    private void Start()
    {
        cm = GameObject.Find("CheckpointMaster").GetComponent<CheckpointMaster>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cm.lastCheckPos = transform.position;
            cm.checkScene = this.gameObject.scene.name;
        }
    }
}
