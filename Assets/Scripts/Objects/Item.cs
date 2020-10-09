using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    public string name;
    public Sprite image;
    public int id;

    public Item (string name, Sprite image, int id)
    {

        this.name = name;
        this.image = image;
        this.id = id;

    }
    
}
