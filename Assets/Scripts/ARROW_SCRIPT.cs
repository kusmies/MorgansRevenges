using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARROW_SCRIPT : MonoBehaviour
{
    SpriteRenderer mySprite;
    Transform myTran;
    BoxCollider2D myBox;
    public Rigidbody2D myBody;
    public DFACT1_HANDLER_SCRIPT actHandler;
    bool isDead;
    [SerializeField] public LayerMask groundLayer;
    POWER_SCRIPT myPower;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBox = GetComponent<BoxCollider2D>();
        mySprite = GetComponent<SpriteRenderer>();
        myTran = GetComponent<Transform>();
        myPower = GetComponent<POWER_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myTran.position.y <= -40)
        {
            Destroy(gameObject);
        }
        if(actHandler.levelComplete)
        {
            Destroy(gameObject);
        }


        Vector2 v = myBody.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            if (playerPower.type == 1)
            {
                myBody.velocity = new Vector2(0f, 0f);
                mySprite.color = new Color32(0, 255, 245, 255);
                myPower.Damage = 0;
                gameObject.tag = "Untagged";
                gameObject.layer = 0;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            var playerPower = collision.gameObject.GetComponent<POWER_SCRIPT>();

            if (playerPower.type == 1)
            {
                myBody.velocity = new Vector2(0f, 0f);
                mySprite.color = new Color32(0, 255, 245, 255);
                myPower.Damage = 0;
                gameObject.tag = "Untagged";
                gameObject.layer = 0;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
    
}
