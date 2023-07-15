using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClickToKeyPress : MonoBehaviour
{

    Button buttonMe;
    
    void Start()
    {
        buttonMe = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonMe.onClick.Invoke();
        }
        
    }
}

