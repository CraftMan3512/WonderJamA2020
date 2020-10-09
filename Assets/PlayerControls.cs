using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerControls : MonoBehaviour
{

    private Manette manette;

    public void GetPlayerGamepad(int index)
    {

        manette = PlayerInputs.GetPlayerController(index);

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    void MovePlayer()
    {

        transform.Translate(manette.leftStick);

    }
}
