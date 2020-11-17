using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHSTHP_SCRIPT : MonoBehaviour
{
    public Transform spawn;
    public GameObject explosionEffect;

    //animator
    Animator myAnimator;
    public GameObject SteelShield;
    public GameObject SteelHelm;
    public GameObject BronzeRing;
    public GameObject SilverRing;
    public GameObject GoldBag;


    // Start is called before the first frame update
    bool spawnonce;
    bool isdead;
    bool lootonce;

  

    public int lootdrop;



    //objects hp
    public int ItemHealth;


    void Start()
    {
        XMLManager.ins.LoadItems();


        lootdrop = Random.Range(1, 100);

        //getting the animator
        myAnimator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        // objectdrop();
        LootDead();
        objectdrop();
    }

    void SpawnExplosion()
    {

        GameObject Explosion;
        Explosion = (Instantiate(explosionEffect, spawn.transform.position, spawn.transform.rotation)) as GameObject;

        Destroy(gameObject);
    }

    void LootDead()
    {

        //sets the animator dead to true when hp =0
        if (ItemHealth <= 0)
        {



            isdead = true;
            XMLManager.ins.LoadItems();


        }
    }

    void objectdrop()
    {


        //determines if the object died
        if (isdead == true)
        {
            //determines if the loot was already grabbed
            lootonce = true;
            if (lootonce == true)
            {

                //sets it to true immediately so one things dropped
                lootonce = false;


                foreach (ItemEntry item in XMLManager.ins.itemDB.list)
                {



                    //drops the steelshield if its never been picked up before and rolls 1 thru 25
                    if (lootdrop >= 1 && lootdrop < 26 )
                        {
                        if (item.got == false)
                        {


                            if (spawnonce == false)
                            {


                                spawnonce = true;

                                //creates the steelshield
                                SteelShield = (Instantiate(SteelShield, spawn.transform.position, transform.rotation)) as GameObject;

                            }
                        }
                        else if (spawnonce == false)
                        {
                            spawnonce = true;
                            GoldBag = (Instantiate(GoldBag, spawn.transform.position, transform.rotation)) as GameObject;
                        }
                    }



                        //drops the steel helm if its never been picked up before and rolls 26 thru 50
                        else if (lootdrop >= 26 && lootdrop < 51 )
                        {
                            if (item.got == false)
                            {

                                if (spawnonce == false)
                            {
                             
                                    spawnonce = true;

                                    //creates the steelhelmet
                                    SteelHelm = (Instantiate(SteelHelm, spawn.transform.position, transform.rotation)) as GameObject;
                                }
                               
                            }
                        else if (spawnonce == false)
                        {
                            spawnonce = true;
                            GoldBag = (Instantiate(GoldBag, spawn.transform.position, transform.rotation)) as GameObject;
                        }
                    }
                        //drops the bronze ring if its never been picked up before and rolls 51 thru 75
                        else if (lootdrop >= 51 && lootdrop < 76 )
                        {
                            if (item.got == false)
                            {
                                if (spawnonce == false)
                            {
                                spawnonce = true;
                              
                                    spawnonce = true;

                                    //creates the bronze ring
                                    BronzeRing = (Instantiate(BronzeRing, spawn.transform.position, transform.rotation)) as GameObject;
                                }
                             
                            }
                        else if (spawnonce == false)
                        {
                            spawnonce = true;
                            GoldBag = (Instantiate(GoldBag, spawn.transform.position, transform.rotation)) as GameObject;
                        }

                    }

                        //drops the silver ring if its never been picked up before and rolls 76 through 100
                        else if (lootdrop >= 76 && lootdrop < 101 )
                        {
                            if (item.got == false)
                            {
                                if (spawnonce == false)
                            {
                              
                                    spawnonce = true;

                                    SilverRing = (Instantiate(SilverRing, spawn.transform.position, transform.rotation)) as GameObject;

                                    

                                }
                               
                            }
                        else if (spawnonce == false)
                        {
                            spawnonce = true;
                            GoldBag = (Instantiate(GoldBag, spawn.transform.position, transform.rotation)) as GameObject;
                        }


                    }
                        //causes the default sub item to be dropped
                        else
                        {
                            if (spawnonce == false)
                            {
                                spawnonce = true;
                                GoldBag = (Instantiate(GoldBag, spawn.transform.position, transform.rotation)) as GameObject;
                            }
                        }
                        //destroys to only spawn one object
                        myAnimator.SetBool("Dead", true);



                        //resets the drop range for the item drop
                    }
                }

                
            }
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {


            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

            ItemHealth -= damage.Damage;



        }
        //fireball damages the barrel
        else if (collision.gameObject.CompareTag("Fireball"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

            ItemHealth -= damage.Damage;
        }
        //hazards damage the player
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            ItemHealth -= damage.Damage;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player attacks damage the object
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {


            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

            ItemHealth -= damage.Damage;



        }
        //fireball damages the barrel
        else if (collision.gameObject.CompareTag("Fireball"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

            ItemHealth -= damage.Damage;
        }
        //hazards damage the player
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            ItemHealth -= damage.Damage;
        }
    }

}
