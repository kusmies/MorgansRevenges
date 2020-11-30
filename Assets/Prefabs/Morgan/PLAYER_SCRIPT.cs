using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.RestService;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class PLAYER_SCRIPT : MonoBehaviour
{
    Vector2 pushDirection;
    //gets rigid body
    public Rigidbody2D rb;
    //knockback bool
    //thrust force added
    public float thrust;
    int ID;
    public int soul;
    public static int spirit;
    //jump height
    public float jumpforce;
    //inital speed
    public float speedforce;
    //additional speed
    public float bonusspeed;

  public float attackCD;
    float barsize = 160;
    //the coin int
    public float coin;
    //invunerable timer ticks up
    public float invulnertimer;
    //target for the invunerable timer to equal
    public float invulnertarget;
    //bool for players invincibility

    // how long it takes the player to actually die
    public float deathtimer;
    //the target the death timer equals
    public float deathtimertarget;
    public float MaxHealth;
    public float CurrentHealth;
    public float MaxMana;
    public float CurrentMana;
 
    public GameObject SwordSpawn;
    public GameObject HighSwordPrefab;
    GameObject fireball;

    public GameObject FireballPrefab;

    //spawn point for the fireball
    public GameObject FireballSpawn;
    //hp bar
    public Slider Hp;
    public Slider Mp;
    //spawns the sword
    public GameObject lowSwordSpawn;
    //checks for ground
    public bool isGrounded;
    //checks if moving
    public bool isMoving;
    //checks if facing left
    public bool knockBack;

    public bool isLeft;
    public bool shoot;
    public bool castingfireball;

    public bool midslash;
    public bool crouch;
    public bool invicibility;
    //bool for players death
    public bool death;
    public bool attackstun;
 
    //loads the level the players in
    public CHASEN_SCRIPT level;
    //int for fireball unlock
    //the players rigid body
    Rigidbody2D myBody;
   
    //displays the coin value
   public Text coinvalue;
   
    
    public SLIDER_SCRIPT slide;
    public SLIDER_SCRIPT slide2;

    Vector2 dir1;

    //jump box collider
    public BoxCollider2D myBox;
    //checks the sprite renderer
    SpriteRenderer mySprite;
    //players ground layer
    [SerializeField] public LayerMask groundLayer;
  

   
    // Start is called before the first frame update

    void Awake()
    {
        slide.SetMaxBar(MaxHealth);
        slide2.SetMaxBar(MaxMana);
        Load();

    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;

        XMLManager.ins.PermLoadItems();
        XMLManager.ins.LoadItems();
        slide.SetMaxBar(MaxHealth);
        slide2.SetMaxBar(MaxMana);
        RectTransform HpSliderRect = Hp.GetComponent<RectTransform>();
        HpSliderRect.sizeDelta = new Vector2(MaxHealth, HpSliderRect.sizeDelta.y);

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
        Load();
    }


    public void Load()
    {
        float[] loadedStats = SaveLoadManager.LoadPlayer();

        MaxHealth = loadedStats[0];
         MaxMana = loadedStats[1];
        coin = loadedStats[2];
    }
    // Update is called once per frame

    void Update()

    {
 
        slide.SetMaxBar(MaxHealth);
        slide2.SetMaxBar(MaxMana);
        slide.SetBar(CurrentHealth);
        slide2.SetBar(CurrentMana);

       


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


    public IEnumerator knockback(float knockDur, float knockbackPwr, Transform obj)
    {
        float timer = 0;

        while (knockDur> timer)
        {
            timer += Time.deltaTime;

            Vector2 direction = new Vector2((obj.transform.position.x - this.transform.position.x), this.transform.position.y);
            rb.AddForce(-direction * knockbackPwr);
        }
        yield return 0;

    }
    public void CastFireball()
    {
        if (CurrentMana >= 1)
        {
            //sets the shoot equal to true
            shoot = true;
            CurrentMana --;
            slide2.SetBar(CurrentMana);
            //have a bullet

            Debug.Log("normalShot");


            //makes a bullet
            fireball = (Instantiate(FireballPrefab, FireballSpawn.transform.position, transform.rotation)) as GameObject;

            //give it force to right

            if (isLeft == true)
            {
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(1200, 0));
            }
            //give it force to left

            if (isLeft == false)
            {
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1200, 0));
            }
            //destroy after 1 second
            Destroy(fireball, 1.0f);

        }
    }
    void checkForGround()
    {
       
        //checking for ground
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            //ground is true
            isGrounded = true;

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
        if (midslash == true&& castingfireball ==false)
        {

            attackstun = true;
            attackCD += Time.deltaTime;
            if (attackCD > 1)
            {
                attackstun = false;
                attackCD = 0;
                midslash = false;
            }

        }
      
                if (castingfireball == true && midslash == false) 
        
                  { 

  

                    attackstun = true;
                    attackCD += Time.deltaTime;
                    if (attackCD > 1)
                    {
                        attackstun = false;
                        attackCD = 0;
                        castingfireball = false;
                    }

                }
            
                                                                   
        if (attackstun == false)
        {
            //left is true
            if (Input.GetAxis("Horizontal") > 0)
            {

                myBody.velocity = new Vector2(+speedforce + bonusspeed, myBody.velocity.y);
                mySprite.flipX = true;
                isMoving = true;
                isLeft = true;
                crouch = false;

                Debug.Log(mySprite.flipX);
            }
            else if (Input.GetAxis("Crouch") > 0)
            {
                myBody.velocity = new Vector2(0, myBody.velocity.y);

                crouch = true;
                isMoving = false;


            }

            else
            {
                //right is true
                if (Input.GetAxis("Horizontal") < 0)
                {
                    myBody.velocity = new Vector2(-speedforce - bonusspeed, myBody.velocity.y);
                    mySprite.flipX = false;
                    isMoving = true;
                    isLeft = false;
                    crouch = false;


                    Debug.Log(mySprite.flipX);


                }
                //standing still
                else
                {
                    isMoving = false;

                    myBody.velocity = new Vector2(0, myBody.velocity.y);

                    Debug.Log(mySprite.flipX);

                    if (Input.GetAxis("Slash") > 0)
                    {

                        midslash = true;
                    }

                    foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
                    {
                        if (item.ID == 1)
                        {

                            //stops player when O is pressed
                            if (Input.GetAxis("FireBall") > 0 && item.unlocked ==true)
                            {
                                castingfireball = true;
                            }
                        }
                    }

                }
            }

            //jump is true
            if (Input.GetAxis("Jump") > 0 && isGrounded)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);
                isMoving = false;

            }


        
            




        }
    }


    void invulerability()
    {
        //makes invincibility happen when true
        if(invicibility == true)
        {

            invulnertimer -= Time.deltaTime;
            mySprite.color = new Color32(255, 0, 0, 255);
            
            Physics2D.IgnoreLayerCollision(12, 9, true);

            if (invulnertimer <= invulnertarget)
            {
                mySprite.color = new Color32(255, 255, 255, 255);
                Physics2D.IgnoreLayerCollision(12, 9, false);
                invicibility = false;
                invulnertimer = 0.0f;
                

            }
        }
        

    }


    
    void Dead()
    {
       //kills out of bound
            if (myBody.position.y < -20)
            {
                death = true;
            }

            //kills at 0
            if (CurrentHealth <= 0)
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
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == 1)
                {
                    if (item.got == true)
                    {
                        MaxMana -= item.value;
                        item.got = false;
                    }

                }
                if (item.ID == 2)
                {
                    if (item.got == true)
                    {
                        MaxMana -= item.value;
                        item.got = false;
                    }
                }
                if (item.ID == 3)
                {
                    if (item.got == true)
                    {
                        MaxHealth -= item.value;
                        item.got = false;
                    }
                }
                if (item.ID == 4)
                {
                    if (item.got == true)
                    {
                        MaxHealth-= item.value;
                        item.got = false;
                    }
                }
                XMLManager.ins.SaveItems();
                SaveLoadManager.SavePlayer(this);

                level.changeScene(4);
            }
               }
    }
    public void HighSlash()
    {

        //have a bullet
        GameObject blade;

        Debug.Log("normalShot");

        //make a bullet
        if (mySprite.flipX == false)
        {
            Vector2 bladeSpawn = new Vector2(SwordSpawn.transform.position.x + -8.31f, SwordSpawn.transform.position.y);
            blade = (Instantiate(HighSwordPrefab, bladeSpawn, transform.rotation)) as GameObject;

            //destroy after 0.10 seconds
            Destroy(blade, .10f);
        }
        //makes the sword face left
        else if (mySprite.flipX == true)
        {
            Vector2 bladeSpawn = new Vector2(SwordSpawn.transform.position.x + 1.5f, SwordSpawn.transform.position.y);

            SwordSpawn.transform.localPosition = new Vector2(2.27f,0f);
            blade = (Instantiate(HighSwordPrefab, bladeSpawn, transform.rotation)) as GameObject;

            //destroy after 0.10 seconds
            Destroy(blade, .10f);
        }





        //makes slash equal true

    }

   



    private void OnTriggerEnter2D(Collider2D collision)
    {




       if (collision.gameObject.CompareTag("BronzeRing"))
        {
            ID = 1;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == ID)
                {
                    if (item.got == false)
                    {

                        item.got = true;

                        var MpUp = barsize + (item.value * 10);
                        MaxMana += item.value;

                        CurrentMana += item.value;
                        ID = 0;
                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(this);

                        RectTransform MpSliderRect = slide2.GetComponent<RectTransform>();
                        MpSliderRect.sizeDelta = new Vector2(MpUp, MpSliderRect.sizeDelta.y);
                    }
                }



                else
                {

                }

            }
        }

        else if (collision.gameObject.CompareTag("SilverRing"))
        {
            ID = 2;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == ID)
                {
                    if (item.got == false)
                    {
                        item.got = true;

                        var MpUp = barsize + (item.value * 10);
                        MaxMana += item.value;
                        CurrentMana += item.value;

                        ID = 0;
                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(this);

                        RectTransform MpSliderRect = slide2.GetComponent<RectTransform>();
                        MpSliderRect.sizeDelta = new Vector2(MpUp,  MpSliderRect.sizeDelta.y);

                    }
                }



                else
                {

                }

            }
        }

        else if (collision.gameObject.CompareTag("SteelHelm"))
        {
            ID = 3;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == ID)
                {
                    if (item.got == false)
                    {
                        
                        item.got = true;

                        var hpUp = barsize + (item.value*10);
                        MaxHealth += item.value;
                        CurrentHealth += item.value;

                        ID = 0;
                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(this);

                        RectTransform HpSliderRect = slide.GetComponent<RectTransform>();
                        HpSliderRect.sizeDelta = new Vector2(hpUp, HpSliderRect.sizeDelta.y);

                    }
                }



                else
                {

                }

            }
        }

        else if (collision.gameObject.CompareTag("SteelShield"))
        {
            ID = 4;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == ID)
                {
                    if (item.got == false)
                    {
                        item.got = true;

                        var hpUp = barsize + (item.value*10);

                        MaxHealth += item.value;
                        CurrentHealth += item.value;

                        ID = 0;
                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(this);

                        RectTransform HpSliderRect = slide.GetComponent<RectTransform>();
                        HpSliderRect.sizeDelta = new Vector2(hpUp, HpSliderRect.sizeDelta.y);
                    }
                }



                else
                {

                }

            }
        }

        //gives the player a coin
        else if (collision.gameObject.CompareTag("Coin"))
        {
            coin++;

            coinvalue.text = coin + "$";

        }
      
        //adds hp

        else if (collision.gameObject.CompareTag("BSnack"))
        {
            CurrentHealth += 2;

            if(MaxHealth < CurrentHealth)
            { CurrentHealth = MaxHealth;
            }


        }
        //adds mana
        else if (collision.gameObject.CompareTag("Mvial"))
        {

            CurrentMana += 2;

            if (MaxMana < CurrentMana)
            {
                CurrentMana = MaxMana;
            }


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
            slide.SetBar(CurrentHealth);

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            CurrentHealth -= damage.Damage;
        }
        //makes enemies do damage
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            
                slide.SetBar(CurrentHealth);

                var target = collision.transform;
                dir1 = (transform.position - target.position).normalized;
                myBody.AddRelativeForce(dir1 * thrust);
                var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
                CurrentHealth -= damage.Damage;
                invicibility = true;
                invulnertimer = 2.0f;

            


        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            var powerScript = collision.gameObject.GetComponent<POWER_SCRIPT>();


            CurrentHealth -= powerScript.Damage;





            StartCoroutine(knockback(0.5f, 50f, collision.transform)) ;
      

            invicibility = true;

            invulnertimer = 2.0f;

        }
    }
}
