using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
   /* Petit paragraphe a lire pour comprendre le script,
    d'abord il y a la method Ontrigger qui permet d'activer la suite si quelque chose est rentrer en contact avec lobjet.
    ensuie on regarde si l'objet rencontré est le player et si le compteru sers a faire ce script qu'une fois.
     L28 on ajoute a l'inventaire l'arme.
     L29 on recuperer le tabeau d'objet situer dans dontdestroyonLoad 
     L30 on regarde si la place 7 (reserver aux armes) est libre 
     L31 si elle est libre on ajoute l'arme en place 7
     L32 sinon
     L33 on ajoute l'arme en place 8
     L34 On recuperer la method AddDontDestroy situé dans DontDestroyOnLoad pour ajouter l'arme au la liste des DontDestroy
     L35 On recuprer le script de l'arme et on dit a l'arme qu'elle est prise par le joueur
     L36 On f en sorte que l'arme ne soit plus visible mais encore dans le jeux
     L37 on enlever le compteur*/
    
    
    
    public int compteur = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && compteur == 1)
        {
            Inventory.instance.AddWeapons(gameObject);
            transform.SetParent(collider.transform.GetChild(0).transform);
            //gameObject.GetComponent<BolterMovement>().isKeep = true;
            gameObject.SetActive(false);
            compteur--;
        }
    }
}
