﻿using System.Collections;
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

    public void AddCurse(float severity, GameObject player) // la sévérité commence autour de 0.2 et fini proche de 10-20 probablement pas trop certain tho
    {
        Effect curse;
        int randomCurse = Random.Range(0, 2);
        switch (randomCurse)
        {
            case 0: if (severity >= 50) { severity = 40; }                                                                 
                       curse = new Slow(2 * severity);
                break;
            case 1:     curse = new Sheep(4*severity);
                break;

            default:
                curse = new Sheep(4 * severity);
                break;
        }
        

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
