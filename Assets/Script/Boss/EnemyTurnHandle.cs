using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnHandle : MonoBehaviour
{
    public bool finishedTurn;

    public int attackAmounts;

    public void Start()
    {
        finishedTurn = false;

        int atkNumb = 0;
        GetComponent<Animator>().SetInteger("AtkDex", atkNumb);
    }

    void AtkDone()
    {
        finishedTurn = true;
    }
}
