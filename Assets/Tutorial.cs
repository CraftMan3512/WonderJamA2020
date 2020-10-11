using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> slides;
    public int slideNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NextSlide()
    {
        if(slideNumber == slides.Count - 1)
        {
            // SceneManager.load("")
        }
        else
        {
            slideNumber++;

            slides[slideNumber].SetActive(true);
            slides[slideNumber - 1].SetActive(false);
        }
        
         
    }
}
