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

    // Start is called before the first frame update
    void Start()
    {
        powerScript = GetComponent<POWER_SCRIPT>();
        myTran = GetComponent<Transform>();
        myBox = GetComponent<BoxCollider2D>();
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        warDogAnimScript = GetComponent<WARDOG_ANIM_SCRIPT>();
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

        checkForGround();

        if(!isDead)
        {
            invincibilty();

            walkingAround();
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

    void walkingAround()
    {
            if (!mySprite.flipX)
            {
                RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.left, .1f, groundLayer);

                if (raycastHit2d.collider != null)
                {
                    mySprite.flipX = true;
                    
                }
                else
                {
                    myBody.velocity = new Vector2(-5f, myBody.velocity.y);
                    warDogAnimScript.isWalking = true;
                }
            }
            else
            {
                RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBox.bounds.center, myBox.bounds.size, 0f, Vector2.right, .1f, groundLayer);

                if (raycastHit2d.collider != null)
                {
                    mySprite.flipX = false;
                    
                }
                else
                {
                    myBody.velocity = new Vector2(5f, myBody.velocity.y);
                    warDogAnimScript.isWalking = true;
                }
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            hp -= playerPower.Damage;

            if (playerPower.Damage >= dmgThreshold)
            {
                invinCD = 2.0f;
            }
            else
            {
                invinCD = 2.0f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            hp -= playerPower.Damage;

            if (playerPower.Damage >= dmgThreshold)
            {
                invinCD = 2.0f;
            }
            else
            {
                invinCD = 2.0f;
            }

        }
    }

    void invincibilty()
    {
        if (invinCD > 0)
        {
            
            invinCD -= Time.deltaTime;

            mySprite.color = new Color32(255, 0, 0, 255);

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
        mySprite.color = new Color32(255, 0, 0, 255);

        GameObject explosion;

        explosion = Instantiate(explosionEffect, myTran.position, myTran.rotation);

        Destroy(gameObject);
    }

    void spawnExplosion()
    {
        GameObject explosion;

        explosion = Instantiate(explosionEffect, myTran.position, myTran.rotation);
    }
}
