using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DayTime
{
    public static float time;
    public static int day = 1;
    public static float timePerDay;

    
    public static void AddTime(float addedTime)
    {
        time += addedTime;
        if (time  > timePerDay)
        {
            NextDay();
        }
    }


    public static void NextDay()
    {


        time = 0;
    }
}
