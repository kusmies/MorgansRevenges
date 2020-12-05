using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LANCEL_ANIM_SCRIPT : MonoBehaviour
{
    LANCEL_SCRIPT lancelScript;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        lancelScript = GetComponent<LANCEL_SCRIPT>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(lancelScript.state)
        {
            case 1:
                myAnim.SetBool("isCharging", true);
                break;
            case 2:
                myAnim.SetBool("usingBallLightning", true);
                break;
            case 3:
                myAnim.SetBool("usingElectricHell1", true);
                break;
            case 4:
                myAnim.SetBool("usingElectricHell2", true);
                break;
            case 5:

                break;
            case 6:

                break;
            case 7:

                break;
            case 8:

                break;
            case 9:

                break;
            default:

                break;
        }
    }

    public void turnOffAllBools()
    {
        myAnim.SetBool("isCharging", false);
        myAnim.SetBool("usingBallLightning", false);
        myAnim.SetBool("usingElectricHell1", false);
        myAnim.SetBool("usingElectricHell2", false);
    }

    
}
