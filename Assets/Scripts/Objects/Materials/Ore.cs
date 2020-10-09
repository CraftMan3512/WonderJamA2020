using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : Item
{
    public Ore() : base("Diamant", Resources.Load<Sprite>("Sprites/Materials/diamant"), 2)
    {
    }
}
