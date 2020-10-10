using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayOneExploration : MonoBehaviour
{
  
    void Start()
    {
        if(DayTime.day == 1)
        {
            GetComponent<Camera>().rect = new Rect(new Vector2(0, 0), new Vector2(1, 1));
        }
    }

  
}
