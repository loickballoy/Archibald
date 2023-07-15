using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepIn : MonoBehaviour
{
    public BoxCollider2D bc;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = Vector3.zero;
        }
        
    }
}
