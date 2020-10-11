using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>() != null) 
            GetComponent<SpriteRenderer>().sortingOrder = -(int)Math.Round(transform.position.y*100);

    }
}
