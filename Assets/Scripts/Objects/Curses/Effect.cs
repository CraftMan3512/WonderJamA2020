using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Effect
{
    public bool lastDay = false;
    public string name;
    public string description;
    protected GameObject playerAffected;
    public abstract void Invoke(GameObject player);

    public abstract void NextDay();

}
