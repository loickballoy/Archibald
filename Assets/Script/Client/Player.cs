using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public GameObject playerCamera;

    public Text gamerTag;

    private void Awake()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
            gamerTag.text = PhotonNetwork.playerName;
        }
        else
        {
            ///gamerTag.text = photonView.owner.name;
            gamerTag.color = Color.green;
        }
    }
}
