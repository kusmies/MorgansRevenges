using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lancelot might be the most difficult thing I do on this project as far as programming is concerned.
//The main problem is his general shape. Lancelot is a centaur-like creature and so his shape makes his hit box a bit difficult to figure out.
//I don't like how poligonal colliders work in Unity (not enough control) and the advance poligonal collide asset seems to cause too much strain on the system.
//So I have added two box colliders to Lancelot and made two public box variables here. I assigned them personally in the inspector panel.
//There will be constant animation events that will change the shape, size, and location of these boxes.
//I believe this is the best way to handle this. If it were a snake or hydra or something else I'd definately use the poligonal collider.
//But in this circumstance (with the time I have left) this is the way.
public class LANCEL_SCRIPT : MonoBehaviour
{

    POWER_SCRIPT powerScript;
    public Transform myTran;
    LANCEL_ANIM_SCRIPT lancelAnimScript;
    public BoxCollider2D myBottomBox;
    public BoxCollider2D myTopBox;
    Rigidbody2D myBody;
    public bool isGrounded = false;
    [SerializeField] public LayerMask groundLayer;
    SpriteRenderer mySprite;
    public bool isDead = false;
    public int hp = 36;
    public GameObject explosionEffect;
    public GameObject lightningBall;
    int dmgThreshold = 4;
    float invinCD = 0;
    bool isHitStun = false;
    float chargeCD;
    public int state = 1; //1 is charging, 2 is ball lightning (attack 1), 3 is electric hell part 1 (attack 2, part 1), 4 is electric hell part 2 (attck 2, part 2), 5 is idle, 6 is hitstun, 7 is dead
    public bool spearExtended = false;
    public int bulletsSpawned = 0;
    public DFACT2_HANDLER_SCRIPT actHandler;

    // Start is called before the first frame update
    void Start()
    {
        myTran = GetComponent<Transform>();
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        lancelAnimScript = GetComponent<LANCEL_ANIM_SCRIPT>();
        chargeCD = Random.Range(4, 7);
    }

    // Update is called once per frame
    void Update()
    {

        checkForDeath();
        checkForGround();
        handleState();
    }

    void checkForDeath()
    {
        if (hp <= 0)
        {
            isDead = true;
        }
        if (myBody.position.y < -20)
        {
            isDead = true;
        }
    }

    void checkForGround()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(myBottomBox.bounds.center, myBottomBox.bounds.size, 0f, Vector2.down, .1f, groundLayer);

        if (raycastHit2d.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void handleState()
    {
        switch(state)
        {
        case 1: //Charging
            chargeAttack();
            break;
        case 2: //Ball lightning
            ballLightningState();
            break;
        case 3: //Electric Hell part 1
            electricHellPart1();
            break;
        case 4: //Electric Hell part 2
            electricHellPart2();
            break;
        case 5: // Idle
            idleState();
            break;
        case 6: // Hitstun
            hitStunState();
            break;
        case 7: // Dead

            break;
        case 8:

            break;
        case 9:

            break;
        default:
            
            break;
        }
    }

    void chargeAttack()
    {
        if (chargeCD >= 0)
        {
            chargeCD -= Time.deltaTime;
            myTopBox.size = new Vector2(4.8f, 5.2f);
            myBottomBox.size = new Vector2(8.8f, 6.4f);


            if (!mySprite.flipX)
            {
                myTopBox.offset = new Vector2(-2.99f, 3.1f);
                myBottomBox.offset = new Vector2(-1f, -2.67f);

                RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myTopBox.bounds.center, myTopBox.bounds.size, 0f, Vector2.left, 1f, groundLayer);

                if (raycastHit2d1.collider != null)
                {
                    mySprite.flipX = true;
                }
                else
                {
                    myBody.velocity = new Vector2(-15f, myBody.velocity.y);
                }
            }
            else
            {
                myTopBox.offset = new Vector2(3f, 3.1f);
                myBottomBox.offset = new Vector2(1f, -2.67f);

                RaycastHit2D raycastHit2d1 = Physics2D.BoxCast(myTopBox.bounds.center, myTopBox.bounds.size, 0f, Vector2.right, 1f, groundLayer);

                if (raycastHit2d1.collider != null)
                {
                    mySprite.flipX = false;
                }
                else
                {
                    myBody.velocity = new Vector2(15f, myBody.velocity.y);
                }
            }
        }
        else
        {
            float whichAttack = Random.Range(0f, 1f);
            //Debug.Log("whichAttack " + whichAttack);
            if(bulletsSpawned > 1)
            {
                state = 1;
                chargeCD = Random.Range(4, 7);
                lancelAnimScript.turnOffAllBools();
            }
            else if(whichAttack <= .5f)
            {
                state = 2;
            }
            else
            {
                state = 3;
                if (mySprite.flipX && myTran.position.x > actHandler.playerPosition.x)
                {
                    mySprite.flipX = false;
                }
                else if(!mySprite.flipX && myTran.position.x < actHandler.playerPosition.x)
                {
                    mySprite.flipX = true;
                }
            }

            lancelAnimScript.turnOffAllBools();
        }
    }

