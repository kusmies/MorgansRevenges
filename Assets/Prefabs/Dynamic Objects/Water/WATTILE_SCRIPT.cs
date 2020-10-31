using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATTILE_SCRIPT : MonoBehaviour
{
    public CHASEN_SCRIPT level;

    public bool isFrozen;
    public bool isSurface;
    private Animation myAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Water")
        {
            level.changeScene(2);
        }
    }
}
