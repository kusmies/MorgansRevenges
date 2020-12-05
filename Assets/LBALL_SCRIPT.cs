using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBALL_SCRIPT : MonoBehaviour
{
    public Transform myTran;
    public LANCEL_SCRIPT lancelot;
    CircleCollider2D myCircle;
    Rigidbody2D myBody;
    public DFACT2_HANDLER_SCRIPT actHandler;
    public int electricHellIDNumber = 0; //Electric hell has the same pattern every time. Because of this, every lightning ball spawned during that attack has an ID number that determines where it starts.
    public int stage; //1 is moving up during Ball Lightning, 2 is moving down during ball lightning, 3 is moving left during electric hell, 4 is moving right during electric hell

    // Start is called before the first frame update
    void Start()
    {
        myCircle = GetComponent<CircleCollider2D>();
        myBody = GetComponent<Rigidbody2D>();
        myTran = GetComponent<Transform>();
        //Debug.Log("I have been spawned");
    }

    // Update is called once per frame
    void Update()
    {
        switch(stage)
        {
            case 1://1 is moving up during ball lightning
                if(myTran.position.y >= 100f)
                {
                    killSelf();
                }
                if (myTran.position.y >= 70f)
                {
                    myTran.position = new Vector2(actHandler.playerPosition.x, myTran.position.y);
                    stage = 2;
                }
                else
                {
                    myBody.velocity = new Vector2(0f, 20f);
                }
                break;
            case 2://Moving down during ball lightning.
                if (myTran.position.y <= -20f)
                {
                    killSelf();
                }
                else
                {
                    myBody.velocity = new Vector2(0f, -20f);
                }
                break;
            case 3://Moving right to left during electric hell
                if (myTran.position.x <= -83)
                {
                    killSelf();
                }
                else
                {
                    myBody.velocity = new Vector2(-20f, 0f);
                }
                break;
            case 4://Moving left to right during electric hell
                if (myTran.position.x >= 89)
                {
                    killSelf();
                }
                else
                {
                    myBody.velocity = new Vector2(20f, 0f);
                }
                break;
            default:
                {
                    killSelf();
                }
                break;
        }
        
    }

    void killSelf()
    {
        lancelot.bulletsSpawned--;
        Destroy(gameObject);
    }

    public void setUpElectricHell()
    {
        
        if (stage == 3)
        { 
            switch (electricHellIDNumber)
            {
                case 1:
                    myTran.position = new Vector2(91f, 16.03f);
                    break;
                case 2:
                    myTran.position = new Vector2(105f, 23.22f);
                    break;
                case 3:
                    myTran.position = new Vector2(129f, 8.84f);
                    break;
                case 4:
                    myTran.position = new Vector2(143f, 23.22f);
                    break;
                case 5:
                    myTran.position = new Vector2(157f, 8.84f);
                    break;
                case 6:
                    myTran.position = new Vector2(171f, 8.84f);
                    break;
                case 7:
                    myTran.position = new Vector2(185f, 16.03f);
                    break;
                case 8:
                    myTran.position = new Vector2(199f, 23.22f);
                    break;
                case 9:
                    myTran.position = new Vector2(213f, 8.84f);
                    break;
                case 10:
                    myTran.position = new Vector2(227f, 16.03f);
                    break;
                default:
                    Debug.Log("Invalid bullet");
                    killSelf();
                    break;
            }
        }
        else if (stage == 4)
        {
            switch (electricHellIDNumber)
            {
                case 1:
                    myTran.position = new Vector2(-83f, 16.03f);
                    break;
                case 2:
                    myTran.position = new Vector2(-97f, 23.22f);
                    break;
                case 3:
                    myTran.position = new Vector2(-111f, 8.84f);
                    break;
                case 4:
                    myTran.position = new Vector2(-125f, 23.22f);
                    break;
                case 5:
                    myTran.position = new Vector2(-139f, 8.84f);
                    break;
                case 6:
                    myTran.position = new Vector2(-153f, 8.84f);
                    break;
                case 7:
                    myTran.position = new Vector2(-167f, 16.03f);
                    break;
                case 8:
                    myTran.position = new Vector2(-181f, 23.22f);
                    break;
                case 9:
                    myTran.position = new Vector2(-195f, 8.84f);
                    break;
                case 10:
                    myTran.position = new Vector2(-209f, 16.03f);
                    break;
                default:
                    Debug.Log("Invalid bullet");
                    killSelf();
                    break;
            }
        }
        else
        {
            Debug.Log("Invalid bullet. Terminating");
            
            killSelf();
        }

    }
}