    void ballLightningState()
    {
        if (!mySprite.flipX)
        {
            myTopBox.offset = new Vector2(-2.22f, 3.1f);
            myBottomBox.offset = new Vector2(-.21f, -2.67f);
            myTopBox.size = new Vector2(4.8f, 5.2f);
            myBottomBox.size = new Vector2(8.8f, 6.4f);
        }
        else
        {
            myTopBox.offset = new Vector2(2.14f, 3.1f);
            myBottomBox.offset = new Vector2(.15f, -2.67f);
            myTopBox.size = new Vector2(4.8f, 5.2f);
            myBottomBox.size = new Vector2(8.8f, 6.4f);
        }

        if(bulletsSpawned >= 5)
        {
            state = 5;
            lancelAnimScript.turnOffAllBools();
        }
    }

    void spawnBallLightningBullet()
    {
        if(!mySprite.flipX)
        {
            Vector2 spawnLocation = new Vector2(myTran.position.x + -5.72f, myTran.position.y + 7.89f);

            GameObject lightBall;

            lightBall = Instantiate(lightningBall, spawnLocation, transform.rotation);

            LBALL_SCRIPT lightBallScript = lightBall.GetComponent<LBALL_SCRIPT>();

            lightBallScript.stage = 1;

            lightBallScript.lancelot = GetComponent<LANCEL_SCRIPT>();

            lightBallScript.actHandler = actHandler;
        }
        else
        {
            Vector2 spawnLocation = new Vector2(myTran.position.x + 5.69f, myTran.position.y + 7.89f);

            GameObject lightBall;

            lightBall = Instantiate(lightningBall, spawnLocation, transform.rotation);

            LBALL_SCRIPT ballScript = lightBall.GetComponent<LBALL_SCRIPT>();

            ballScript.stage = 1;

            ballScript.lancelot = GetComponent<LANCEL_SCRIPT>();

            ballScript.actHandler = actHandler;
        }

        bulletsSpawned++;
    }

    void idleState()
    {
        if (!mySprite.flipX)
        {
            myTopBox.offset = new Vector2(-1.65f, 3.1f);
            myBottomBox.offset = new Vector2(.36f, -2.67f);
        }
        else
        {
            myTopBox.offset = new Vector2(1.74f, 3.1f);
            myBottomBox.offset = new Vector2(-.26f, -2.67f);
        }

        myTopBox.size = new Vector2(4.8f, 5.2f);
        myBottomBox.size = new Vector2(8.8f, 6.4f);

        if (bulletsSpawned <= 2 && !isHitStun)
        {
            state = 1;
            lancelAnimScript.turnOffAllBools();
        }    
    }

    void hitStunState()
    {
        if(!mySprite.flipX)
        {
            myTopBox.offset = new Vector2(-1.65f, 3.1f);
            myBottomBox.offset = new Vector2(.36f, -2.67f);
        }
        else
        {
            myTopBox.offset = new Vector2(1.74f, 3.1f);
            myBottomBox.offset = new Vector2(8.8f, -2.67f);
        }

        myTopBox.size = new Vector2(4.8f, 3.1f);
        myBottomBox.size = new Vector2(8.8f, 6.4f);
    }

