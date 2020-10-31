using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWD_SCRIPT : MonoBehaviour
{
    public PLAYER_SCRIPT player;
    //gets the sword prefab
    public GameObject swordPrefab;
    //spawns the sword
    public GameObject SwordSpawn;

    //makes the sword script static
    public static SWD_SCRIPT midslash;
    //the fire bool
    public bool slash = false;



     void Awake()
    {
        midslash = this;
    }



    // Update is called once per frame
    void Update()
    {
        handleMovement();

    }
    void handleMovement()


    {
        //makes sword face right
        if (player.isLeft == false)
        {
           SwordSpawn.transform.localPosition = new Vector3(-2.47f, 2.11f, 0);

        }
        //makes sword face left
        else if (player.isLeft == true)
        {
            SwordSpawn.transform.localPosition = new Vector3(-.97f, 2.11f, 0);

        }




    }
    public void MIDFire()
    {
      
            //have a bullet
            GameObject blade;

            Debug.Log("normalShot");

            //make a bullet
            blade = (Instantiate(swordPrefab, SwordSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force
            blade.GetComponent<Rigidbody2D>().MovePosition(SwordSpawn.transform.position);

        //destroy after 0.10 seconds
        Destroy(blade, .10f) ;
        //makes slash equal true
        slash = true;
        
    }





}
