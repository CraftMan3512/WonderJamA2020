using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAfterXSecs : MonoBehaviour
{

    public float waitTime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartSecs());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSecs()
    {
        
        yield return new WaitForSeconds(waitTime);
        GetComponent<Canvas>().enabled = true;

    }
    
}
