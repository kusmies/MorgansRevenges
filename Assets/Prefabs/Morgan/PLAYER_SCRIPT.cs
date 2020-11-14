﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PLAYER_SCRIPT : MonoBehaviour
{
    Vector3 pushDirection;

    //gets rigid body
    public Rigidbody2D rb;
    //knockback bool
    public bool knockBack;
    //thrust force added
    public float upwardThrust;
    public float directionatalthrust;
    public GameObject swordPrefab;
    public GameObject SwordSpawn;
    //spawns the sword
    public GameObject lowSwordSpawn;
    public bool slash = false;

    public bool shoot;
    GameObject fireball;

    public GameObject FireballPrefab;

    //spawn point for the fireball
    public GameObject FireballSpawn;
    //hp bar
    public Slider Hp;
    public Slider Mp;

    public float health;
    public float mana;
    public bool shldfls;
   public bool hlmfls;
    public bool brnzfls;
    public bool silvfls;
    //loads the level the players in
    public CHASEN_SCRIPT level;
    public bool castingfireball;
    //int for fireball unlock
    public int fireunlock;
    //the players rigid body
    Rigidbody2D myBody;
    //the knockback script
    KNCKBCK_SCRIPT struck;
    //displays the coin value
   public Text coinvalue;
    public bool highslash;
    public bool lowslash;
    public float thrust;


    Vector3 dir1;
    public int soul;
    public static int spirit;
    //jump box collider
    public BoxCollider2D myBox;
    //checks the sprite renderer
    SpriteRenderer mySprite;
    //players ground layer
    [SerializeField] public LayerMask groundLayer;
    //the coin int
    public float coin;
    //invunerable timer ticks up
    public float invulnertimer;
    //target for the invunerable timer to equal
    public float invulnertarget;
    //bool for players invincibility
    public bool midslash;
    public bool crouch;
    public bool invicibility;
    //bool for players death
    public bool death;
    // how long it takes the player to actually die
    public float deathtimer;
    //the target the death timer equals
    public float deathtimertarget;
    //checks for ground
    public bool isGrounded;
    //checks if moving
    public bool isMoving;
    //checks if facing left
    public bool isLeft;
    //jump height
    public float jumpforce;
    //inital speed
    public float speedforce;
    //additional speed
    public float bonusspeed;
    // Start is called before the first frame update

   
    void Start()
    {
        Load();

        rb = this.GetComponent<Rigidbody2D>();
        mana = Mp.value;
        health = Hp.value;
        isLeft = false;
        //death timer target
        deathtimertarget = 5.0f;
        //invunerability timer target
        invulnertarget = 0.0f;
        //invunerability timer start
        invulnertimer = 0.0f;
        //how rigid bodys obtained
        myBody = GetComponent<Rigidbody2D>();       
        //how the sprites transfer
        mySprite = GetComponent<SpriteRenderer>();
        //how knockbacks obtained
        struck = GetComponent<KNCKBCK_SCRIPT>();

    }


    public void Load()
    {
        float[] loadedStats = SaveLoadManager.LoadPlayer();

        health = loadedStats[0];
        mana = loadedStats[1];
        coin = loadedStats[2];
    }
    // Update is called once per frame

    void Update()
    {
        knocked();


        coinvalue.text = coin.ToString();

        if (!death)
        {
            checkForGround();
      
            handleMovement();
        }

        Dead();
        invulerability(); 
    }
    //checks if the players on the ground


    public void CastFireball()
    {
        if (mana >= 1)
        {
            //sets the shoot equal to true
            shoot = true;
            Mp.value--;
            mana --;

            //have a bullet

            Debug.Log("normalShot");


            //makes a bullet
            fireball = (Instantiate(FireballPrefab, FireballSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force to right

            if (isLeft == true)
            {
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
            }
            //give it force to left

            if (isLeft == false)
            {
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
            }
            //destroy after 1 second
            Destroy(fireball, 1.0f);

        }
    }
    void checkForGround()
    {
        if (Input.GetKey(KeyCode.K) && isGrounded == false)
        {


            highslash = true;
        }
        //checking for ground
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            //ground is true
            isGrounded = true;
            highslash = false;

        }

        else
        {
          

            //ground is fale
            isGrounded = false;
        }
    }
    //handles the movement
    void handleMovement()

    {
        if (Input.GetKeyDown(KeyCode.K)&& crouch ==true)
        {

            lowslash = true;
        }

        if (!Input.GetKeyDown(KeyCode.K) && crouch == true)
        {

            lowslash = false;
        }
        //left is true
        if (/*Input.GetAxis("Horizontal")> 0*/ Input.GetKey(KeyCode.D)  && !Input.GetKey(KeyCode.S))
        {
            if(Input.GetKeyDown(KeyCode.K))
            {


                midslash = true;
            }
            if (!Input.GetKeyDown(KeyCode.K))

            { midslash = false;

            }
            myBody.velocity = new Vector2(+speedforce + bonusspeed, myBody.velocity.y);
            mySprite.flipX = true;
            isMoving = true;
            isLeft = true;
            crouch = false;


        }
        else  if (Input.GetKey(KeyCode.S)/*&& Input.GetAxis("Horizontal") == 0*/)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                lowslash = true;
            }

            if (Input.GetKeyUp(KeyCode.K))
            {

                lowslash = false;
            }
            myBody.velocity = new Vector2(0, myBody.velocity.y);

            crouch = true;
            isMoving = false;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
            lowslash = false;
        }
        else
        {
            //right is true
            if (/*Input.GetAxis("Horizontal") < 0*/ Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
            {
                myBody.velocity = new Vector2(-speedforce - bonusspeed, myBody.velocity.y);
                mySprite.flipX = false;
                isMoving = true;
                isLeft = false;
                crouch = false;

                if (Input.GetKeyDown(KeyCode.K))
                {

                    midslash = true;
                }
                if (!Input.GetKeyDown(KeyCode.K))

                {
                    midslash = false;

                }


            }
            //standing still
            else
            {
                isMoving = false;

                myBody.velocity = new Vector2(0, myBody.velocity.y);

                if (Input.GetKeyDown(KeyCode.K)&& crouch ==false)
                {


                    midslash = true;
                }
                if (!Input.GetKeyDown(KeyCode.K))

                {
                    midslash = false;

                }
            }
        }

        //jump is true
        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);
            isMoving = false;
           
        }


        //stops player when O is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            castingfireball = true;
            speedforce = 0;
        }
        //stop when O is released
        if (!Input.GetKey(KeyCode.O))
        {
            castingfireball = false;
            speedforce = 20;
        }




    }
    public void setHp(float newvalue)
    {
         health =newvalue;

    }
    public void setMp(float newvalue)
    {
        mana=newvalue;

    }
    void invulerability()
    {
        //makes invincibility happen when true
        if(invicibility == true)
        {

            invulnertimer -= Time.deltaTime;
            mySprite.color = new Color32(255, 0, 0, 255);

            Debug.Log(invulnertimer);
            if (invulnertimer <= invulnertarget)
            {
                mySprite.color = new Color32(255, 255, 255, 255);

                invicibility = false;
                invulnertimer = 0.0f;

            }
        }

     

    }

    void knocked()
    {
        //makes knockback happen when equal true
        if (knockBack == true)
        {
            knockBack = false;
            //if intfont of player make - thrust if behind player make thrust

            rb.AddForce(pushDirection * 100);
            //rb.AddForce(transform.up * upwardThrust);
        }

    }
    void Dead()
    {
        foreach (ItemEntry item in XMLManager.ins.itemDB.list)
        {
            //kills out of bound
            if (myBody.position.y < -20)
            {
                death = true;
            }

            //kills at 0
            if (Hp.value <= 0)
            {

                death = true;

            }

            //plays animation when death equals true
            if (death == true)
            {
                deathtimer += Time.deltaTime;
            }

            if (deathtimer >= deathtimertarget)
            {

                item.got = false;
                XMLManager.ins.SaveItems();

                level.changeScene(4);
            }
        }
    }
    public void Slash()
    {

        //have a bullet
        GameObject blade;

        Debug.Log("normalShot");

        //make a bullet
        blade = (Instantiate(swordPrefab, SwordSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force
        blade.GetComponent<Rigidbody2D>().MovePosition(SwordSpawn.transform.position);

        //destroy after 0.10 seconds
        Destroy(blade, .10f);
        //makes slash equal true

    }
    public void lowSlash()
    {




        //have a bullet
        GameObject blade;



        //make a bullet
        blade = (Instantiate(swordPrefab, lowSwordSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force
        blade.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

        //destroy after 0.25 seconds
        Destroy(blade, 0.25f);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        //gives the player a coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin++;

            coinvalue.text = coin + "$";

        }
      
        //adds hp

        else if (collision.gameObject.CompareTag("BSnack"))
        {
            health += 2;
            Hp.value += 2;


        }
        //adds mana
        else if (collision.gameObject.CompareTag("Mvial"))
        {
           mana += 2;
           Mp.value += 2;


        }
        //adds 5 coins
        else if (collision.gameObject.CompareTag("Cbag"))
        {
            coin += 5;

            coinvalue.text = coin + "$";

        }
        //kills on hazard collision
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            health -= damage.Damage;
        }
        //makes enemies do damage
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (invicibility == false)
            {

                var target = collision.transform;
                dir1 = (transform.position - target.position).normalized;
                myBody.AddRelativeForce(dir1 * thrust);
                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
                health -= damage.Damage;
                invicibility = true;
                invulnertimer = 2.0f;



            }


        }


    }
}
