using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerJoinTester : MonoBehaviour
{
    private PlayerInput playerInput { get; set; }
    [Range(1,4)]
    public int playerNb = 0;

    private void Update()
    {

        if (PlayerExists(playerNb-1))
        {
            
            if (PlayerInputs.GetPlayerController(playerNb-1).gp.enabled)
            {
            
                Color col = GetComponent<Image>().color;
                float h,s,v;
                Color.RGBToHSV(col, out h, out s, out v);
                col = Color.HSVToRGB(h, s, 1);
                GetComponent<Image>().color = col;

            }   
            
        }

        if (PlayerExists(0))
        {

            if (PlayerInputs.GetPlayerController(0).selectButton.wasPressedThisFrame)
            {

                SceneManager.LoadScene("DayTransition",LoadSceneMode.Single);

            }
            
        }

    }

    private bool PlayerExists(int player)
    {

        //Debug.Log("Pla");
        return PlayerInputs.GetPlayerController(player) != null;

    }
}
