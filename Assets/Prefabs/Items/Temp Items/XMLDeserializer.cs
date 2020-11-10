using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMLDeserializer : MonoBehaviour
{
    public static XMLDeserializer deseralized;

    void awake()
    {
        deseralized = this;
    }    
    // Start is called before the first frame update
    void Start()
    {
        TEMPITEMS_CLASS bronze = XMLOp.Deserialize<TEMPITEMS_CLASS>("bronze.xml");
       // Debug.Log(bronze.name);
        TEMPITEMS_CLASS silver = XMLOp.Deserialize<TEMPITEMS_CLASS>("silver.xml");
       // Debug.Log(silver.name);
        TEMPITEMS_CLASS steelhelm = XMLOp.Deserialize<TEMPITEMS_CLASS>("helm.xml");
       // Debug.Log(steelhelm.name);
        TEMPITEMS_CLASS steelshield = XMLOp.Deserialize<TEMPITEMS_CLASS>("shield.xml");
       // Debug.Log(steelshield.name);
    }


}
