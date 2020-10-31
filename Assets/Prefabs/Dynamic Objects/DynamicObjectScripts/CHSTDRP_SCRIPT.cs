using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHSTDRP_SCRIPT : MonoBehaviour
{
    //chest  spawn spot
    public Transform spawn;


    //gold prefabs
    public GameObject GoldCoin;
    public GameObject CoinBag;

    //death script
    public DETHSPWN_SCRIPT drop;

    //gold amount
    public int goldAmount;

    // Start is called before the first frame update
    void Start()
    {
        //references the death spawn
        drop = GetComponent<DETHSPWN_SCRIPT>();

        //the amount of gold range
        goldAmount = Random.Range(1, 2);

    }

    // Update is called once per frame
    void Update()
    {
        LootDrop();

    }

    void LootDrop()
    {

        //if deaths true this is called
        if (drop.itemdrop == true)
        {
            // Debug.Log("hi tim");

            //selects the value
            goldAmount = Random.Range(1, 2);

           //sets the death to false after spawning once
            drop.itemdrop = false;
            //when the player collides with a test dummy drop an object from 1 to 7


            //spawns the gold coin if amount equals 1
            if (goldAmount == 1)
            {
                GameObject drop1;
                
                drop1 = (Instantiate(GoldCoin, spawn.transform.position, transform.rotation)) as GameObject;
                drop1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
           
            //spawns the coin bag if amount equals 2
            if (goldAmount == 2)
            {
                GameObject drop4;
                drop4 = (Instantiate(CoinBag, spawn.transform.position, transform.rotation)) as GameObject;
                drop4.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

            }
        }
    }
}
