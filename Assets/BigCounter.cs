using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BigCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool started = false;
    // Update is called once per frame
    void Update()
    {

        if (DayTime.timePerDay - DayTime.time < 4)
        {

            if (!started)
            {

                started = true;
                StartCoroutine(StartCDown());   
                
            }

        } 
        
    }

    public IEnumerator StartCDown()
    {


        GetComponent<TextMeshProUGUI>().enabled = true;
        while (true)
        {
         
            
            GetComponent<TextMeshProUGUI>().text = ((int)(DayTime.timePerDay - DayTime.time)).ToString();
            if (((int) (DayTime.timePerDay - DayTime.time)) > 3) GetComponent<TextMeshProUGUI>().text = "0";
            yield return new WaitForSeconds(1f);
            
        }

    }
    
}
