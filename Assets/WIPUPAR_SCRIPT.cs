using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIPUPAR_SCRIPT : MonoBehaviour
{
    Transform myTran;
    Rigidbody2D myBody;
    public Vector2 startPosition;
    float speed;
    float dir;
    SpriteRenderer mySprite;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        myTran = GetComponent<Transform>();
        myBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        speed = Random.Range(0f, 1f);
        dir = Random.Range(-1f, 1f);
        myBody.velocity = new Vector2(dir*10, -speed*10);
        startY = myTran.position.y;
        float whichColor = Random.Range(0f, 1f);
        
        if (whichColor <= .25)
        {
            mySprite.color = new Color32(0, 108, 10, 255); //Dark Green
        }
        else if (whichColor <= .5)
        {
            mySprite.color = new Color32(0, 255, 31, 255); //Green
        }
        else if (whichColor <= .75)
        {
            mySprite.color =  new Color32(107, 45, 0, 255); //Brown
        }
        else
        {
            mySprite.color = new Color32(107, 3, 0, 255); //Dark Red
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(myTran.position.y < startY-5f)
        {
            Destroy(gameObject);
        }
        myTran.eulerAngles += Vector3.forward * (dir * 100);

    }
}
