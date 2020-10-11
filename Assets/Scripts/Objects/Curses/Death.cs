using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : Effect
{

    public Death()
    {
        description = "The Ultimate Goal";
        name = "Death";
        lastDay = true;

    }
    public override void Invoke(GameObject player)
    {
        if (player != null)
        {
            GameObject blood = GameObject.Instantiate((GameObject)Resources.Load("PlayerBlood"), null);
            blood.transform.position = player.transform.position;
            PlayerInputs.pControllers[int.Parse(player.name.Substring(1))] = null;
            GameObject.Destroy(player);
            
        }
    }

    public override void NextDay()
    {
      
    }
}
