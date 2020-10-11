using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public float startPauseTime;
    public float endPauseTime;
    public float transitionSpeed;
    public GameObject dayAt;
    public GameObject nextDay;
    float dayAtStartPos;


    private void Start()
    {
        dayAt.GetComponent<TextMeshProUGUI>().text = "" + DayTime.day;
        nextDay.GetComponent<TextMeshProUGUI>().text = "" + (DayTime.day+1);
        DayTime.day++;
        dayAtStartPos = dayAt.transform.localPosition.y;
        
        //SFX
        GameObject.Find("SoundManager").GetComponent<SoundPlayer>().PlaySFX(Resources.Load<AudioClip>("SFX/SFX_DayChange"));
       
    }


    private void Update()
    {
        if(startPauseTime > 0)
        {
            startPauseTime-= Time.deltaTime;
        }
        else
        {
            if(nextDay.transform.localPosition.y > dayAtStartPos)
            {
                nextDay.transform.position += transitionSpeed * Vector3.down*Time.deltaTime;
                dayAt.transform.position += transitionSpeed * Vector3.down*Time.deltaTime;
            }
            else if(endPauseTime > 0)
            {
                endPauseTime -= Time.deltaTime;
            }
            else
            {
                if (DayTime.day != 1)
                {
                    Destroy(gameObject);
                }
            }
            
            
        }
    }
}
