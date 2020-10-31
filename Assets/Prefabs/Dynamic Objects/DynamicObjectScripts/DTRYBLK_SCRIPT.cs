using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DTRYBLK_SCRIPT: MonoBehaviour
{



   void OnTriggerEnter2D(Collider2D collision)
    {
        //Fireball destroys the brick
        if (collision.gameObject.CompareTag("Fireball"))
        { 
            Destroy(gameObject);
        }
    }

}