using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Effect
{
   float slow;
   public Slow(float slowAmount)
   {
        slow = slowAmount;
        name = "Slow "+(slow*100)+"%";
        description = "Pretty self-explanatory...";     

   }

    public override void Invoke(GameObject player)
    {
        playerAffected = player;
        playerAffected.GetComponent<PlayerControls>().moveSpeed *= (1-slow);
    }

    public override void NextDay()
    {
        if (playerAffected != null)
        {
            playerAffected.GetComponent<PlayerControls>().moveSpeed /= (1 - slow);
        }
    }


}
