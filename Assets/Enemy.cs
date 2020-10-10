using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float startScale;

    private GameObject[] allPlayers;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        allPlayers=GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        Vector3 closestDirection = Vector3.zero;
        
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
            Debug.Log("Died");
            //Dying stuff here
            Destroy(gameObject);
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

}
