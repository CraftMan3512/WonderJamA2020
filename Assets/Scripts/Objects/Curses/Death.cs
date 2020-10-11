using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            bool checkAllDead = true;
            for(int i = 0; i < PlayerInputs.pControllers.Length; i++)
            {
                if(PlayerInputs.pControllers[i] != null)
                {
                    checkAllDead = false;
                }
            }

            if (checkAllDead)
            {
                SceneManager.LoadScene("End");
            }
            GameObject.Destroy(player);
            
        }
    }

    public override void NextDay()
    {
      
    }
}
