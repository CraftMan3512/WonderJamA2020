using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEWait : MonoBehaviour
{
    public float timeToWait = 7;
    public float accuracyBoost = 0.1f;

    private Item contains;

    private bool start = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQTE(GameObject player)
    {
        
        if (start)
        {
            if (player.GetComponent<PlayerGrabs>().GetItemGrabbed() != null)
            {
                
                //take player's item
                contains = player.GetComponent<PlayerGrabs>().UseItem();
                player.GetComponent<PlayerGrabs>().RemoveItem();
                StartCoroutine(StartEvent());    
                
            }

        }
        else
        {

            if (player.GetComponent<PlayerGrabs>().GetItemGrabbed() == null)
            {
                
                StopCoroutine(StartEvent());
                player.GetComponent<PlayerGrabs>().GrabItem(contains);
                contains = null;
                GetComponent<SpriteRenderer>().color = Color.white;
                start = true;   
                
            }


        }


    }
    

    public IEnumerator StartEvent()
    {
        start = false;
        
        yield return new WaitForSeconds(timeToWait);
        ;
        contains.accuracy += accuracyBoost;
        //temporary test
        GetComponent<SpriteRenderer>().color = Color.red;

    }
    
}
