using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class NMYHP_SCRIPT : MonoBehaviour
{
    [SerializeField] public LayerMask groundLayer;
    Rigidbody2D myBody;
    public BoxCollider2D myBox;
    public bool isGrounded = false;
    public float thrust;
    //the enemy spawn
    public Transform spawn;
    //the enemy animator
    Animator myAnimator;
    //invulnerability timer
    public float invulnertimer;
    //invunerability target
    public float invulnertarget;
    //checks for invincibility
    public bool invicibility;
    //dead variable
    public bool isdead;

    //enemys hp
    public int Enemyhealth;
    //knockback script
    KNCKBCK_SCRIPT struck;
    public int lootdrop;
    bool lootonce;
    public int dropchance;

    public GameObject Bsnack;
    public GameObject Bmeal;
    public GameObject Mvial;
    public GameObject Mpotion;
    public GameObject GoldCoin;
    public GameObject CoinBag;
    public GameObject GoldBar;
    public GameObject playeref;
     Vector3 dir1;




    // Start is called before the first frame update
    void Start()
    {
          lootdrop = Random.Range(1, 100);
        dropchance = Random.Range(1, 2);

        //gets animator
        myAnimator = GetComponent<Animator>();

        myBody = GetComponent<Rigidbody2D>();

        //invunerability timer and target
        invulnertarget = 0.0f;
        invulnertimer = 0.0f;
        //knockback script
        struck = GetComponent<KNCKBCK_SCRIPT>();

    }
    void Update()
    {
        //objectdrop();
        invulerability();
        EnemyDead();
        checkForGround();
        objectdrop();
    }
    void checkForGround()
    {
        //checking for ground
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            //ground is true


        }

       

        if (isGrounded == true)
        {
            myBody.velocity = new Vector3(0,0,0);
            myBody.gravityScale = 0;

        }

        else
        {
            myBody.gravityScale = 1;
        }

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {//it detects the player attacks
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            if (invicibility == false)
            {
                invicibility = true;

                invulnertimer = 2.0f;

                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

                Enemyhealth -= damage.Damage;

                var target = collision.transform;
                
                dir1 = (transform.position - target.position).normalized;
                myBody.AddRelativeForce(dir1 * thrust);

             

            }
        }
        if (collision.gameObject.CompareTag("Fireball"))
        {
            if (invicibility == false)
            {
                invicibility = true;

                invulnertimer = 2.0f;

                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
                var target = collision.transform;
                dir1 = (transform.position - target.position).normalized;
                myBody.AddRelativeForce(dir1 * thrust);
                Enemyhealth -= damage.Damage;

            
                Debug.Log(Enemyhealth);

            }


        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

        }
        //it detects the hazard
        if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            Enemyhealth -= damage.Damage;
        }
    }
    
    void invulerability()
    {//invcibility when hit
        if (invicibility == true)
        {

            invulnertimer -= Time.deltaTime;

            Debug.Log(invulnertimer);
            if (invulnertimer <= invulnertarget)
            {
                invicibility = false;
                Debug.Log("invicibilitygone");
                invulnertimer = 0.0f;

            }
        }



    }
    
    //where the enemy code dies
    void EnemyDead() {
        if (Enemyhealth <= 0)
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
                    if (lootdrop >= 51 && lootdrop < 71)
                    {
                        GameObject drop2;

                        drop2 = (Instantiate(Bsnack, spawn.transform.position, transform.rotation)) as GameObject;
                        drop2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                    }
                    if (lootdrop >= 71 && lootdrop < 91)
                    {
                        GameObject drop3;

                        drop3 = (Instantiate(Mvial, spawn.transform.position, transform.rotation)) as GameObject;
                        drop3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                    }


                    if (lootdrop >= 91)
                    {
                        GameObject drop6;
                        drop6 = (Instantiate(CoinBag, spawn.transform.position, transform.rotation)) as GameObject;
                        drop6.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                    }
                    /*

                    if (lootdrop == 5)
                    {
                        GameObject drop4;
                        drop4 = (Instantiate(Mpotion, spawn.transform.position, transform.rotation)) as GameObject;
                        drop4.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                    }

                    if (lootdrop == 6)
                    {
                        GameObject drop5;

                        drop5 = (Instantiate(GoldBar, spawn.transform.position, transform.rotation)) as GameObject;
                        drop5.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

                    }
                    if (lootdrop == 7)
                    {
                        GameObject drop1;

                        drop1 = (Instantiate(Bmeal, spawn.transform.position, transform.rotation)) as GameObject;
                        drop1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));


                    }
                    */
                }
                else
                {


                }
                //destroys to only spawn one object
                myAnimator.SetBool("Death", true);



                //resets the drop range for the item drop


            }
        }
    }
    
}
