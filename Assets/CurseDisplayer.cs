using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurseDisplayer : MonoBehaviour
{

    public float timeToDisplay = 5;

    public GameObject name, description;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurseDesc(Effect curse)
    {

        GetComponent<Canvas>().enabled = true;
        name.GetComponent<TextMeshProUGUI>().text = curse.name;
        description.GetComponent<TextMeshProUGUI>().text = curse.description;
        StartCoroutine(DisplayTime());

    }

    IEnumerator DisplayTime()
    {
        
        yield return new WaitForSeconds(timeToDisplay);
        GetComponent<Canvas>().enabled = false;

    }
    
}
