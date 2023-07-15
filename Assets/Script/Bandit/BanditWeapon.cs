using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditWeapon : MonoBehaviour
{

    //public
    public MoveBandit mB;
    private float range = 1.25f;


    void Update()
    {
      transform.eulerAngles = new Vector3(0, 0, mB.angle);
      transform.position = transform.parent.position;
      transform.position -= new Vector3(0, 0.1f, 0);
      transform.position += new Vector3(mB.dir.x*0.15f, mB.dir.y*0.15f, 0);

      if (mB.dir.x < 0)
          GetComponent<SpriteRenderer>().flipY = true;
      else
          GetComponent<SpriteRenderer>().flipY = false;

      if (mB.dir.y > 0)
      {
        GetComponent<SpriteRenderer>().sortingOrder = 1;
      }
      else
          GetComponent<SpriteRenderer>().sortingOrder = 3;
    }
}
