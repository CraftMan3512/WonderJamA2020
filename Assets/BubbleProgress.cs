using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleProgress : MonoBehaviour
{

    public List<GameObject> bubbles = new List<GameObject>();
    float changeThreshold;
    int tresholdAt;

    private void Start()
    {
        tresholdAt = 0;
        ChangeBubbles(tresholdAt);
        changeThreshold = 100f / bubbles.Count;
    }

    // Update is called once per frame
    void Update()
    {
     if((int)(AlchemyValues.potionProgress / changeThreshold) != tresholdAt)
        {
            tresholdAt++;
            ChangeBubbles(tresholdAt);
        }   
    }



    void ChangeBubbles(int type)
    {
        for (int i = 0; i < bubbles.Count; i++)
        {
            if (i == 2 && !GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            
            if(i == tresholdAt)
            {
                bubbles[i].SetActive(true);
            }
            else
            {
                bubbles[i].SetActive(false);
            }
        }
    }
}
