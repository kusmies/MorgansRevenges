using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DTRYBLK_SCRIPT : MonoBehaviour
{
    public EXPLWAL_SCRIPT parent;

    public bool isDead = false;

    [SerializeField] public GameObject explosionEffect;

    Transform myTran;

    void Start()
    {
        

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Fireball destroys the brick
        if (collision.gameObject.CompareTag("Fireball"))
        {
            parent.isExploding = true;
        }
    }



    void Update()
    {
        if (isDead)
        {
            Instantiate(explosionEffect, myTran.position, myTran.rotation);
            
            Destroy(gameObject);
           
        }

    }


}