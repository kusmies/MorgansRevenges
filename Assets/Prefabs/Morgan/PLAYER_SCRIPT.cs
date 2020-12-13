using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
//using UnityEditor.Experimental.RestService;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;

public class PLAYER_SCRIPT : MonoBehaviour
{
    public FLOATING_FONT damageNumbers;

    Vector2 pushDirection;
    //gets rigid body
    //knockback bool
    //thrust force added
    public static bool IsInputEnabled = true;

    public float thrust;
    int ID;
    //jump height
    public float jumpforce;
    //inital speed
    public float speedforce;
    //additional speed

    public float barsize = 160;
    //the coin int
    public float coin;
    //invunerable timer ticks up
    public float invulnertimer;
    public float stuntimer;
    //target for the invunerable timer to equal
    public float invulnertarget;
    public float stuntarget;
    //bool for players invincibility

    // how long it takes the player to actually die
    public float deathtimer;
    //the target the death timer equals
    public float deathtimertarget;
    public float MaxHealth;
    public float CurrentHealth;
    public float MaxMana;
    public float CurrentMana;
    public float SwordDamage;
    public float bonusspeed;

    public float speedup;
    public GameObject player;
    public GameObject SwordSpawn;
    public GameObject HighSwordPrefab;
    GameObject fireball;
    GameObject Frostwave;


    public GameObject FrostWavePrefab;

    public GameObject FireballPrefab;
    public Text itemtext;

    public GameObject FrostWaveSpawn;

    //spawn point for the fireball
    public GameObject FireballSpawn;
    //hp bar
    public Slider Hp;
    public Slider Mp;
    //checks for ground
    public bool playerstruck;
    public bool isGrounded;
    //checks if moving
    public bool isMoving;
    //checks if facing left
    public bool knockBack;
    public bool landing;
    public bool castingfireball;
    public bool castingfrostWave;
    public bool jumpslash;
    public bool midslash;
    public bool crouch;
    public bool invicibility;
    public bool doublejumped;
    //bool for players death
    public bool death;
    public bool stun;
    public bool hitstunned;


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
    public SpriteRenderer mySprite;
    //players ground layer
    [SerializeField] public LayerMask groundLayer;

    public GameObject windPushParticleEmitter;

    // Start is called before the first frame update

    void Awake()
    {
        slide.SetMaxBar(MaxHealth);
        slide2.SetMaxBar(MaxMana);
        Load();
        var MpUp = barsize + (MaxMana * 10);
        var hpUp = barsize + (MaxHealth * 10);

        RectTransform HpSliderRect = slide.GetComponent<RectTransform>();
        HpSliderRect.sizeDelta = new Vector2(hpUp, HpSliderRect.sizeDelta.y);
        RectTransform MpSliderRect = slide2.GetComponent<RectTransform>();
        MpSliderRect.sizeDelta = new Vector2(MpUp, MpSliderRect.sizeDelta.y);

    }

    void Start()
    {
        bonusspeed = speedup;
        damageNumbers = GetComponent<FLOATING_FONT>();

        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        XMLManager.ins.PermLoadItems();
        XMLManager.ins.LoadItems();
        slide.SetMaxBar(MaxHealth);
        slide2.SetMaxBar(MaxMana);
        var MpUp = barsize + (MaxMana * 10);
        var hpUp = barsize + (MaxHealth * 10);

        RectTransform HpSliderRect = slide.GetComponent<RectTransform>();
        HpSliderRect.sizeDelta = new Vector2(hpUp, HpSliderRect.sizeDelta.y);
        RectTransform MpSliderRect = slide2.GetComponent<RectTransform>();
        MpSliderRect.sizeDelta = new Vector2(MpUp, MpSliderRect.sizeDelta.y);
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
        SwordDamage = loadedStats[3];
        speedup = loadedStats[4];
    }
    // Update is called once per frame

    void Update()

