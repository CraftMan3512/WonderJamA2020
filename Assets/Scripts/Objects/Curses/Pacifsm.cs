﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacifsm : Effect
{
    float damageReduction = 0;
    public Pacifsm(float amount)
    {
        name = "Pacifism";
        damageReduction = 0;
        
    }

    public override void Invoke(GameObject player)
    {
        playerAffected = player;
        playerAffected.GetComponent<PlayerControls>().damage 
    }

    public override void NextDay()
    {
        
    }
}