using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditShot : MonoBehaviour
{
    public Transform shotPrefab;

    public float cooldown;
    public float timeleft;
    
    void Start()
    {
        timeleft = cooldown;
    }

    void Update()
    {
        Timer();
        if (timeleft <= 0 && this.GetComponent<MoveBandit>().target != this.GetComponent<MoveBandit>().waypoints[0] && this.GetComponent<MoveBandit>().target != this.GetComponent<MoveBandit>().waypoints[1])
            Attack();
    }

    public void Timer ()
    {
        if (timeleft >= 0)
            timeleft -= Time.deltaTime;
    }

    


    public void Attack()
    {
        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        timeleft = cooldown;
    }
}
