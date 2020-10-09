using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public Recipe(Item[] items)
    {
        this.items = items;
    }
    public Item[] items;
    public Effect effect;
    
}
