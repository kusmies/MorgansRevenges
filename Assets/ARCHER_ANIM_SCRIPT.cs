using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCHER_ANIM_SCRIPT : MonoBehaviour
{
    Animator myAnim;
    ARCHER_SCRIPT archerScript;
    public bool isWalking = false;
    public bool isDead = false;
    public bool isHitStun = false;

    // Start is called before the first frame update
    void Start()
    {
        archerScript = GetComponent<ARCHER_SCRIPT>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            myAnim.SetBool("isWalking", true);
        }
        if(isDead)
        {
            myAnim.SetBool("isDead", true);
        }
        if(isHitStun)
        {
            myAnim.SetBool("isHitStun", true);
        }
    }

    public void endAttack()
    {

    }

    void clearAllBools()
    {
        myAnim.SetBool("isWalking", false);
        myAnim.SetBool("isHitStun", false);
        myAnim.SetBool("isDead", false);
        myAnim.SetBool("isStraightShot", false);
        myAnim.SetBool("isArcShot", false);
    }
}
