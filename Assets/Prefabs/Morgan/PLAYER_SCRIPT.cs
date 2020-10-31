using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PLAYER_SCRIPT : MonoBehaviour
{
    //hp bar
    public Slider Hp;

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

    //jump box collider
    public BoxCollider2D myBox;
    //checks the sprite renderer
    SpriteRenderer mySprite;
    //players ground layer
    [SerializeField] public LayerMask groundLayer;
    //the coin int
    public int coin;
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
        isLeft = false;
        //gets coin save
        coin = PlayerPrefs.GetInt("newcoin");
        //gets fireunlocked save
        fireunlock = PlayerPrefs.GetInt("unlocked");
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

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetAxis("Horizontal") > 0)
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
            Debug.Log("moveleft");
            crouch = false;


        }
        else  if (Input.GetAxis("Crouch") >0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                lowslash = true;
            }

            if (!Input.GetKeyDown(KeyCode.K))
            {

                lowslash = false;
            }

            crouch = true;

            Debug.Log("crouch");
        }
        else if (Input.GetAxis("Crouch") < 0)
        {
            crouch = false;
            lowslash = false;
            Debug.Log("crouch");
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

                if (Input.GetKeyDown(KeyCode.K))
                {

                    Debug.Log("slash");
                    midslash = true;
                }
                if (!Input.GetKeyDown(KeyCode.K))

                {
                    midslash = false;

                }
                Debug.Log("moveright");


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
                Debug.Log("invicibilitygone");
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
            PlayerPrefs.SetInt("newcoin", coin);
            PlayerPrefs.SetInt("unlocked", fireunlock);

            level.changeScene(4);
        }
    }

   public void Cost()
    {
      //unlocks and saves unlocked when cost is hit
       fireunlock = 1;
            coin -= 5;

        PlayerPrefs.SetInt("newcoin", coin);
        PlayerPrefs.SetInt("unlocked", fireunlock);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //makes win happen
        if (collision.tag == "Player" || collision.tag == "Win")
        {
            PlayerPrefs.SetInt("newcoin", coin);
            PlayerPrefs.SetInt("unlocked", fireunlock);

            level.changeScene(4);
        }
        //adds 1 coin
        else if (collision.gameObject.CompareTag("Coin"))
        {
            coin++;

            coinvalue.text = coin+ "$";
        }
        //adds hp
        else if (collision.gameObject.CompareTag("BSnack"))
        {
            Hp.value += 2;


        }
        //adds mana
        else if (collision.gameObject.CompareTag("Mvial"))
        {
            MP_SCRIPT.mana.Mp.value += 2;


        }
        //adds 5 coins
        else if (collision.gameObject.CompareTag("Cbag"))
        {
            coin+= 5;

            coinvalue.text = coin + "$";

        }
        //kills on hazard collision
        else if (collision.gameObject.CompareTag("Hazard"))
        {

            var damage = collision.gameObject.GetComponent<POWER_SCRIPT>();
            Hp.value -= damage.Damage;
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
                Hp.value -= damage.Damage;
                invicibility = true;
                invulnertimer = 2.0f;



            }


        }


    }
}
