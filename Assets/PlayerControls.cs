using System;
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

    public bool lockMovement = false;

    public Manette Manette { get => manette; set => manette = value; }

    public void GetPlayerGamepad(int index)
    {

        Manette = PlayerInputs.GetPlayerController(index);

    }

    private void Update()
    {
        //Attacks
        if (timeBtwAttack <= 0)
        {
            if (Manette.bButton.wasPressedThisFrame)
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

        if (Manette.aButton.wasPressedThisFrame) CheckInteraction();

    }

    void CheckInteraction()
    {
        
        Collider2D[] thingsNear = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach (var station in thingsNear)
        {

            if (station.CompareTag("Station"))
            {

                station.GetComponent<Interactable>().Interact(gameObject);
                break;
            }
            
        }

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
        if (!lockMovement) GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x,transform.position.y)+(Manette.leftStick*Time.deltaTime*moveSpeed));
    }
}

