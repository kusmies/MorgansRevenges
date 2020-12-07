using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Build.Content;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEngine.UI;
using System.Linq;
using System;
public class TEMP_ITEM_PREFAB : MonoBehaviour
{
    public static TEMP_ITEM_PREFAB tempitemprefab;
    public Image itemspriterenderer;
    public Text Name, price, description;
    public int AssignedNumber;

    private void Awake()
    {
        tempitemprefab = this;
    }

}
