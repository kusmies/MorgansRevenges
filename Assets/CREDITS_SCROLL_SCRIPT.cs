﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CREDITS_SCROLL_SCRIPT : MonoBehaviour
{
    RectTransform myTran;
    // Start is called before the first frame update
    void Start()
    {
        myTran = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myTran.position.y < 3000)
        {
            myTran.position = new Vector2(myTran.position.x, myTran.position.y+.5f);
        }
    }
}