using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCHER_ANIM_SCRIPT : MonoBehaviour
{
    Animator myAnim;
    ARCHER_SCRIPT archerScript;
    public int state; //1 is walking, 2 is dead, 3 is hitstun, 4 straight shot, 5 is arc shot, 6 is idle

    // Start is called before the first frame update
    void Start()
    {
        archerScript = GetComponent<ARCHER_SCRIPT>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case 1: //walking
                myAnim.SetBool("isWalking", true);
                break;
            case 2: //dead
                myAnim.SetBool("isDead", true);
                break;

            case 3: //hitstun
                myAnim.SetBool("isHitStun", true);
                break;
            case 4: //straight shot
                myAnim.SetBool("isStraightShot", true);
                break;
            case 5: //arc shot
                myAnim.SetBool("isArcShot", true);
                break;
            case 6: //idle
                clearAllBools();
                break;
            default:
                state = 1;
                break;
        }

    }



    public void clearAllBools()
    {
        myAnim.SetBool("isWalking", false);
        myAnim.SetBool("isHitStun", false);
        myAnim.SetBool("isDead", false);
        myAnim.SetBool("isStraightShot", false);
        myAnim.SetBool("isArcShot", false);
    }
}
