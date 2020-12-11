﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_ITEM_FONT : MonoBehaviour
{
    public int ID;
    [SerializeField] private GameObject floatingTextPrefab;
    // Start is called before the first frame update
    void Start()
    {
      
    


    }

// Update is called once per frame
void showText(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

        }
    }
}