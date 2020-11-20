using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WARDOG_ANIM_SCRIPT : MonoBehaviour
{
    Animator myAnim;
    WARDOG_SCRIPT wardogScript;
    public bool isWalking = false;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        wardogScript = GetComponent<WARDOG_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            myAnim.SetBool("isWalking", true);
        }
        else
        {
            myAnim.SetBool("isWalking", false);
        }

        isDead = wardogScript.isDead;

        if (isDead)
        {
            myAnim.SetBool("isDead", true);
        }
    }
}
