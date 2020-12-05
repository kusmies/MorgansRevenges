using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLManager : MonoBehaviour
{
    public static XMLManager ins;
    void Awake()
    {
        ins = this;
    }

    public ItemDatabase itemDB;
    public void SaveItems()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/XML/item_data.xml", FileMode.Create);
        serializer.Serialize(stream, itemDB);
        stream.Close();
    }
    public void LoadItems()
    {

        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/XML/item_data.xml", FileMode.Open);
        itemDB = serializer.Deserialize(stream) as ItemDatabase;
        stream.Close();
    }

    public PermItemDatabase PitemDB;
    public void PermSaveItems()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PermItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/XML/perm_item_data.xml", FileMode.Create);
        serializer.Serialize(stream, PitemDB);
        stream.Close();
    }
    public void PermLoadItems()
    {

        XmlSerializer serializer = new XmlSerializer(typeof(PermItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/XML/perm_item_data.xml", FileMode.Open);
        PitemDB = serializer.Deserialize(stream) as PermItemDatabase;
        stream.Close();
    }
}

[System.Serializable]
public class ItemEntry
{
    public int ID;
    public string name;
    public string description;
    public int value;
    public Currency currency;
    public int price;
    public bool got;
    public bool chestdropped;
}
[System.Serializable]
public class ItemDatabase
{
    [XmlArray("TempItems")]
    public List<ItemEntry> list = new List<ItemEntry>();
}

[System.Serializable]
public class PermItemEntry
{
    public int ID;
    public string name;
    public string description;
    public int value;
    public Currency currency;
    public int price;
    public bool unlocked;
}
[System.Serializable]
public class PermItemDatabase
{
    [XmlArray("PermItems")]
    public List<PermItemEntry> list = new List<PermItemEntry>();
}
public enum Currency
{
  Gold,
  soul
}