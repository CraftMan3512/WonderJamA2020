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

    private GameObject[] allPlayers;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        allPlayers=GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(allPlayers.Length);
        rb = GetComponent<Rigidbody2D>();
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
        float angle = Mathf.Atan2(closestDirection.y, closestDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        closestDirection.Normalize();
        movement = closestDirection;
        
        if (health <= 0)
        {
            //Dying stuff here
            
            
            Destroy(this);
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
