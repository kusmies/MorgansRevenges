using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATSURF_SCRIPT : MonoBehaviour
{
    public WATBOD_SCRIPT parent;

    public bool isDead = false;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            Destroy(gameObject);
        }
    }
}
