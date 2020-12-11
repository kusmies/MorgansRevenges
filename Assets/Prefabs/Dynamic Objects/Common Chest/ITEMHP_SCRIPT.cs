using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEMHP_SCRIPT : MonoBehaviour
{
    public Animator ITEM_CONTROL;
    public GameObject explosionEffect;
    public Transform myTran;
  
     void Start()
    {
        ITEM_CONTROL = GetComponent<Animator>();

    }

   public void ObjectDestroy()
    {

        Destroy(gameObject);
    }
   public void spawnExplosion()
    {
        GameObject explosion;

        explosion = Instantiate(explosionEffect, myTran.position, myTran.rotation);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            ITEM_CONTROL.SetBool("Dead", true);






        }
        //fireball damages the barrel
        else if (collision.gameObject.CompareTag("Fireball"))
        {
            ITEM_CONTROL.SetBool("Dead", true);


        }
        //hazards damage the player
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            ITEM_CONTROL.SetBool("Dead", true);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player attacks damage the object
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {



            ITEM_CONTROL.SetBool("Dead", true);


        }
        //fireball damages the barrel
        else if (collision.gameObject.CompareTag("Fireball"))
        {
            ITEM_CONTROL.SetBool("Dead", true);


        }
        //hazards damage the player
        else if (collision.gameObject.CompareTag("Hazard"))
        {
            ITEM_CONTROL.SetBool("Dead", true);

        }
    }

}
