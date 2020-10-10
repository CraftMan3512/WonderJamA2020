using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float moveSpeed;
    public GameObject prefab;
    public GameObject blood;
    private bool justGotDamaged;
    public float timeRed;
    public int itemID;
    private float z;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float startScale;
    private Vector3 closestDirection;
    
    public float startTimeBtwAttack;
    private double timeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsPlayers;
    public float attackRange;
    public int damage;

    private GameObject[] allPlayers;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        allPlayers=GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale.x;
        prefab = Resources.Load<GameObject>("ItemPrefab");
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        closestDirection  = Vector3.zero;
        
        for (int i = 0; i < allPlayers.Length; i++)
        {
            direction = allPlayers[i].GetComponent<Transform>().position - transform.position;
            if (i == 0)
            {
                closestDirection = direction;
            }else 
            if (direction.magnitude < closestDirection.magnitude)
            {
                closestDirection = direction;
            }
        }
        //Chase
        if (closestDirection.x < 0)
            transform.localScale = new Vector3(-startScale,transform.localScale.y,transform.localScale.z);
        else
            transform.localScale = new Vector3(startScale,transform.localScale.y,transform.localScale.z);
        
        closestDirection.Normalize();
        movement = closestDirection;
        
        if (health <= 0)
        {
            GameObject temp = Instantiate(prefab, transform.position, Quaternion.identity);
            temp.GetComponent<ItemCreator>().setItem(AlchemyValues.materialPool[itemID]);
            Instantiate(blood, transform.position, Quaternion.identity);
            //Dying stuff here
            Destroy(gameObject);
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

        if (damage > 0)
        {
            if (timeBtwAttack <= 0)
            {
                
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPlayers);
                if (enemiesToDamage.Length > 0)
                {
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        //TODO enemiesToDamage[i].GetComponent<PlayerHp>().TakeDamage(damage);
                        Debug.Log("Touche un enemie");
                    }

                    timeBtwAttack = startTimeBtwAttack;
                }

            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
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
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }

}
