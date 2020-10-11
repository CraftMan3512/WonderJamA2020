using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class DayTime
{
    public static float time;
    public static int day = 0;
    public static float timePerDay = 30;
    public static int maxDays = 3;


    
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
        SceneManager.LoadScene("ResultScreen");

        time = 0;
    }
}
