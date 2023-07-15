using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossShot : MonoBehaviour
{

    public Transform shotPrefab;
    public Transform shotPrefabPlasma;
    public GameObject player;

    public float cooldown;
    public float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        timeleft = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if (Input.GetKey(KeyCode.R) && timeleft <= 0)
            Attack();
    }

    private void Timer()
    {
        if (timeleft >= 0)
            timeleft -= Time.deltaTime;
    }

    private void Attack()
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        timeleft = cooldown;
    }
}
