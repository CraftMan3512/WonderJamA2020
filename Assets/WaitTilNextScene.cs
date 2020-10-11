using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitTilNextScene : MonoBehaviour
{
    public float timeTilNextScene;

    // Update is called once per frame
    void Update()
    {
        if(timeTilNextScene < 0)
        {
            NextScene();
        }
        else
        {
            timeTilNextScene -= Time.deltaTime;
        }
        if (PlayerInputs.pControllers[0] != null)
        {
            if (PlayerInputs.pControllers[0].aButton.wasPressedThisFrame || PlayerInputs.pControllers[0].startButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene("DayTransition");

            }
        }else if (PlayerInputs.pControllers[1] != null)
        {
            if (PlayerInputs.pControllers[1].aButton.wasPressedThisFrame || PlayerInputs.pControllers[1].startButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene("DayTransition");

            }
        }
        else if (PlayerInputs.pControllers[2] != null)
        {
            if (PlayerInputs.pControllers[2].aButton.wasPressedThisFrame || PlayerInputs.pControllers[2].startButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene("DayTransition");

            }
        }
        else if (PlayerInputs.pControllers[3] != null)
        {
            if (PlayerInputs.pControllers[3].aButton.wasPressedThisFrame || PlayerInputs.pControllers[3].startButton.wasPressedThisFrame)
            {
                SceneManager.LoadScene("DayTransition");

            }
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene("DayTransition");
    }
}
