using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTakeDmg : MonoBehaviour
{
    public EnemyProfile boss;
    public CapsuleCollider2D cc;
    public GameObject bossObj;
    public int playerDmg;
    private bool takesDmg;

    private int maxHp;
    [SerializeField] public int Hp;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHp = boss.Hp;
        Hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (takesDmg)
        {
            TakeDamage();
        }
        if (Hp <= 0)
        {
            GameObject.Find("BossSprite").GetComponent<SpriteRenderer>().enabled = !GameObject.Find("BossSprite").GetComponent<SpriteRenderer>().enabled;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        takesDmg = true;
        Destroy(collision.gameObject);
    }

    public void TakeDamage()
    {
        Hp -= playerDmg;
        takesDmg = false;
    }
}
