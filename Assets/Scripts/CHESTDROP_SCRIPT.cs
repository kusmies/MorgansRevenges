using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHESTDROP_SCRIPT : MonoBehaviour
{
    public Animator ITEM_CONTROL;

    public  CHESTDROP_SCRIPT chestdrop;
    public Transform spawn;
    public GameObject[] items;
    public PLAYER_SCRIPT player;
    public List<int> chestslots = new List<int>();
    public int IDassigner;

    public int ID;

    bool droppedonce;
    void Awake()
    {
        chestdrop = this;
        Roll();

    }

     void Start()
    {
        ID = IDassigner;
        ITEM_CONTROL = GetComponent<Animator>();

    }

    private void Update()
    {
        ID = IDassigner;
    }


    public int Roll()
    { //function to find a job

        

            if (chestslots.Count == 0)
            { //if list is empty
            chestslots.Clear();
            }
            else
            { //if not
                IDassigner = chestslots[Random.Range(0, chestslots.Count)]; //get a random

            }
        chestslots.Remove(IDassigner); //remove from list

        
        return IDassigner;

    }
    public void ObjectDestroy()
    {

        Destroy(gameObject);
    }
    public void Drop()
    {
       
        {
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (ID == item.ID && item.ID == 1)
                {


                    if (item.got == false && item.chestdropped ==false)
                    {




                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();

                        Instantiate(items[0], spawn.transform.position, spawn.transform.rotation);
                      

                        Destroy(gameObject);

                    }
                    else if (item.got == true || item.chestdropped == true)
                    {
                        Roll();

                    }

                }

                if (ID == item.ID && item.ID == 2)
                {



                    if (item.got == false && item.chestdropped == false)
                    {




                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[1], spawn.transform.position, spawn.transform.rotation);
        
                        Destroy(gameObject);



                    }
                    else   if (item.got == true || item.chestdropped == true)
                    {
                        Roll();


                    }

                }
                if (ID == item.ID && item.ID == 3)
                {


                    if (item.got == false && item.chestdropped == false)
                    {




                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[2], spawn.transform.position, spawn.transform.rotation);
                    

                        Destroy(gameObject);

                    }
                    else   if (item.got == true || item.chestdropped == true)
                    {

                        Roll();

                    }

                }
                if (ID == item.ID && item.ID == 4)
                {


                    if (item.got == false && item.chestdropped == false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[3], spawn.transform.position, spawn.transform.rotation);
                    
                        Destroy(gameObject);


                    }
                    else if (item.got == true || item.chestdropped == true)
                    {
                        Roll();

                    }

                }
                if (ID == item.ID && item.ID == 5)
                {


                    if (item.got == false && item.chestdropped == false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[4], spawn.transform.position, spawn.transform.rotation);
                    
                        Destroy(gameObject);


                    }
                    else  if (item.got == true || item.chestdropped == true)
                    {
                        Roll();

                    }

                }
                if (ID == item.ID && item.ID == 6)
                {


                    if (item.got == false && item.chestdropped == false)
                    {




                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[5], spawn.transform.position, spawn.transform.rotation);
                     
                        Destroy(gameObject);


                    }


                    else if(item.got ==true || item.chestdropped ==true)
                    {
                        Roll();


                    }

                }





            }

            if (chestslots.Count == 0)
            {
                Instantiate(items[6], spawn.transform.position, spawn.transform.rotation);
                Destroy(gameObject);
            }


        }
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
