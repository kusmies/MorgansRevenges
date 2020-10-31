using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PATROL_SCRIPT : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool movingRight = false;

    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "trigger")
        {
            
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
        }
    }
}
