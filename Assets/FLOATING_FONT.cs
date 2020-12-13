using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLOATING_FONT : MonoBehaviour
{

    [SerializeField] private GameObject floatingTextPrefab;


    // Update is called once per frame
    public void showText(string text)
    {
        if (floatingTextPrefab)
        {
            Debug.Log("textspawned");
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

        }
    }


  
}