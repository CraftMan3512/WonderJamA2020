using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Item
{
    public Stone() : base("Roche", Resources.Load<Sprite>("Sprites/Materials/roche"), 1)
    {
    }
}
