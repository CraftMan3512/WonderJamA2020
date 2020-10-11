using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamChooseController : MonoBehaviour
{

    private Manette manette;
    public int playerNb = 0;
    public float leftPos, rightPos;
    [HideInInspector]
    public bool ready;

    public enum Teams
    {
        
        Exploration,Alchemy
        
    }

    public Teams team;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerInputs.GetPlayerController(playerNb) == null) Destroy(gameObject);
        else
        {

            manette = PlayerInputs.GetPlayerController(playerNb);

        }
        
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (DayTime.day != 1)
        {
            if (!(manette.leftStick.x < 0.5 && manette.leftStick.x > -0.5)) MoveToTeam();
            if (manette.aButton.wasPressedThisFrame) Ready();
            if (manette.bButton.wasPressedThisFrame) UnReady();
        }else if (GameObject.Find("Transition").GetComponent<Transition>().endPauseTime <= 0.2f && DayTime.day == 1)
        {
            team = Teams.Exploration;
            Ready();
        }/*else if (GameObject.Find("Transition").GetComponent<Transition>().endPauseTime <= 0.2f)
        {
            Debug.Log(" 3rd day and on");
            Ready();
        }*/

    }

    private void UnReady()
    {
        ready = false;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
    }

    void Ready()
    {

        ready = true;
        GameObject.Find("Controller").GetComponent<TeamChooser>().OnPlayerReady();
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;

    }

    void MoveToTeam()
    {
        
        if (ready) return;
        
        if (manette.leftStick.x < 0.5)
        {

            transform.localPosition = new Vector3(leftPos,transform.localPosition.y);
            team = Teams.Alchemy;

        }
        else  if (manette.leftStick.x > 0.5)
        {
            
            transform.localPosition = new Vector3(rightPos,transform.localPosition.y);
            team = Teams.Exploration;

        }
        
        
    }
    
}