    void electricHellPart1()
    {
        if(!mySprite.flipX)
        {
                if (spearExtended)
                {
                    myTopBox.offset = new Vector2(-1.65f, 3.1f);
                    myBottomBox.offset = new Vector2(-2f, -2.67f);
                    myTopBox.size = new Vector2(4.8f, 3.1f);
                    myBottomBox.size = new Vector2(12.76f, 6.4f);
                }
                else
                {
                    myTopBox.offset = new Vector2(-1.65f, 3.1f);
                    myBottomBox.offset = new Vector2(.36f, -2.67f);
                    myTopBox.size = new Vector2(4.8f, 3.1f);
                    myBottomBox.size = new Vector2(8.8f, 6.4f);
                }
        }
        else
        {
        if(spearExtended)
                {
                    myTopBox.offset = new Vector2(1.74f, 3.1f);
                    myBottomBox.offset = new Vector2(2f, -2.67f);
                    myTopBox.size = new Vector2(4.8f, 3.1f);
                    myBottomBox.size = new Vector2(12.76f, 6.4f);
                }
                else
                {
                    myTopBox.offset = new Vector2(1.74f, 3.1f);
                    myBottomBox.offset = new Vector2(8.8f, -2.67f);
                    myTopBox.size = new Vector2(4.8f, 3.1f);
                    myBottomBox.size = new Vector2(8.8f, 6.4f);
                }
        }
        
    }

    void flipSpear()
    {
        if(spearExtended)
        {
            spearExtended = false;
        }
        else
        {
            spearExtended = true;
        }
    }

    void spawnElectricHellBullet()
    {
        flipSpear();

        if (!mySprite.flipX)
        {
            for(int i = 0; i < 10; i++)
            {
                Vector2 spawnLocation = new Vector2(0, 200f);

                GameObject lightBall;

                lightBall = Instantiate(lightningBall, spawnLocation, transform.rotation);

                LBALL_SCRIPT lightBallScript = lightBall.GetComponent<LBALL_SCRIPT>();

                lightBallScript.stage = 3;

                lightBallScript.electricHellIDNumber = i+1;

                lightBallScript.actHandler = actHandler;

                lightBallScript.lancelot = GetComponent<LANCEL_SCRIPT>();

                lightBallScript.setUpElectricHell();

                bulletsSpawned++;
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                Vector2 spawnLocation = new Vector2(0, 200f);

                GameObject lightBall;

                lightBall = Instantiate(lightningBall, spawnLocation, transform.rotation);

                LBALL_SCRIPT lightBallScript = lightBall.GetComponent<LBALL_SCRIPT>();

                lightBallScript.stage = 4;

                lightBallScript.electricHellIDNumber = i + 1;

                lightBallScript.actHandler = actHandler;

                lightBallScript.lancelot = GetComponent<LANCEL_SCRIPT>();

                lightBallScript.setUpElectricHell();

                bulletsSpawned++;
            }
        }
    }

    void startElectricHell2()
    {
        lancelAnimScript.turnOffAllBools();
        state = 4;
    }
    void electricHellPart2()
    {
        if (!mySprite.flipX)
        {
            if (spearExtended)
            {
                myTopBox.offset = new Vector2(-1.65f, 3.1f);
                myBottomBox.offset = new Vector2(-2f, -2.67f);
                myTopBox.size = new Vector2(4.8f, 3.1f);
                myBottomBox.size = new Vector2(12.76f, 6.4f);
            }
            else
            {
                myTopBox.offset = new Vector2(-1.65f, 3.1f);
                myBottomBox.offset = new Vector2(.36f, -2.67f);
                myTopBox.size = new Vector2(4.8f, 3.1f);
                myBottomBox.size = new Vector2(8.8f, 6.4f);
            }
        }
        else
        {
            if (spearExtended)
            {
                myTopBox.offset = new Vector2(1.74f, 3.1f);
                myBottomBox.offset = new Vector2(2f, -2.67f);
                myTopBox.size = new Vector2(4.8f, 3.1f);
                myBottomBox.size = new Vector2(12.76f, 6.4f);
            }
            else
            {
                myTopBox.offset = new Vector2(1.74f, 3.1f);
                myBottomBox.offset = new Vector2(8.8f, -2.67f);
                myTopBox.size = new Vector2(4.8f, 3.1f);
                myBottomBox.size = new Vector2(8.8f, 6.4f);
            }
        }
    }

    void endElectricHell()
    {
        state = 5;
        chargeCD = Random.Range(4, 7);
        lancelAnimScript.turnOffAllBools();
    }

    void death()
    {
        if (!mySprite.flipX)
        {
            myTopBox.offset = new Vector2(-1.43f, 3.1f);
            myBottomBox.offset = new Vector2(.56f, 6.4f);
        }
        else
        {
            myTopBox.offset = new Vector2(2.45f, 3.1f);
            myBottomBox.offset = new Vector2(.38f, 6.4f);
        }

        myTopBox.size = new Vector2(4.8f, 3.1f);
        myBottomBox.size = new Vector2(8.8f, 6.4f);
    }
}

