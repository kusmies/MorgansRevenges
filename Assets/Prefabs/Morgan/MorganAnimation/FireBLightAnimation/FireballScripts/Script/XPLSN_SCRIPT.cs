﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPLSN_SCRIPT: MonoBehaviour
{
    //variables for the explosion spawnning
    public GameObject ExplosionPrefab;
    public GameObject ExplosionSpawn;
    //variables for the timer
    public float timer;
    public float timerTarget;

    POWER_SCRIPT powerScript;
    // Start is called before the first frame update
    void Start()
    {
        timerTarget = 0.8f;

        powerScript = GetComponent<POWER_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
        //how timer goes up
        timer += Time.deltaTime;


        //triggers to explode if timer reaches timer target
        if (timer >= timerTarget)
        {
            //have a bullet
            GameObject Explosion;


            //make a bullet
            Explosion = (Instantiate(ExplosionPrefab, ExplosionSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force
            Explosion.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));

            //destroy after 0.8f seconds
            Destroy(Explosion, 0.8f);
            timer = 0.0f;
        }


    }


    
    //triggers early if it hits an enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);
            GameObject Explosion;

            Debug.Log("normalShot");

            //make a bullet
            Explosion = (Instantiate(ExplosionPrefab, ExplosionSpawn.transform.position, transform.rotation)) as GameObject;


            //destroy after 0.8f seconds
            Destroy(Explosion, 0.8f);
        }
         if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);

            GameObject Explosion;

            //make a bullet
            Explosion = (Instantiate(ExplosionPrefab, ExplosionSpawn.transform.position, transform.rotation)) as GameObject;


            //destroy after 0.8 seconds
            Destroy(Explosion, 0.8f);
        }

         if (collision.gameObject.CompareTag("Loot"))
        {
            Destroy(gameObject);

            GameObject Explosion;

            Debug.Log("normalShot");

            //make a bullet
            Explosion = (Instantiate(ExplosionPrefab, ExplosionSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force

            //destroy after 0.8 seconds
            Destroy(Explosion, 0.8f);
        }
    }

}
