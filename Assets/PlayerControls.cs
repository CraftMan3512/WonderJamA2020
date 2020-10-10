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
    public float interactRadius = 0.75f;

    private Animator animator;

    public Manette Manette { get => manette; set => manette = value; }

    private void Start()
    {
        animator = transform.Find("Sprite").GetComponent<Animator>();
    }

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

        if (Manette.aButton.wasPressedThisFrame && !lockMovement) CheckInteraction();

        //animations
        AnimationControl();

    }

    void AnimationControl()
    {
        
        animator.SetFloat("speed",Manette.leftStick.magnitude);
        if (Manette.leftStick.magnitude > 0.2) animator.SetBool("moving", true);
        else animator.SetBool("moving", false);


    }

    void CheckInteraction()
    {
        
        Collider2D[] thingsNear = Physics2D.OverlapCircleAll(transform.position, interactRadius);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,interactRadius);
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

