using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerStamina : MonoBehaviour
{
    public PhotonView photonView;

    public int maxStamina;// stamina max variable
    public int currentStamina;// stamina actuelle variable

    private float timeleft;

    private float timer;

    public Staminabar staminaBar;// la bar de stamina

    public int stamina;// les stamina du test 

    public MultiplayerWalk player;


    void Start()// au debut on set la stamina au max 
    {
        timer = 1.2f;
        timeleft = 1.2f;
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
    }


    public void Update()// update a chaque instant
    {

        /*if (player.speed != player.speedrunning)//timeur de recharge de la barre de stamina
            timeleft -= Time.deltaTime;
        if (timeleft < 0 && player.speed != player.speedrunning && currentStamina < maxStamina)//regagne de la stamina
        {
            GainStamina(4);
            timeleft = timer;
        }*/
    }

    public void UseStamina(int staminause)// method pour changer la stamina et la bar de stamina
    {
        if (photonView.isMine)
        {
            currentStamina -= staminause;
            staminaBar.SetStamina(currentStamina);
        }
        
    }

    public void GainStamina(int gain)// method pour changer la stamina et la bar de stamina
    {
        if (photonView.isMine)
        {
            currentStamina += gain;
            staminaBar.SetStamina(currentStamina);
        }
    }
}