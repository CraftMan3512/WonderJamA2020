using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<Effect>[] playerEffects = new List<Effect>[PlayerInputs.playerAdded];
    

    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Manager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            for (int i = 0; i < playerEffects.Length; i++)
            {
                playerEffects[i] = new List<Effect>();
            }
        }
        
    }

    public void AddCurse(Effect curse, GameObject player)
    {

        playerEffects[int.Parse(player.name.Substring(1))].Add(curse);
        curse.Invoke(player);
       
    }

    public void NextDay()
    {
        
        for(int i = 0; i < playerEffects.Length; i++)
        {
            foreach(Effect effect in playerEffects[i])
            {
                if (effect.lastDay)
                {
                    effect.NextDay();
                    playerEffects[i].Remove(effect);
                }else
                {
                    effect.Invoke(GameObject.Find("p"+i));
                    effect.lastDay = true;
                }
            }
        }
    
    }

    public void RemoveCurse(Effect curse)
    {
        for(int i = 0; i < playerEffects.Length; i++)
        {
            foreach (Effect effect in playerEffects[i])
            {
                if (effect == curse)
                {
                    playerEffects[i].Remove(curse);
                }
            }
        }
    }


    public void StartChildCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

}
