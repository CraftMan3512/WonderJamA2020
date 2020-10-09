using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Effect
{
   float slow;
   public Slow(float slowAmount)
   {
        slow = slowAmount;

   }

    public override void Invoke(GameObject player)
    {
        playerAffected = player;
        player.GetComponent<PlayerControls>();
    }

    public override void NextDay()
    {
        
    }


}
