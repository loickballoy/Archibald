using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] objects;

    void Awake()
    {
        foreach (GameObject objet in objects)
        {
            DontDestroyOnLoad(objet);
        }
    }
}
