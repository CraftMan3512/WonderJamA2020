﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerControls : MonoBehaviour
{

    private Manette manette;
    public float startTimeBtwAttack;
    private float timeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public float moveSpeed;
    
    public void GetPlayerGamepad(int index)
    {

        manette = PlayerInputs.GetPlayerController(index);

    }

    private void Update()
    {
        //Attacks
        if (timeBtwAttack <= 0)
        {
            if (manette.bButton.wasPressedThisFrame)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange,whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length ;i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
                    Debug.Log("Touche un enemie");
                }

            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (manette.bButton.wasPressedThisFrame) CheckInteraction();

    }

    void CheckInteraction()
    {
        
                
        
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    void MovePlayer()
    {
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x,transform.position.y)+(manette.leftStick*Time.deltaTime*moveSpeed));
    }
}

