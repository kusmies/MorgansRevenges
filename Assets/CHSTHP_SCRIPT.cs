using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHSTHP_SCRIPT : MonoBehaviour
{
    public Transform spawn;

    //animator
    Animator myAnimator;
    public GameObject GoldCoin;
    public GameObject CoinBag;
    public GameObject GoldBar;
    // Start is called before the first frame update

    bool isdead;
    bool lootonce;

    public int lootdrop;
    public int dropchance;


    //objects hp
    public int ItemHealth;


    void Start()
    {

        dropchance = Random.Range(1, 2);
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


    void LootDead()
    {

        //sets the animator dead to true when hp =0
        if (ItemHealth <= 0)
        {



            isdead = true;


        }
    }

    void objectdrop()
    {
        if (isdead == true)
        {
            lootonce = true;
            if (lootonce == true)
            {
                lootonce = false;
                Debug.Log("hi tim");


                if (dropchance == 1)
                {
                    //when the player collides with a test dummy drop an object from 1 to 7
                    if (lootdrop >= 1 && lootdrop < 51)
                    {
                        GameObject drop7;

                        drop7 = (Instantiate(GoldCoin, spawn.transform.position, transform.rotation)) as GameObject;
                        drop7.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                    }
            


                    if (lootdrop >= 51)
                    {
                        GameObject drop6;
                        drop6 = (Instantiate(CoinBag, spawn.transform.position, transform.rotation)) as GameObject;
                        drop6.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                    }
                  
                }
                else
                {


                }
                //destroys to only spawn one object
                myAnimator.SetBool("Dead", true);



                //resets the drop range for the item drop


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
        //hazards damage the player
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            ItemHealth -= damage.Damage;
        }
    }

}
