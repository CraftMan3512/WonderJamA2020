using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lag : Effect
{
    int lagTimes;
    GameObject manager;
    public Lag(int lags)
    {
        name = "Lag";
        description = "Anybody else experiencing rollbacks right now?";
        lagTimes = lags;
        manager = GameObject.Find("CurseManager");
        lastDay = true;
       
    }
    public override void Invoke(GameObject player)
    {

        playerAffected = player;
        manager.GetComponent<Manager>().StartChildCoroutine(Lagging());

    }

    IEnumerator Lagging()
    {
        
        if(playerAffected != null)
        {
            Vector3 posPlayer = playerAffected.transform.position;
            for (int i = 0; i < lagTimes; i++)
            {
                
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
                if(playerAffected != null)
                {
                   posPlayer = playerAffected.transform.position;
                }
                yield return new WaitForSeconds(Random.Range(0.5f, 2f));
                if (playerAffected != null)
                {
                    playerAffected.transform.position = posPlayer;
                }

            }


        }
    }

    public override void NextDay()
    {
        if (playerAffected != null)
        {
           
                GameObject.Find("CurseManager").GetComponent<Manager>().RemoveCurse(this);
            
        }

    }
}
