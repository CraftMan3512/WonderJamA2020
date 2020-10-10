using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeMultiplier = 1;


    // Update is called once per frame
    void Update()
    {
        DayTime.AddTime(Time.deltaTime * timeMultiplier);
    }
}
