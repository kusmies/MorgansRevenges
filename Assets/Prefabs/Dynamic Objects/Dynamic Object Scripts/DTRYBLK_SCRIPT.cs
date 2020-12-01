using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

//By Timothy Phillips
//Copyright November 2020
//This script handles the individual behavior of any given descructible block.
//The assumption here is that we have already linked up with a parent object,
//who has an exploding wall script attached.
//When this object collides with the fireball explosion, it tells the parent to start exploding.
//Then parent then tells all the children to explode, shortly before exploding itself.

public class DTRYBLK_SCRIPT : MonoBehaviour
{
    public EXPLWAL_SCRIPT parent; //We store the parent script here.

    public bool isDead = false; //Whether or not the tile is dead and should explode. This is public so the parent object can access it.

    public GameObject explosionEffect; //When a tile dies, it spawns the prefab explosion effect.

    Transform myTran; //The destructible block transform. We need it to spawn the explosion effect in the right spot.

    void OnTriggerEnter2D(Collider2D collision) //We need to check if the destructible block is being hit by a fireball explosion.
    {
        
        if (collision.gameObject.CompareTag("PlayerAttack")) //If the destructible block collides with a player attack.
        {
            
            var powerScript = collision.gameObject.GetComponent<POWER_SCRIPT>(); //All player attacks have a power script attached. We get that script and store it in a temporary variable.

            if(powerScript.type == 2) //The power script has a public number that indicates what type of attack it is. If that attack type is 2, then the attack is a fireball explosion and we run this if statement.
            {       
                parent.isExploding = true; //We tell the parent that it's time to explode all the children by switching the parent's isExploding bool to true.
            }
        }
    }



    void Update()
    {
      if(isDead)//isDead is only switched to true by the parent object when it is told by another tile to explode.
        {
            GameObject Explosion; //Declare a temporary game object variable.
            Explosion = (Instantiate(explosionEffect, myTran.transform.position, myTran.transform.rotation)) as GameObject; //Spawn an explosion where the block is.

            Destroy(gameObject); //Destroy the block.
        }

    }

}