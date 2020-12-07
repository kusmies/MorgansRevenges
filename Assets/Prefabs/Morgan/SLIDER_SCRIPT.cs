using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLIDER_SCRIPT : MonoBehaviour
{
    public Slider Bar;
   
    public void SetMaxBar(float value)
    {
        Bar.maxValue = value;
        Bar.value = value;


        
    }

    public void SetBar(float value)
    {
        Bar.value = value;
       
    }


  
}
