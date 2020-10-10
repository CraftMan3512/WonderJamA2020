using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMovement : MonoBehaviour
{
    private Manette manette;
    public float moveSpeed;

    public Manette Manette { get => manette; set => manette = value; }

    private void FixedUpdate()
    {
        MovePlayer();
       

    }

    void MovePlayer()
    {
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y) + (Manette.leftStick * Time.deltaTime * moveSpeed));
    }
}
