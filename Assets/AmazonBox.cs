using System.Collections;
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
        
        AlchemyValues.inventory.Add(new Flower());
        AlchemyValues.inventory.Add(new Flower());
        AlchemyValues.inventory.Add(new Stone());
        AlchemyValues.inventory.Add(new Ore());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInteract(GameObject player)
    {

        GameObject UI = Instantiate(UIPrefab, new Vector3(transform.position.x +offset.x, transform.position.y + offset.y),quaternion.identity,null);
        UI.GetComponent<BoxMenu>().playerInteracted = player;

    }
    
}
