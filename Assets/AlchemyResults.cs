using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyResults : MonoBehaviour
{
    public float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        float distanceBetweenDisplays = (maxX - minX)/AlchemyValues.alchemyPlayers.Count;
        for(int i = 0; i < AlchemyValues.alchemyPlayers.Count; i++)
        {
            GameObject display = Instantiate((GameObject)Resources.Load("PlayerResult"), null);
            display.transform.localPosition = display.transform.position = new Vector3(minX + i * distanceBetweenDisplays, display.transform.position.y, display.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
