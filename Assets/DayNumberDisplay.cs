using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayNumberDisplay : MonoBehaviour
{

    public void SetValue(Single value)
    {

        GetComponent<TextMeshProUGUI>().text = "Number of days: " + value;

    }
    
}
