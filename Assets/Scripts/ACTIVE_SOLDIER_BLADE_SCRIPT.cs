using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTIVE_SOLDIER_BLADE_SCRIPT : MonoBehaviour
{
    public SOLDIER_SCRIPT mySoldier;
    BoxCollider2D myBox;
    Transform myTran;
    POWER_SCRIPT myPower;
    public int type = 0; //1 is low right, 2 is low left, 3 is air right, 4 is air left

    // Start is called before the first frame update
    void Start()
    {
        myBox = GetComponent<BoxCollider2D>();
        myTran = GetComponent<Transform>();
        myPower = GetComponent<POWER_SCRIPT>();
        switch (type)
            {
            case 1:
                myTran.localScale = new Vector2(1.4f, 1.2f);
                
                break;

            case 2:
                myTran.localScale = new Vector2(1.4f, 1.2f);
                
                break;

            case 3:
                myTran.localScale = new Vector2(3.1f,4.36f);
                
                break;

            case 4:
                myTran.localScale = new Vector2(3.1f, 4.36f);
                
                break;

            default:
                Debug.Log("Non-applicable type for blade");
                break;

            }
    }

    // Update is called once per frame
    void Update()
    {
        if(!mySoldier.isAttacking || (mySoldier.isHighAttacking2 == false && mySoldier.isHighAttacking3 == true) || mySoldier.isDead)
        {
            killBlade();
        }

        switch (type)
        {
            case 1:
                myTran.position = new Vector2(mySoldier.myTran.position.x + 2.4f, mySoldier.myTran.position.y);
                break;

            case 2:
                myTran.position = new Vector2(mySoldier.myTran.position.x - 2.4f, mySoldier.myTran.position.y);
                break;

            case 3:
                myTran.position = new Vector2(mySoldier.myTran.position.x + 1.54f, mySoldier.myTran.position.y - 1.0f);
                break;

            case 4:
                myTran.position = new Vector2(mySoldier.myTran.position.x - 1.54f, mySoldier.myTran.position.y - 1.0f);
                break;

            default:
                Debug.Log("Non-applicable type for blade");
                break;
        }
    }

    void killBlade()
    {
        
        Destroy(gameObject);
    }
}
