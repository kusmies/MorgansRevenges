using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOLDIER_ANIM_SCRIPT : MonoBehaviour
{

    Animator myAnim;
    SOLDIER_SCRIPT soldierScript;
    bool isHighAttacking1 = false;
    public bool isHighAttacking2 = false;
    public bool isHighAttacking3 = false;
    bool isLowAttacking = false;
    public bool isWalking = false;
    bool landingReady = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        soldierScript = GetComponent<SOLDIER_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            myAnim.SetBool("isWalking", true);
        }
        else
        {
            myAnim.SetBool("isWalking", false);
        }

        isDead = soldierScript.isDead;

        if(isDead)
        {
            myAnim.SetBool("isDead", true);
        }

        highAttackStage3();
    }

    public void chooseAttack()
    {
        myAnim.SetBool("isWalking", false);

        float whichAttack = Random.Range(0.0f, 1.0f);

        if (whichAttack <= .5)
        {
            myAnim.SetBool("lowAttack", true);
            isLowAttacking = true;
        }
        else
        {
            myAnim.SetBool("highAttack1", true);
            isHighAttacking1 = true;
        }
    }

    public void highAttackStage2()
    {
        myAnim.SetBool("highAttack1", false);
        myAnim.SetBool("highAttack2", true);
        isHighAttacking1 = false;
        isHighAttacking2 = true;
    }

    void setLandingReady()
    {
        landingReady = true;
    }

    void highAttackStage3()
    {
        if(soldierScript.isGrounded && isHighAttacking2 && landingReady)
        {
            isHighAttacking2 = false;
            myAnim.SetBool("highAttack2", false);
            isHighAttacking3 = true;
            myAnim.SetBool("highAttack3", true);
            landingReady = false;
        }
    }

    void endAttack()
    {
        myAnim.SetBool("lowAttack",false);
        myAnim.SetBool("highAttack1", false);
        myAnim.SetBool("highAttack2", false);
        myAnim.SetBool("highAttack3", false);
        isHighAttacking1 = false;
        isHighAttacking2 = false;
        isHighAttacking3 = false;
        isLowAttacking = false;
        soldierScript.isAttacking = false;
        landingReady = false;

    }
}
