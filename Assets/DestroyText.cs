using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    [SerializeField] private float secondsToDestroy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, secondsToDestroy);
    }

    private void Update()
    {
        transform.position = new UnityEngine.Vector2(transform.position.x, transform.position.y + 0.1f);
    }

}
