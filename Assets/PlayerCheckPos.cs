using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckPos : MonoBehaviour
{

    private CheckpointMaster cm;

     void Start()
    {
        cm = GameObject.Find("CheckpointMaster").GetComponent<CheckpointMaster>();
        transform.position = cm.lastCheckPos;
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
