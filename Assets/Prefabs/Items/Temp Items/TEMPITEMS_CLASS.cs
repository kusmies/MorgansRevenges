

using System;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class TEMPITEMS_CLASS
{
    //players id
    [XmlAttribute("ID")]
    public int ID;
    //player name
    [XmlElement("name")]
    public string name;
    //players currency
    [XmlElement("currency")]

    public string currency;
    //players price
    [XmlElement("price")]

    //players get status
    public int price;
    [XmlElement("got")]

    public bool got;


}

