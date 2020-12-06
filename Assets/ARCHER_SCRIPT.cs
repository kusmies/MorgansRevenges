using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCHER_SCRIPT : MonoBehaviour
{
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
    int dmgThreshold = 1;
    bool beenActivated = false;
    float colorChangeCD = 0f;
    float hitStunCD = 0f;
    public DFACT1_HANDLER_SCRIPT actManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
        if (myBody.position.y < -20)
        {
            isDead = true;
        }
        if (actManager.levelComplete)
        {
            isDead = true;
        }

        if (isPlayerNearby())
        {
            beenActivated = true;
        }

        if (beenActivated)
        {
            handleColor();

            checkForGround();
            if (!isDead)
            {
                if (hitStunCD <= 0)
                {
                    archerAnimatorScript.isHitStun = false;

                    checkForPlayer();

                    powerScript.Damage = 3;

                    if (!isAttacking)
                    {
                        walkingAround();
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    hitStun();
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
                        archerAnimatorScript.isWalking = false;
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
                        archerAnimatorScript.isWalking = false;

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
                RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, .1f, groundLayer);

                if (raycastHit2d.collider != null)
                {
                    mySprite.flipX = true;
                    turnAroundCD = 2f;
                }
                else
                {
                    myBody.velocity = new Vector2(-3f, myBody.velocity.y);
                    archerAnimatorScript.isWalking = true;
                }
            }
            else
            {
                RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.right, .1f, groundLayer);

                if (raycastHit2d.collider != null)
                {
                    mySprite.flipX = false;
                    turnAroundCD = 2f;
                }
                else
                {
                    myBody.velocity = new Vector2(3f, myBody.velocity.y);
                    archerAnimatorScript.isWalking = true;
                }
            }
        }
        else
        {
            turnAroundCD -= Time.deltaTime;
            archerAnimatorScript.isWalking = false;
        }

        if (turnAroundCD <= 0) //Check for Ledge
        {
            if (!mySprite.flipX)
            {
                RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, .1f, groundLayer);

                if (raycastHit2d1.collider == null)
                {
                    Vector2 originPoint = new Vector2(myTran.position.x - 3f, myTran.position.y);


                    RaycastHit2D raycastHit2d2 = Physics2D.BoxCast(originPoint, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

                    if (raycastHit2d2.collider == null)
                    {
                        mySprite.flipX = true;
                        turnAroundCD = 2f;
                    }
                    else
                    {
                        myBody.velocity = new Vector2(-3f, myBody.velocity.y);
                        archerAnimatorScript.isWalking = true;
                    }

                }
                else
                {
                    myBody.velocity = new Vector2(-3f, myBody.velocity.y);
                    archerAnimatorScript.isWalking = true;
                }
            }
            else
            {
                RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, .1f, groundLayer);

                if (raycastHit2d1.collider == null)
                {
                    Vector2 originPoint = new Vector2(myTran.position.x + 3f, myTran.position.y);


                    RaycastHit2D raycastHit2d2 = Physics2D.BoxCast(originPoint, myBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

                    if (raycastHit2d2.collider == null)
                    {
                        mySprite.flipX = false;
                        turnAroundCD = 2f;
                    }
                    else
                    {
                        myBody.velocity = new Vector2(3f, myBody.velocity.y);
                        archerAnimatorScript.isWalking = true;
                    }

                }
                else
                {
                    myBody.velocity = new Vector2(3f, myBody.velocity.y);
                    archerAnimatorScript.isWalking = true;
                }
            }
        }
        else
        {
            turnAroundCD -= Time.deltaTime;
            archerAnimatorScript.isWalking = false;
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
                    hitStunCD = 2f;
                    archerAnimatorScript.endAttack();
                }
                else
                {
                    colorChangeCD = 1f;
                }
            }
            else
            {
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
                    hitStunCD = 2f;
                    archerAnimatorScript.endAttack();
                }
                else
                {
                    colorChangeCD = 1f;
                }
            }
            else
            {
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
        archerAnimatorScript.endAttack();

        GameObject explosion;

        explosion = Instantiate(explosionEffect, myTran.position, myTran.rotation);

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
        archerAnimatorScript.isHitStun = true;
        powerScript.Damage = 0;
        if (hitStunCD > 0)
        {
            hitStunCD -= Time.deltaTime;
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

    }

    void endAttack()
    {
        attackCD = 2.0f;
    }
}
