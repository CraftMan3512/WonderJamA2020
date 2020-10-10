using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public string name;
    public Sprite image;
    public int id;
    public int zone;

    public Item (string name, Sprite image, int id, int zone)
    {

        this.name = name;
        this.image = image;
        this.id = id;
        this.zone = zone;
    }

    public int getZone()
    {
        return zone;
    }
    
}
