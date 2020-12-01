using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WARDOG_SCRIPT : MonoBehaviour
{
    POWER_SCRIPT powerScript;
    WARDOG_ANIM_SCRIPT warDogAnimScript;
    Transform myTran;
    BoxCollider2D myBox;
    Rigidbody2D myBody;
    public bool isGrounded;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask playerLayer;
    SpriteRenderer mySprite;
    public bool isAttacking = false;
    public bool isDead = false;
    public int hp = 4;
    public GameObject explosionEffect;
    int dmgThreshold = 1;
    float invinCD = 0;
    float jumpCD = 0f;
    float prevY;
    float prevX;
    bool wallTry = false;
    bool beenActivated = false;
    bool isHitStun = false;

    // Start is called before the first frame update
    void Start()
    {
        powerScript = GetComponent<POWER_SCRIPT>();
        myTran = GetComponent<Transform>();
        myBox = GetComponent<BoxCollider2D>();
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        warDogAnimScript = GetComponent<WARDOG_ANIM_SCRIPT>();

        prevY = myTran.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            isDead = true;
        }

        if(myTran.position.y < -20)
        {
            isDead = true;
        }
        
        if(isPlayerNearby())
        {
            beenActivated = true;
        }
        
        if(beenActivated)
        {
            checkForGround();

            if (!isDead)
            {

                invincibilty();
                if (!isHitStun)
                {
                walkingAround();
                }
                else
                {
                    warDogAnimScript.isWalking = false;
                }
            }
            else
            {
                mySprite.color = new Color32(255, 0, 0, 255);
                Physics.IgnoreLayerCollision(9, 12, true);
                Physics.IgnoreLayerCollision(9, 10, true);
                Physics.IgnoreLayerCollision(9, 0, true);
            }
        }

    }

    void checkForGround()
    {
        Vector2 boxCastSize = new Vector2(myBox.bounds.size.x - .2f, myBox.bounds.size.y);

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, boxCastSize, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            isGrounded = true;   
        }
        else
        {
            isGrounded = false;
        }
    }

    void walkingAround()
    {
        Vector2 boxCastSize = new Vector2(myBox.bounds.size.x, myBox.bounds.size.y - .2f); //We get the size of our box cast

        if (jumpCD >= 0) //If our jump cooldown is greater than 0 then we subtract delta time from it.
        {  
            jumpCD -= Time.deltaTime;
        }
        

        if (!mySprite.flipX) //If we are facing left we throw our box cast to the left and run appropriate left facing code
        {
            RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myBox.bounds.center, boxCastSize, 0f, Vector2.left, 1f, groundLayer); //Throw the box cast out to the left. We're looking for the ground layer.

            if (raycastHit2d1.collider != null) //If we hit the ground layer then run the code
            {
                if(isGrounded && jumpCD <= 0) //If we are grounded and our jump cooldown is less than or equal to 0 then we run this code.
                {
                    myBody.velocity = new Vector2(-5f, 30f); //Jump, but continue moving left.                  
                    jumpCD = 1f; //Set the jump cooldown to 1.
                    prevX = myTran.position.x;
                }
                else if(isGrounded && jumpCD > 0 && checkIfXPositionIsDifferent())
                {
                    
                    mySprite.flipX = true; //Flip the sprite's x direction. This will affect all other code that is based on the direction we are facing.
                    myBody.velocity = new Vector2(5f, myBody.velocity.y); //Start moving right, keep the war dog's y velocity though.
                    jumpCD = 0;
                }
            }
            else //If we do not hit the ground layer with our left facing box case then run this code.
            {              
                prevY = myTran.position.y; //Record the current y position.
                myBody.velocity = new Vector2(-5f, myBody.velocity.y); //Move left. Maintain the current Y velocity.
                warDogAnimScript.isWalking = true; //Tell the animation script that we are still walking.
            }
        }
        else
        {
            RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myBox.bounds.center, boxCastSize, 0f, Vector2.right, 1f, groundLayer);

            if (raycastHit2d1.collider != null)
                {
                if (isGrounded && jumpCD <= 0)
                {     
                    myBody.velocity = new Vector2(5f, 30f);
                    jumpCD = 1f;
                    prevX = myTran.position.x;
                }
                else if (isGrounded && jumpCD > 0 && checkIfXPositionIsDifferent())
                {
                    mySprite.flipX = false; //Flip the sprite's x direction. This will affect all other code that is based on the direction we are facing.
                    myBody.velocity = new Vector2(-5f, myBody.velocity.y); //Start moving right, keep the war dog's y velocity though.
                    jumpCD = 0;
                }


            }
            else
            {
                prevY = myTran.position.y;
                myBody.velocity = new Vector2(5f, myBody.velocity.y);
                warDogAnimScript.isWalking = true;
            }
        }

    }

    bool checkIfYPositionIsDifferent()
    {
        if(prevY > myTran.position.y - 1f && prevY < myTran.position.y + 1f)
        {
            return false;
        }

        return true;
    }

    bool checkIfXPositionIsDifferent()
    {
        if(prevX != myTran.position.x)
        {
            return true;
        }

        return false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            hp -= playerPower.Damage;

            if (!isHitStun)
            {
                if (playerPower.Damage >= dmgThreshold)
                {
                    activateHitStunState();
                }
                else
                {
                    invinCD = 1f;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            hp -= playerPower.Damage;

            if (!isHitStun)
            {
                if (playerPower.Damage >= dmgThreshold)
                {
                    activateHitStunState();
                }
                else
                {
                    invinCD = 1f;
                }
            }

        }
    }

    void invincibilty()
    {
        if (invinCD > 0)
        {        
            invinCD -= Time.deltaTime;

            mySprite.color = new Color32(255, 255, 0, 255);

            Physics2D.IgnoreLayerCollision(9, 12, true);
            Physics2D.IgnoreLayerCollision(9, 10, true);
        }
        else
        {
            mySprite.color = new Color32(255, 255, 255, 255);
            Physics2D.IgnoreLayerCollision(9, 12, false);
            Physics2D.IgnoreLayerCollision(9, 10, false);
        }
    }

    void killWarDog()
    {
        

        GameObject explosion;

        explosion = Instantiate(explosionEffect, myTran.position, myTran.rotation);

        Destroy(gameObject);
    }

    void spawnExplosion()
    {
        GameObject explosion;

        explosion = Instantiate(explosionEffect, myTran.position, myTran.rotation);
    }

    bool isPlayerNearby()//This function checks if the player is close enough for this enemy to begin acting.
    {
        Vector2 boxCastSize = new Vector2(64f, 30f);

        RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myBox.bounds.center, boxCastSize, 0f, Vector2.right, 0f, playerLayer);

        if (raycastHit2d1.collider != null)
        {
            return true;
        }

        return false;
    }

    void activateHitStunState()
    {
        mySprite.color = new Color32(0, 255, 0, 255);

        isHitStun = true;

        warDogAnimScript.isHitStun = true;

        if (!mySprite)
        {
            myBody.velocity = new Vector2(-5f, 10f);
        }
        else
        {
            myBody.velocity = new Vector2(5f, 10f);
        }
    }

    public void deactivateHitStunState()
    {
        mySprite.color = new Color32(255, 255, 255, 255);

        myBody.velocity = new Vector2(0f, 0f);

        invinCD = 1f;

        warDogAnimScript.isHitStun = false;

        isHitStun = false;
    }
}
