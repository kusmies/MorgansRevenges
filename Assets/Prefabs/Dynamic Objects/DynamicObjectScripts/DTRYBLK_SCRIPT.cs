using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DTRYBLK_SCRIPT : MonoBehaviour
{
    Animator myAnimator;

    public EXPLWAL_SCRIPT parent;

    public bool isDead = false;

    public GameObject explosionEffect;

    public Transform myTran;

    void Start()
    {

        myAnimator = GetComponent<Animator>();


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Fireball destroys the brick
        if (collision.gameObject.CompareTag("Fireball"))
        {
            myAnimator.SetBool("Broke", true);

        }
    }



    void Update()
    {
      

    }

    void SpawnExplosion()
    {

       GameObject Explosion;
       Explosion = (Instantiate(explosionEffect, myTran.transform.position, myTran.transform.rotation)) as GameObject;

        Destroy(gameObject);

    }
}