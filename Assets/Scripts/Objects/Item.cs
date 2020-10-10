using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public string name;
    public Sprite image;
    public int id;
    public int zone;
    public int qty;
    public float accuracy;

    public Item (string name, Sprite image, int id, int zone)
    {

        this.name = name;
        this.image = image;
        this.id = id;
        this.zone = zone;
        qty = 1;
        accuracy = 0;
    }

    public int getZone()
    {
        return zone;
    }
    
}
