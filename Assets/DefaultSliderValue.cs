using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultSliderValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Slider>().value = 7;
        GetComponent<Slider>().onValueChanged.Invoke(GetComponent<Slider>().value);

    }
}
