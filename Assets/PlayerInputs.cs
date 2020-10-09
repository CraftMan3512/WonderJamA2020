using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class PlayerInputs
{
    
    public static Manette[] pControllers = new Manette[4];
    private static int playerAdded = 0;
    public static List<Manette> gamepads = new List<Manette>();
    
    public static void SetPlayerController(Manette device, int player)
    {

        if (player >= 0 && player < 4)
        {

            pControllers[player] = device;

        }
        
    }

    public static Manette GetPlayerController(int player)
    {

        if (player >= 0 && player < 4) return pControllers[player];
        else return null;

    }

    public static void AddPlayerController(Manette ctrl)
    {

        if (playerAdded < 4)
        {
            
            pControllers[playerAdded] = ctrl;
            playerAdded++;
            Debug.Log("New player added to game: ");
            
        }

    }
    
    
}
