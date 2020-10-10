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
        changeThreshold = 100f / bubbles.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