    {

        slide.SetMaxBar(MaxHealth);
        slide2.SetMaxBar(MaxMana);
        slide.SetBar(CurrentHealth);
        slide2.SetBar(CurrentMana);



        var MpUp = barsize + (MaxMana * 10);
        var hpUp = barsize + (MaxHealth * 10);

        RectTransform HpSliderRect = slide.GetComponent<RectTransform>();
        HpSliderRect.sizeDelta = new Vector2(hpUp, HpSliderRect.sizeDelta.y);
        RectTransform MpSliderRect = slide2.GetComponent<RectTransform>();
        MpSliderRect.sizeDelta = new Vector2(MpUp, MpSliderRect.sizeDelta.y);
        coinvalue.text = "X " + coin.ToString();

        if (!death && PLAYER_SCRIPT.IsInputEnabled == true)
        {
            checkForGround();

            handleMovement();
        }

        Dead();
        invulerability();

    }
    //checks if the players on the ground



    void checkForGround()
    {

        //checking for ground
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            //ground is true
            isGrounded = true;
            doublejumped = false;

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


        if (stun == false||playerstruck ==false)
        {
           
                midslash = false;
            castingfireball = false;
            castingfrostWave = false;
            jumpslash = false;

          



         
            //left is true
             if (Input.GetAxisRaw("Horizontal") > 0)
            {

                myBody.velocity = new Vector2(+speedforce + speedup, myBody.velocity.y);
                mySprite.flipX = true;
                isMoving = true;
                crouch = false;
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);


                }
                else if (!isGrounded)
                {
                    if (Input.GetButtonDown("JumpSlash"))
                    {


                        jumpslash = true;
                    }

                    else if (Input.GetButtonDown("WindSlash") && CurrentMana > 0 && doublejumped == false)
                    {
                        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
                        {
                            if (item.ID == 3)
                            {

                                if (item.unlocked == true)
                                {
                                    doublejumped = true;
                                    CurrentMana--;
                                    GameObject PartEmitter;
                                    PartEmitter = Instantiate(windPushParticleEmitter, transform.position, transform.rotation);
                                    WINPUEM_SCRIPT PartEmitterScript = PartEmitter.GetComponent<WINPUEM_SCRIPT>();
                                    PartEmitterScript.spawnZoneOrigin = player.transform.position;
                                    PartEmitterScript.spawnZoneBounds = new Vector2(1.5f, 3f);
                                    myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);

                                }
                            }
                        }
                    }

                }

            }
            else if (Input.GetButtonDown("Crouch"))
            {
                myBody.velocity = new Vector2(0, myBody.velocity.y);

                crouch = true;
                isMoving = false;



            }
            else if (Input.GetButtonUp("Crouch"))
            {
                myBody.velocity = new Vector2(0, myBody.velocity.y);

                crouch = false;


            }
            else if (crouch == true)
            {
                foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
                {
                    if (item.ID == 2)
                    {
                        if (item.unlocked == true)
                        {
                            if (Input.GetButtonDown("FrostWave") && item.unlocked == true)
                            {

                                castingfrostWave = true;
                            }

                        }
                    }
                }
            }
 

            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                myBody.velocity = new Vector2(-speedforce - speedup, myBody.velocity.y);
                mySprite.flipX = false;
                isMoving = true;
                crouch = false;

                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);


                }
                else if (!isGrounded)
                {
                    if (Input.GetButtonDown("JumpSlash"))
                    {


                        jumpslash = true;
                    }
                    else if (Input.GetButtonDown("WindSlash") && CurrentMana > 0 && doublejumped == false)
                    {
                        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
                        {
                            if (item.ID == 3)
                            {

                                if (item.unlocked == true)
                                {
                                    doublejumped = true;
                                    CurrentMana--;
                                    GameObject PartEmitter;
                                    PartEmitter = Instantiate(windPushParticleEmitter, transform.position, transform.rotation);
                                    WINPUEM_SCRIPT PartEmitterScript = PartEmitter.GetComponent<WINPUEM_SCRIPT>();
                                    PartEmitterScript.spawnZoneOrigin = player.transform.position;
                                    PartEmitterScript.spawnZoneBounds = new Vector2(1.5f, 3f);
                                    myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);

                                }
                            }
                        }
                    }
                }

            }

            //jump is true


            //standing still
            else
            {
                isMoving = false;

                myBody.velocity = new Vector2(0, myBody.velocity.y);

                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);


                }
                else if (!isGrounded)
                {
                    if (Input.GetButtonDown("JumpSlash"))
                    {


                        jumpslash = true;
                    }

                    else if (Input.GetButtonDown("WindSlash") && CurrentMana > 0 &&doublejumped == false)
                    {
                        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
                        {
                            if (item.ID == 3)
                            {

                                if (item.unlocked == true)
                                {
                                    doublejumped = true;
                                    CurrentMana--;
                                    GameObject PartEmitter;
                                    PartEmitter = Instantiate(windPushParticleEmitter, transform.position, transform.rotation);
                                    WINPUEM_SCRIPT PartEmitterScript = PartEmitter.GetComponent<WINPUEM_SCRIPT>();
                                    PartEmitterScript.spawnZoneOrigin = player.transform.position;
                                    PartEmitterScript.spawnZoneBounds = new Vector2(1.5f, 3f);
                                    myBody.velocity = new Vector2(myBody.velocity.x, jumpforce);

                                }
                            }
                        }
                    }

                }

                if (Input.GetButtonDown("Slash") && isGrounded)
                {

                    midslash = true;

                }

                foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
                {
                    if (item.ID == 1)
                    {

                        if (item.unlocked == true)
                        {
                            //stops player when O is pressed
                            if (Input.GetButtonDown("FireBall") && item.unlocked == true)
                            {
                                castingfireball = true;
                            }
                        }

                    }
                }

            }


        }


    }


    void failsafe()
    {
        stun = false;
    }

    void crouchsafe()
    {
        crouch = false;
    }
    void invulerability()
    {
        //makes invincibility happen when true
        if (invicibility == true)
        {

            if (stuntimer > stuntarget)
            {
                isMoving = false;
                playerstruck = true;

                if (mySprite.flipX == true)
                {
                    PLAYER_SCRIPT.IsInputEnabled = false;
                    Vector2 direction = new Vector2(-20f, myBody.velocity.y);
                    myBody.velocity = direction;
                }

                if (mySprite.flipX == false)
                {
                    PLAYER_SCRIPT.IsInputEnabled = false;

                    Vector2 direction = new Vector2(20f, myBody.velocity.y);
                    myBody.velocity = direction;
                }

        


            }

            stuntimer -= Time.deltaTime;
            invulnertimer -= Time.deltaTime;
            mySprite.color = new Color32(255, 0, 0, 255);

            Physics2D.IgnoreLayerCollision(12, 9, true);

            if (stuntimer <= stuntarget)
            {
                playerstruck = false;
                PLAYER_SCRIPT.IsInputEnabled = true;

                stun = false;
                stuntimer = 0.0f;
            }
    
        }

        if (invulnertimer <= invulnertarget)
        {

            mySprite.color = new Color32(255, 255, 255, 255);
            if (death == false)
            {
                Physics2D.IgnoreLayerCollision(12, 9, false);
            }
            invicibility = false;
            invulnertimer = 0.0f;


        }


    }

    public void attackloop()
    {
        stun = !stun;
    }


    public void itemcleaner()
    {
        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
        {
            if (item.ID == 1)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 2)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 3)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 4)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 5)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }

        }

        foreach (ItemEntry item in XMLManager.ins.itemDB.list)
        {

            if (item.ID == 1)
            {
                item.displayed = false;

                if (item.got == true)
                {
                    MaxMana -= item.value;
                    item.got = false;

                    item.chestdropped = false;



                }

            }
            if (item.ID == 2)
            {
                item.displayed = false;

                if (item.got == true)
                {
                    MaxMana -= item.value;
                    item.got = false;
                    item.chestdropped = false;


                }
            }
            if (item.ID == 3)
            {
                item.displayed = false;

                if (item.got == true)
                {
                    MaxHealth -= item.value;
                    item.got = false;
                    item.chestdropped = false;



                }
            }
            if (item.ID == 4)
            {
                item.displayed = false;

                if (item.got == true)
                {
                    MaxHealth -= item.value;
                    item.got = false;
                    item.chestdropped = false;



                }


            }
            if (item.ID == 5)
            {
                if (item.got == true)
                {
                    item.displayed = false;

                    SwordDamage -= item.value;
                    item.got = false;
                    item.chestdropped = false;



                }
            }
            if (item.ID == 6)
            {
                if (item.got == true)
                {
                    SwordDamage -= item.value;
                    item.got = false;
                    item.chestdropped = false;
                    item.displayed = false;


                }
            }
            if (item.ID == 7)
            {
                if (item.got == true)
                {
                    speedup -= item.value;
                    item.got = false;
                    item.chestdropped = false;
                    item.displayed = false;


                }
            }
        }
        XMLManager.ins.SaveItems();
        XMLManager.ins.PermSaveItems();

        SaveLoadManager.SavePlayer(this);
    }
    void Dead()
    {
        Physics2D.IgnoreLayerCollision(12, 9, true);


        //kills out of bound
        if (myBody.position.y < -2000)
        {
            death = true;
        }

        //kills at 0
        if (CurrentHealth <= 0)
        {

            death = true;

            myBody.velocity = new Vector2(0, myBody.velocity.y);

        }

        //plays animation when death equals true
        if (death == true)
        {
            deathtimer += Time.deltaTime;
        }

        if (deathtimer >= deathtimertarget)
        {
            Physics2D.IgnoreLayerCollision(12, 9, false);

            itemcleaner();
             
                level.changeScene(4);
            
        }
    }
    public void CastFireball()
    {
        if (CurrentMana > 0)
        {
            

            //sets the shoot equal to true
            CurrentMana-=4;
            slide2.SetBar(CurrentMana);
            //have a bullet
            if (CurrentMana < 0)
            {
                CurrentMana = 0;
            }
            Debug.Log("normalShot");


            //makes a bullet

            //give it force to right

            if (mySprite.flipX == true)
            {


                Vector2 Firespawn = new Vector2(FireballSpawn.transform.position.x + 2.9f, FireballSpawn.transform.position.y);

                fireball = (Instantiate(FireballPrefab, Firespawn, transform.rotation)) as GameObject;
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(1200, 0));
            }
            //give it force to left

            if (mySprite.flipX == false)
            {
                Vector2 Firespawn = new Vector2(FireballSpawn.transform.position.x - 2.9f, FireballSpawn.transform.position.y);

                fireball = (Instantiate(FireballPrefab, Firespawn, transform.rotation)) as GameObject;
                fireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1200, 0));

            }
            //destroy after 1 second
            Destroy(fireball, 1.0f);

        }
    }
    public void CastFrostWave()
    {
        if (CurrentMana > 0)
        {
            //sets the shoot equal to true
            CurrentMana -= 3;
            if(CurrentMana < 0)
            {
                CurrentMana = 0;
            }
            slide2.SetBar(CurrentMana);
            //have a bullet

            Debug.Log("normalShot");


            //makes a bullet

            //give it force to right

            if (mySprite.flipX == true)
            {
                Vector2 FrostSpawn = new Vector2(FrostWaveSpawn.transform.position.x, FrostWaveSpawn.transform.position.y);

                Frostwave = (Instantiate(FrostWavePrefab, FrostSpawn, transform.rotation)) as GameObject;


            }
            //give it force to left

            if (mySprite.flipX == false)
            {
                Vector2 FrostSpawn = new Vector2(FrostWaveSpawn.transform.position.x, FrostWaveSpawn.transform.position.y);

                Frostwave = (Instantiate(FrostWavePrefab, FrostSpawn, transform.rotation)) as GameObject;
            }
            //destroy after 1 second
            Destroy(Frostwave, 1.0f);

        }
    }
    public void HighSlash()
    {

        //have a bullet
        GameObject blade;



        //make a bullet
        if (mySprite.flipX == false)
        {
            Vector2 bladeSpawn = new Vector2(SwordSpawn.transform.position.x +-5.71f, SwordSpawn.transform.position.y);
            blade = (Instantiate(HighSwordPrefab, bladeSpawn, transform.rotation)) as GameObject;
            blade.GetComponent<POWER_SCRIPT>().Damage += (int)SwordDamage;

            //destroy after 0.10 seconds
            Destroy(blade, .10f);
        }
        //makes the sword face left
        else if (mySprite.flipX == true)
        {
            Vector2 bladeSpawn = new Vector2(SwordSpawn.transform.position.x + 1.5f, SwordSpawn.transform.position.y);

            SwordSpawn.transform.localPosition = new Vector2(2.27f, 0f);
            blade = (Instantiate(HighSwordPrefab, bladeSpawn, transform.rotation)) as GameObject;
            blade.GetComponent<POWER_SCRIPT>().Damage += (int)SwordDamage;

            //destroy after 0.10 seconds
            Destroy(blade, .10f);
        }





        //makes slash equal true

    }





    private void OnTriggerEnter2D(Collider2D collision)
    {




        //gives the player a coin
      
        //kills on hazard collision
         if (collision.gameObject.CompareTag("Water"))
        {
            slide.SetBar(CurrentHealth);

            WATSUB_SCRIPT waterScript = collision.gameObject.GetComponent<WATSUB_SCRIPT>();
            damageNumbers.showText("999");

            if (!waterScript.isFrozen) CurrentHealth = 0;

        }
        
         //makes enemies do damage
         else if (collision.gameObject.CompareTag("Enemy"))
         {



            slide.SetBar(CurrentHealth);

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            damageNumbers.showText(damage.Damage.ToString());

            CurrentHealth -= damage.Damage;
            invicibility = true;
            invulnertimer = 2.0f;
            stuntimer = 0.5f;
        }

     
    }

    void OnCollisionEnter2D(Collision2D collision)
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

                        var MpUp = barsize + (MaxMana * 10);
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

                        var MpUp = barsize + (MaxMana * 10);
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

                        var hpUp = barsize + (MaxHealth * 10);
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

                        var hpUp = barsize + (MaxHealth * 10);

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
        else if (collision.gameObject.CompareTag("Dagger"))
        {
            ID = 5;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == ID)
                {
                    if (item.got == false)
                    {
                        item.got = true;


                        SwordDamage += item.value;

                        ID = 0;
                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(this);
                    }
                }



                else
                {

                }

            }
        }
        else if (collision.gameObject.CompareTag("LongSword"))
        {
            ID = 6;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == ID)
                {
                    if (item.got == false)
                    {
                        item.got = true;

                        SwordDamage += item.value;
                        ID = 0;
                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(this);
                    }
                }



                else
                {

                }

            }
        }
        else if (collision.gameObject.CompareTag("SilverShoes"))
        {
            ID = 7;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (item.ID == ID)
                {
                    if (item.got == false)
                    {
                        item.got = true;

                        speedup += item.value;
                        ID = 0;
                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(this);
                    }
                }



                else
                {

                }

            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {

          

            slide.SetBar(CurrentHealth);

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();

            damageNumbers.showText(damage.Damage.ToString());

            CurrentHealth -= damage.Damage;
            invicibility = true;
            invulnertimer = 2.0f;
            stuntimer = 0.5f;
        }

      else if (collision.gameObject.CompareTag("Water"))
        {
            slide.SetBar(CurrentHealth);

            WATSUB_SCRIPT waterScript = collision.gameObject.GetComponent<WATSUB_SCRIPT>();
                        damageNumbers.showText("999");

            if (!waterScript.isFrozen) CurrentHealth = 0;

        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            coin++;

            coinvalue.text = coin + "$";

        }

        //adds hp

        else if (collision.gameObject.CompareTag("BSnack"))
        {
            CurrentHealth += 2;

            if (MaxHealth < CurrentHealth)
            {
                CurrentHealth = MaxHealth;
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
    }
}
