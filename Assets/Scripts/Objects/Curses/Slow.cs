using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Effect
{
   float slow;
   public Slow(float slowAmount)
   {
        name = "Slow "+(slow*100)+"%";
        slow = slowAmount;

   }

    public override void Invoke(GameObject player)
    {
        playerAffected = player;
        playerAffected.GetComponent<PlayerControls>().moveSpeed *= slow;
    }

    public override void NextDay()
    {
        playerAffected.GetComponent<PlayerControls>().moveSpeed /= slow;
    }


}
