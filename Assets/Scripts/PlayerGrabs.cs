using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabs : MonoBehaviour
{

    private Item grabbedItem;
    public GameObject HeldItem;
    // Start is called before the first frame update
    void Start()
    {
        HeldItem.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item GetItemGrabbed()
    {

        return grabbedItem;

    }
    
    public void GrabItem(Item item)
    {

        grabbedItem = item;
        HeldItem.GetComponent<SpriteRenderer>().sprite = item.image;

    }

    public Item UseItem()
    {

        return grabbedItem;

    }

    public void RemoveItem()
    {

        grabbedItem = null;
        HeldItem.GetComponent<SpriteRenderer>().sprite = null;

    }
    
}
