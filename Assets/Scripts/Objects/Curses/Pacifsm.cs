﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacifsm : Effect
{
    float damageReduction = 0;
    public Pacifsm(float amount)
    {
        name = "Pacifism";
        description = "Because genocide was never the answer";
        damageReduction = 0;
        
    }

    public override void Invoke(GameObject player)
    {
        playerAffected = player;
        playerAffected.GetComponent<PlayerControls>().damage *= (1f - damageReduction); 
    }

    public override void NextDay()
    {
        if (playerAffected != null)
        {
            playerAffected.GetComponent<PlayerControls>().damage /= (1f - damageReduction);
        }
    }

}
