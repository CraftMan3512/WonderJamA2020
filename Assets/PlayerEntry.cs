﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEntry : MonoBehaviour
{
    /*void OnPlayerJoined(PlayerInput player)
    {
        
        Debug.Log("PLAYERJOINED: ");
        PlayerInputs.SetPlayerController(player.devices[0],0);

    }*/

    private void Start()
    {

        //ajouter le clavier aux manettes
        PlayerInputs.gamepads.Add(new Manette());
        
        foreach (Gamepad gp in Gamepad.all)
        {
            
            PlayerInputs.gamepads.Add(new Manette(gp));
            
        }
        
        
    }

    private void Update()
    {
        
        InputSystem.onDeviceChange += (device, change) =>
        {

            switch (change)
            {
                
                case InputDeviceChange.Added :
                    if (!ManetteContains((Gamepad)device))
                    {
                        
                        PlayerInputs.gamepads.Add(new Manette((Gamepad)device));
                        Debug.Log("ADDED DEVICE " + device.displayName);   
                        
                    }
                    break;
                case InputDeviceChange.Removed:
                    RemoveManette((Gamepad)device);
                    break;
                    
                
            }

        };
        //Debug.Log("WE HAVE " + PlayerInputs.gamepads.Count + " GAMEPADS!");
        foreach (Manette man in PlayerInputs.gamepads)
        {

            if (man.joinButton.IsPressed() && (!PlayerInputs.pControllers.Contains(man)))
            {
                
                PlayerInputs.AddPlayerController(man);
                
            }
            
        }
        
    }

    private bool ManetteContains(Gamepad gp)
    {

        bool contains = false;
        foreach (Manette man in PlayerInputs.gamepads)
        {

            if (man.gp == gp) contains = true;

        }

        return contains;

    }

    private void RemoveManette(Gamepad gp)
    {

        Manette toRemove = null;
        foreach (Manette man in PlayerInputs.gamepads)
        {

            if (man.gp == gp) toRemove = man;

        }

        if (toRemove != null) PlayerInputs.gamepads.Remove(toRemove);

    }
}
