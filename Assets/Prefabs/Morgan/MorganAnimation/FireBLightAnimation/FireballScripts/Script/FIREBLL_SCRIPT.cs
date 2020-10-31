using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIREBLL_SCRIPT : MonoBehaviour
{
    //calls the player script for unlock
    public PLAYER_SCRIPT unlock;

    //sets the fireball up for other scripts
    public static FIREBLL_SCRIPT fire;

    //the fireball game object
    GameObject fireball;

    //the true variable
   public bool shoot;

    //prefab for the fireball game object
   public GameObject FireballPrefab;

    //spawn point for the fireball
    public GameObject FireballSpawn;
    
    //checks if the players right
    bool righttrue;
    // Start is called before the first frame update

        
     void Awake()
    {
        //makes the script equal to itself
        fire = this;
    }
  

    // Update is called once per frame
    void Update()
    {

        handleMovement();

       
       

    }
    void handleMovement()

    {
        //sets the point right
        if (unlock.isLeft == false)
        {
            FireballSpawn.transform.localPosition = new Vector3(-2.9f, 0, 0);
            righttrue = true;
        }

        //sets the point left
        else if (unlock.isLeft == true)
        {
            FireballSpawn.transform.localPosition = new Vector3(2.9f, 0, 0);
            righttrue = false;
        }




    }
    public void CastFireball()
    {
        if (MP_SCRIPT.mana.Mp.value >= 1)
        {
            //sets the shoot equal to true
            shoot = true;

            MP_SCRIPT.mana.Mp.value -= 1;

            //have a bullet

            Debug.Log("normalShot");


            //makes a bullet
            fireball = (Instantiate(FireballPrefab, FireballSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force to right

            if (unlock.isLeft == true)
            {
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
            }
            //give it force to left

            if (unlock.isLeft == false)
            {
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
            }
            //destroy after 1 second
            Destroy(fireball, 1.0f);

        }
    }


     
    

   
}
