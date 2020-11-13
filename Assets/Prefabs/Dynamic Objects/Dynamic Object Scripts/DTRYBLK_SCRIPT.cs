using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DTRYBLK_SCRIPT : MonoBehaviour
{
    public EXPLWAL_SCRIPT parent;

    public bool isDead = false;

    public GameObject explosionEffect;

    public Transform myTran;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            
            var powerScript = collision.gameObject.GetComponent<POWER_SCRIPT>();

            if(powerScript.type == 2)
            {
                
                parent.isExploding = true;
            }
        }
    }



    void Update()
    {
      if(isDead)
        {
            GameObject Explosion;
            Explosion = (Instantiate(explosionEffect, myTran.transform.position, myTran.transform.rotation)) as GameObject;

            Destroy(gameObject);
        }

    }

}