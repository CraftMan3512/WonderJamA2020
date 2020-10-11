using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressStartBlinker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Blink());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blink()
    {

        while (true)
        {

            GetComponent<TextMeshProUGUI>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            GetComponent<TextMeshProUGUI>().enabled = true;
            yield return new WaitForSeconds(0.5f);
            
        }

    }
    
}
