using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToGame : MonoBehaviour
{

    public void GoToJoin()
    {

        //set nbDays to play
        DayTime.maxDays = (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        SceneManager.LoadScene("PlayerJoinScreen");

    }
    
}
