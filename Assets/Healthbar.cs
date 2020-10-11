using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public GameObject player;
    public Slider slider;

    private void Start()
    {
        for(int i = 0;i<AlchemyValues.alchemyPlayers.Count;i++)
        {
            if(AlchemyValues.alchemyPlayers[i] == int.Parse(player.name.Substring(1)))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetCurrentHealth(float health)
    {
        slider.value = health;
    }
}
