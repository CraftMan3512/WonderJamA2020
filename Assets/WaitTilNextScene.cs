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

        if(PlayerInputs.pControllers[0].aButton.wasPressedThisFrame && PlayerInputs.pControllers[0].startButton.wasPressedThisFrame)
        {

            NextScene();

        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene("DayTransition");
    }
}
