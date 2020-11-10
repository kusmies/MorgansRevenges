using UnityEngine;
using System.Xml.Serialization;
using System.IO;
public class XMLSerializer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        TEMPITEMS_CLASS bronze = new TEMPITEMS_CLASS();

        bronze.ID = 1;
        bronze.name = "BronzeRing";
        bronze.currency = "Gold";
        bronze.price = 4;
        bronze.got = false;

        XMLOp.Serialize(bronze, "bronze.xml");
        TEMPITEMS_CLASS silver = new TEMPITEMS_CLASS();

        silver.ID = 2;
        silver.name = "SilverRing";
        silver.currency = "Gold";
        silver.price = 8;
        silver.got = false;

        XMLOp.Serialize(silver, "silver.xml");
        TEMPITEMS_CLASS SteelHelm = new TEMPITEMS_CLASS();

        SteelHelm.ID = 3;
        SteelHelm.name = "SteelHelm";
        SteelHelm.currency = "Gold";
        SteelHelm.price = 2;
        SteelHelm.got = false;

        XMLOp.Serialize(SteelHelm, "helm.xml");
        TEMPITEMS_CLASS SteelShield = new TEMPITEMS_CLASS();

        SteelShield.ID = 4;
        SteelShield.name = "SteelShield ";
        SteelShield.currency = "Gold";
        SteelShield.price = 4;
        SteelShield.got = false;

        XMLOp.Serialize(SteelShield, "shield.xml");

    }


}
