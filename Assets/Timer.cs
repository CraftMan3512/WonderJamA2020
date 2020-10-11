using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeMultiplier = 1;
    public int segments;
    public float xradius;
    public float yradius;
    LineRenderer line;


    private void Start()
    {

        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
    }
    // Update is called once per frame
    void Update()
    {
        DayTime.AddTime(Time.deltaTime * timeMultiplier);
        UpdateTimer();

    }


    void UpdateTimer()
    {
        float x = 0f;
        float y = 0f;
        float z = 0f;
        float angle = 0f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));
            if(DayTime.time > DayTime.timePerDay)
            {
                DayTime.time = DayTime.timePerDay;
            }
            angle += (((360f)-(360f*(DayTime.time/DayTime.timePerDay))) / segments);
        }
    }
}
