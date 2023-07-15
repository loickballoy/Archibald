using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public Slider slider;/* Truc qui sert a changer la taille de la bar automoatiquement */

    public Gradient gradient;/* Couleur de la jauge de vie */
    public Image bar;/* Bar de vie */
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void SetMaxStamina(int stamina)/* Utilisé pour set la bar au debut au maximum de vie*/
    {
        slider.maxValue = stamina;
        slider.value = stamina;
        
        bar.color = gradient.Evaluate(1f);
    }

    public void SetStamina(int stamina) /* Utilisé pour changer la bar de vie */
    {
        slider.value = stamina;
        bar.color = gradient.Evaluate(slider.normalizedValue);
    }
}
