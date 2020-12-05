using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATSUB_SCRIPT : MonoBehaviour
{
    public WATBOD_SCRIPT parent;

    public bool isFrozen = false;

    BoxCollider2D myBox;

    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();

        myBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFrozen)
        {
            myAnim.SetBool("isFrozen", true);
            gameObject.tag = "Ground";
            gameObject.layer = 8;
            myBox.isTrigger = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {

            var powerScript = collision.gameObject.GetComponent<POWER_SCRIPT>();

            if (powerScript.type == 1)
            {
                parent.isFrozen = true;
            }
        }

    }
}
