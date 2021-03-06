﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AmazonBox : MonoBehaviour
{

    public GameObject UIPrefab;

    public Vector2 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
        /*AlchemyValues.inventory.Add(new Flower());
        AlchemyValues.inventory.Add(new Flower());
        AlchemyValues.inventory.Add(new Stone());
        AlchemyValues.inventory.Add(new Ore());*/
        //Debug.Log("ON A " + AlchemyValues.inventory.Count + " ITEMS DANS AMAZONBOX");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract(GameObject player)
    {
        if (AlchemyValues.inventory.Count > 0)
        {
            
            GameObject UI = Instantiate(UIPrefab, new Vector3(transform.position.x +offset.x, transform.position.y + offset.y),quaternion.identity,null);
            UI.GetComponent<BoxMenu>().playerInteracted = player;
            player.GetComponent<PlayerControls>().lockMovement = true;
            UI.GetComponent<BoxMenu>().manette = player.GetComponent<PlayerControls>().Manette;
            //play box open sfx
            GameObject.Find("SoundManager").GetComponent<SoundPlayer>().PlaySFX(Resources.Load<AudioClip>("SFX/SFX_BoxOpen"));

        }

    }
    
}
