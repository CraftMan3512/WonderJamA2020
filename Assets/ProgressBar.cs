using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Slider slider;
    public float diff;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = AlchemyValues.potionProgress;
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value != AlchemyValues.potionProgress)
        {
            diff = AlchemyValues.potionProgress - slider.value;
            for(float i = 0.1f; i < diff;)
            {
                slider.value += i;
            }
        }
    }
}
