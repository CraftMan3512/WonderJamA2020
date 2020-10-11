using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Random = UnityEngine.Random;

public class PlayerControls : MonoBehaviour
{

    private float currHp;
    public Healthbar Healthbar;
    public SpriteRenderer SpriteRenderer;
    public float rateOfLoss;
    public float maxHp;
    private Manette manette;
    public float startTimeBtwAttack;
    private double timeBtwAttack;
    public GameObject BloodParticles;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public float damage;
    public float moveSpeed;

    public bool lockMovement = false;
    public float interactRadius = 0.75f;

    private bool justGotDamaged;
    private float dmgToDeal;
    private float z;
    
    private Animator animator;
    private int playernb;

    public Manette Manette { get => manette; set => manette = value; }

    private void Start()
    {
        z = 0;
        animator = transform.Find("Sprite").GetComponent<Animator>();
        currHp = maxHp;
        Healthbar.SetMaxHealth(maxHp);
        transform.position = new Vector3(transform.position.x,transform.position.y,0f);
    }

    public void GetPlayerGamepad(int index)
    {

        playernb = index;
        Manette = PlayerInputs.GetPlayerController(index);
        animator = transform.Find("Sprite").GetComponent<Animator>();
        
        //sprite based on player
        switch (index)
        {
            
            case 0: animator.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Player/magerouge"); break;
            case 1: animator.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Player/magebleu"); break;
            case 2: animator.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Player/magerose"); break;
            case 3: animator.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Player/magevert"); break;
            
        }

    }

    private void Update()
    {
        //Attacks
        if (timeBtwAttack <= 0)
        {
            if (Manette.bButton.wasPressedThisFrame)
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().takeDamage(damage);
                }

                StartCoroutine(AttackAnim());
                
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

        if (Manette.aButton.wasPressedThisFrame && !lockMovement) CheckInteraction();

        //animations
        AnimationControl();
        //Take Damage
        float tempDmg;
        tempDmg= rateOfLoss * Time.deltaTime * dmgToDeal;
        currHp -= tempDmg;
        dmgToDeal -= tempDmg;
        //Color
        if (justGotDamaged)
        {
            z = 0.1f;
            justGotDamaged = false;
        }

        if (z > 0)
        {
            SpriteRenderer.color=Color.red;
            z -= Time.deltaTime;
        }else
        {
            SpriteRenderer.color=Color.white;
        }
        if (currHp <= 0)
        {
            Debug.Log("A player Died");
            Destroy(gameObject);
        }
    }

    void AnimationControl()
    {
        
        animator.SetFloat("speed",Manette.leftStick.magnitude);
        if (Manette.leftStick.magnitude > 0.2) animator.SetBool("moving", true);
        else animator.SetBool("moving", false);
        
        //flip sprite
        if (Manette.leftStick.magnitude > 0.2)
        {

            animator.GetComponent<SpriteRenderer>().flipX = (Manette.leftStick.x < 0);
            if (Manette.leftStick.x < 0) //gauche
            {
                attackPos.transform.localPosition = new Vector3(-0.87f, attackPos.transform.localPosition.y);
                if (GetComponent<PlayerGrabs>().HeldItem != null)
                {
                    GetComponent<PlayerGrabs>().HeldItem.transform.localPosition = new Vector3(-0.36f, 0.57f, -0.03f);
                }
            }
            else { //droite
                attackPos.transform.localPosition = new Vector3(0.87f, attackPos.transform.localPosition.y);
                if(GetComponent<PlayerGrabs>().HeldItem != null)
                {
                    GetComponent<PlayerGrabs>().HeldItem.transform.localPosition = new Vector3(0.36f, 0.57f, -0.03f);
                }
            }

        }

        Healthbar.SetCurrentHealth(currHp);
    }

    IEnumerator AttackAnim()
    {
        
        //Attack SFX
        GameObject.Find("SoundManager").GetComponent<SoundPlayer>().PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Attack0" + Random.Range(1,3).ToString()),0.3f);
        
        SpriteRenderer sr = animator.GetComponent<SpriteRenderer>();
        
        switch (playernb)
        {
            
            case 0: sr.sprite = Resources.Load<Sprite>("Sprites/Player/rougeslap"); break;
            case 1: sr.sprite = Resources.Load<Sprite>("Sprites/Player/bleuslap"); break;
            case 2: sr.sprite = Resources.Load<Sprite>("Sprites/Player/roseslap"); break;
            case 3: sr.sprite = Resources.Load<Sprite>("Sprites/Player/vertslap"); break;
            
        }
        
        yield return new WaitForSeconds(0.2f);
        
        switch (playernb)
        {
            
            case 0: sr.sprite = Resources.Load<Sprite>("Sprites/Player/magerouge"); break;
            case 1: sr.sprite = Resources.Load<Sprite>("Sprites/Player/magebleu"); break;
            case 2: sr.sprite = Resources.Load<Sprite>("Sprites/Player/magerose"); break;
            case 3: sr.sprite = Resources.Load<Sprite>("Sprites/Player/magevert"); break;
            
        }

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
    public void takeDamage(float dmg)
    {
        justGotDamaged = false;
        dmgToDeal+=dmg;
        justGotDamaged = true;
    }
}

