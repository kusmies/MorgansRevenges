using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGHSWD_SCRIPT: MonoBehaviour
{
    public PLAYER_SCRIPT player;
    //gets the sword prefab
    public GameObject swordPrefab;
    //spawns the sword
    public GameObject SwordSpawn;
    //makes the highsword script static
    public static HGHSWD_SCRIPT HighSlash;
    //makes the fire bool
    public bool highslash = false;

    void Awake()
    {
        HighSlash = this;
    }



    // Update is called once per frame
    void Update()
    {
        handleMovement();



//makes the slash fire when jumps pressed with k
        if (player.isGrounded ==false && Input.GetKeyDown(KeyCode.K))
        {
          //  Fire();
           // highslash = true;

        }

        else
        {
            highslash = false;
        }
    }
    void handleMovement()

    {
        //high slash is right
        if (player.isLeft == false)
        {
           swordPrefab.transform.localPosition = new Vector3(2.7f, 2.1f, 0f);

        }

        //high slash is left
        else if (player.isLeft == true)
        {
            swordPrefab.transform.localPosition = new Vector3(-2.7f, 2.1f, 0f);

        }





    }
   /* void Fire()
    {

       

            Debug.Log("HighSlash");
            //have a bullet
            GameObject blade;



            //make a bullet
            blade = (Instantiate(swordPrefab, SwordSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force
            blade.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

        //destroy after 0.5 seconds
        Destroy(blade, 0.5f);
        

            
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //destroys on enemy collision
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

        }


    }

    }
