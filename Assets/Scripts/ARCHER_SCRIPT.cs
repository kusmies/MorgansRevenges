using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCHER_SCRIPT : MonoBehaviour
{
    public FLOATING_FONT damageNumbers;

    POWER_SCRIPT powerScript;
    public Transform myTran;
    public ARCHER_ANIM_SCRIPT archerAnimatorScript;
    BoxCollider2D myBox;
    Rigidbody2D myBody;
    public bool isGrounded = false;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask playerLayer;
    SpriteRenderer mySprite;
    public bool isAttacking = false;
    float attackCD = 0f;
    float turnAroundCD = 0f;
    public bool isDead = false;
    public int hp = 5;
    public GameObject arrowPrefab;
    public GameObject explosionEffect;
    int dmgThreshold = 2;
    bool beenActivated = false;
    float colorChangeCD = 0f;
    float hitStunCD = 0f;
    public DFACT1_HANDLER_SCRIPT actManager;
    public int state = 6; //1 is walking, 2 is dead, 3 is hitstun, 4 straight shot, 5 is arc shot, 6 is idle
    public UNIDROP_SCRIPT dropScript;

    // Start is called before the first frame update
    void Start()
    {
        damageNumbers = GetComponent<FLOATING_FONT>();

        archerAnimatorScript = GetComponent<ARCHER_ANIM_SCRIPT>();
        powerScript = GetComponent<POWER_SCRIPT>();
        myTran = GetComponent<Transform>();
        myBox = GetComponent<BoxCollider2D>();
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        dropScript = GetComponent<UNIDROP_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {

        checkForDeath();

        if (isPlayerNearby())
        {
            beenActivated = true;
        }

        if (beenActivated)
        {
            handleColor();

            checkForGround();
            
            switch (state)
            {
                case 1: //walking
                    walkingAround();
                    checkForPlayer();
                    break;
                case 2: //dead
                    killVelocity();
                    break;

                case 3: //hitstun
                    hitStun();
                    break;
                case 4: //straight shot
                    
                    break;
                case 5: //arc shot
                    
                    break;
                case 6: //idle
                    idleState();
                    break;
                default:
                    state = 1;
                    break;
            }
            

        }

        archerAnimatorScript.state = state;

    }

    void checkForGround()
    {

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    void checkForPlayer()
    {
        if (attackCD <= 0f && !isAttacking)
        {
            if (!mySprite.flipX)
            {
                RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, 7.5f, playerLayer);

                if (raycastHit2d.collider != null)
                {
                    if (!isAttacking)
                    {
                        isAttacking = true;
                        attackCD = 2.0f;
                        chooseAttack();
                    }
                }
            }
            else
            {
                RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.right, 7.5f, playerLayer);

                if (raycastHit2d.collider != null)
                {
                    if (!isAttacking)
                    {
                        isAttacking = true;
                        attackCD = 2.0f;
                        chooseAttack();
                    }
                }
            }
        }
        else
        {
            attackCD -= Time.deltaTime;
        }

    }

    void walkingAround()
    {
        if (turnAroundCD <= 0) //Check for Wall
        {
            if (!mySprite.flipX)
            {
                RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, .1f, groundLayer);

                if (raycastHit2d1.collider != null)
                {
                    state = 6;
                    mySprite.flipX = true;
                    turnAroundCD = 2f;
                }
                else
                {
                    state = 1;
                    myBody.velocity = new Vector2(-3f, myBody.velocity.y);
                }
            }
            else
            {
                RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.right, .1f, groundLayer);

                if (raycastHit2d1.collider != null)
                {
                    state = 6;
                    mySprite.flipX = false;
                    turnAroundCD = 2f;
                }
                else
                {
                    state = 1;
                    myBody.velocity = new Vector2(3f, myBody.velocity.y);
                }
            }


        }
        

        if (turnAroundCD <= 0) //Check for Ledge
        {
            if (!mySprite.flipX)
            {
                RaycastHit2D raycastHit2d2 = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, .1f, groundLayer);

                if (raycastHit2d2.collider == null)
                {
                    Vector2 originPoint = new Vector2(myTran.position.x - 3f, myTran.position.y);


                    RaycastHit2D raycastHit2d3 = Physics2D.BoxCast(originPoint, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

                    if (raycastHit2d3.collider == null)
                    {
                        mySprite.flipX = true;
                        turnAroundCD = 2f;
                    }
                    else
                    {
                        myBody.velocity = new Vector2(-3f, myBody.velocity.y);
                    }

                }
                else
                {
                    myBody.velocity = new Vector2(-3f, myBody.velocity.y);
                }
            }
            else
            {
                RaycastHit2D raycastHit2d2 = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, .1f, groundLayer);

                if (raycastHit2d2.collider == null)
                {
                    Vector2 originPoint = new Vector2(myTran.position.x + 3f, myTran.position.y);


                    RaycastHit2D raycastHit2d3 = Physics2D.BoxCast(originPoint, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

                    if (raycastHit2d3.collider == null)
                    {
                        mySprite.flipX = false;
                        turnAroundCD = 2f;
                    }
                    else
                    {
                        myBody.velocity = new Vector2(3f, myBody.velocity.y);
                    }

                }
                else
                {
                    myBody.velocity = new Vector2(3f, myBody.velocity.y);
                }
            }
        }
        
        if(turnAroundCD>0)
        {
            turnAroundCD -= Time.deltaTime;
            state = 6;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            hp -= playerPower.Damage;

            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), myBox);

            if (hitStunCD <= 0)
            {
                if (playerPower.Damage >= dmgThreshold)
                {
                    damageNumbers.showText(playerPower.Damage.ToString() + "!");

                    hitStunCD = 2f;
                    archerAnimatorScript.clearAllBools();
                    state = 3;
                }
                else
                {
                    damageNumbers.showText(playerPower.Damage.ToString());

                    colorChangeCD = 1f;
                }
            }
            else
            {
                damageNumbers.showText(playerPower.Damage.ToString());

                colorChangeCD = 1f;
            }

        }

        if (collision.gameObject.CompareTag("Water"))
        {
            WATSUB_SCRIPT waterScript = collision.gameObject.GetComponent<WATSUB_SCRIPT>();

            if (!waterScript.isFrozen) hp = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            hp -= playerPower.Damage;

            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), myBox);

            if (hitStunCD <= 0)
            {
                if (playerPower.Damage >= dmgThreshold)
                {
                    damageNumbers.showText(playerPower.Damage.ToString() + "!");

                    hitStunCD = 2f;
                    archerAnimatorScript.clearAllBools();
                }
                else
                {
                    damageNumbers.showText(playerPower.Damage.ToString());

                    colorChangeCD = 1f;
                }
            }
            else
            {
                damageNumbers.showText(playerPower.Damage.ToString());

                colorChangeCD = 1f;
            }

        }

        if (collision.gameObject.CompareTag("Water"))
        {
            WATSUB_SCRIPT waterScript = collision.gameObject.GetComponent<WATSUB_SCRIPT>();

            if (!waterScript.isFrozen) hp = 0;
        }
    }

    void killArcher()
    {
        GameObject explosion;

        explosion = Instantiate(explosionEffect, myTran.position, myTran.rotation);

        dropScript.Drop();

        Destroy(gameObject);
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

    void hitStun()
    {
        state = 3;
        powerScript.Damage = 0;
        if (hitStunCD > 0)
        {
            hitStunCD -= Time.deltaTime;
        }
        else
        {
            powerScript.Damage = 3;
            state = 6;
        }

    }

    void handleColor()
    {
        if (hitStunCD > 0)
        {
            mySprite.color = new Color32(255, 255, 0, 255);
        }
        else if (colorChangeCD > 0)
        {
            colorChangeCD -= Time.deltaTime;

            mySprite.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            mySprite.color = new Color32(255, 255, 255, 255);
        }
    }

    void chooseAttack()
    {
        killVelocity();

        archerAnimatorScript.clearAllBools();

        float whichAttack = Random.Range(0f, 1f);

        if(whichAttack <=.5)
        {
            Debug.Log("Straight Shot");
            state = 4;
        }
        else
        {
            Debug.Log("Arc Shot");
            state = 5;
        }
    }

    void killVelocity()
    {
        myBody.velocity = new Vector2(0f, 0f);
    }

    void endAttack()
    {
        attackCD = 2.0f;
        isAttacking = false;
        archerAnimatorScript.clearAllBools();
        state = 6;
    }

    void idleState()
    {
        if(attackCD <= 0 && turnAroundCD <= 0)
        {
            state = 1;
        }
        else
        {
           if(attackCD > 0)
            {
                attackCD -= Time.deltaTime;
            }

           if(turnAroundCD > 0)
            {
                turnAroundCD -= Time.deltaTime;
            }
        }
    }

    void checkForDeath()
    {
        if (hp <= 0)
        {
            isDead = true;
            state = 2;
        }
        if (myBody.position.y < -20)
        {
            isDead = true;
            state = 2;
        }
        if (actManager.levelComplete)
        {
            isDead = true;
            state = 2;
        }
    }

    void spawnArrow()
    {
        Vector2 spawnLocation = new Vector2(0f,0f);

        Vector2 arrowVelocity = new Vector2(0f, 0f);

        if (state == 4) //Straight Shot
        {
            if(!mySprite.flipX)
            {
                spawnLocation = new Vector2(myTran.position.x - 2.15f, myTran.position.y + 0.7f);
                arrowVelocity = new Vector2(-50f, 0f);
            }
            else
            {
                spawnLocation = new Vector2(myTran.position.x + 2.18f, myTran.position.y + 0.7f);
                arrowVelocity = new Vector2(50f, 0f);
            }
        }
        else if (state == 5) //Arc shot
        {
            if (!mySprite.flipX)
            {
                spawnLocation = new Vector2(myTran.position.x - 2.0f, myTran.position.y + 1.9f);
                arrowVelocity = new Vector2(-50f, 50f);
            }
            else
            {
                spawnLocation = new Vector2(myTran.position.x + 2.0f, myTran.position.y + 1.9f);
                arrowVelocity = new Vector2(50f, 50f);
            }
        }


        GameObject arrowSpawned;

        arrowSpawned = Instantiate(arrowPrefab, spawnLocation, transform.rotation);

        ARROW_SCRIPT arrowSpawnScript = arrowSpawned.GetComponent<ARROW_SCRIPT>();

        arrowSpawnScript.myBody.velocity = arrowVelocity;

        arrowSpawnScript.actHandler = actManager;

        
    }
}
