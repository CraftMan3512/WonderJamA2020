using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float moveSpeed;
    public GameObject prefab;
    private GameObject blood;
    private bool justGotDamaged;
    public float timeRed;
    public int itemID;
    private float z;
    public bool isEnvironment;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float startScale;
    private Vector3 closestDirection;
    
    public float startTimeBtwAttack;
    private double timeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public int damage;
    public bool isAnimated;

    private GameObject[] allPlayers;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        allPlayers=GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale.x;
        prefab = Resources.Load<GameObject>("ItemPrefab");
        z = 0;
        blood = Resources.Load<GameObject>("Blood");
        if (isAnimated)
        {
            animator=GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnvironment)
        {
            Vector3 direction;
            closestDirection = Vector3.zero;

            for (int i = 0; i < allPlayers.Length; i++)
            {
                if (allPlayers[i] != null)
                {
                    direction = allPlayers[i].GetComponent<Transform>().position - transform.position;
                    if (i == 0)
                    {
                        closestDirection = direction;
                    }
                    else if (direction.magnitude < closestDirection.magnitude)
                    {
                        closestDirection = direction;
                    }
                }
            }

            //Chase
            if (closestDirection.x < 0)
                transform.localScale = new Vector3(-startScale, transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(startScale, transform.localScale.y, transform.localScale.z);
            if (closestDirection.magnitude > 8)
            {
                closestDirection = Vector3.zero;
            }

            closestDirection.Normalize();
            movement = closestDirection;
        }

        if (health <= 0)
        {
            var position = transform.position;
            GameObject temp = Instantiate(prefab, position, Quaternion.identity);
            temp.GetComponent<ItemCreator>().setItem(AlchemyValues.materialPool[itemID]);
            if (!isEnvironment)
                Instantiate(blood, position, Quaternion.identity);

            //Dying stuff here
            Destroy(gameObject);
            
            //SFX
            GameObject.Find("SoundManager").GetComponent<SoundPlayer>().PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Death"));

        }
        

        //Color
            if (justGotDamaged)
            {
                z = timeRed;
                justGotDamaged = false;
            }
        

        if (z > 0)
        {
            GetComponent<SpriteRenderer>().color=Color.red;
            z -= Time.deltaTime;
        }else
        {
            GetComponent<SpriteRenderer>().color=Color.white;
        }

        if (damage > 0&&!isEnvironment)
        {
            if (timeBtwAttack <= 0)
            {
                
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
                if (enemiesToDamage.Length > 0)
                {
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        if(enemiesToDamage[i].CompareTag("Player"))
                            enemiesToDamage[i].GetComponent<PlayerControls>().takeDamage(damage);
                    }
                    timeBtwAttack = startTimeBtwAttack;
                }

            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        } 
        if(isAnimated)
           AnimationControl();
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    
    

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position+(direction*moveSpeed*Time.deltaTime));
    }

    public void takeDamage(float dmg)
    {
        justGotDamaged = false;
        health -= dmg;
        justGotDamaged = true;
        
        //SFX
        GameObject.Find("SoundManager").GetComponent<SoundPlayer>().PlaySFX(Resources.Load<AudioClip>("SFX/SFX_Damage0" + Random.Range(1,3).ToString()));
    }
    
    void OnDrawGizmosSelected()
    {
        if (attackPos != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }

    void AnimationControl()
    {
        if (movement!=Vector2.zero) animator.SetBool("Walking", true);
        else animator.SetBool("Walking", false);
    }
}
