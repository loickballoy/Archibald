using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackable : MonoBehaviour
{
    public string type;
    public int value = 1;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
          if (type == "coins")
          {
              Inventory.instance.AddCoins(value);
          }
          else if (type == "components")
          {
              Inventory.instance.AddComponents(value);
          }
          else if (type == "stimpack")
          {
              Inventory.instance.AddStimpack(value);
          }
          else if (type == "stimisc")
          {
              Inventory.instance.AddStimisc(value);
          }
          else if (type == "exp")
          {
              Inventory.instance.AddExp(value);
          }
          Destroy(gameObject);
        }
    }
}
