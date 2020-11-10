

using System;
using System.Xml.Serialization;

[Serializable]
public class TEMPITEMS_CLASS
{
    [XmlAttribute("ID")]
    public int ID;
    [XmlAttribute("name")]

    public string name;
    [XmlAttribute("currency")]

    public string currency;
    [XmlAttribute("price")]

    public int price;
    [XmlAttribute("got")]

    public bool got;


}
