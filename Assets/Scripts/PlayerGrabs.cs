using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabs : MonoBehaviour
{

    private Item grabbedItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabItem(Item item)
    {

        grabbedItem = item;

    }

    public void UseItem()
    {

        grabbedItem = null;

    }
    
}
