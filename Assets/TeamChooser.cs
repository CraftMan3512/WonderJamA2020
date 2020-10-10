using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamChooser : MonoBehaviour
{

    public List<TeamChooseController> players = new List<TeamChooseController>();
    // Start is called before the first frame update
    void Start()
    {
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerReady()
    {
        
        CheckReady();

    }

    void CheckReady()
    {

        UpdateList();
        
        bool allready = true;
        foreach (var p in players)
        {

            if (p != null)
            {
                
                if (!p.ready)
                {
                    allready = false;
                    break;
                }   
                
            }

        }
        if (DayTime.day > 1 && players.Count > 1)
        {
            int onePerTeamConfirm = 0;
            foreach (TeamChooseController p in players)
            {
                if (p.team == TeamChooseController.Teams.Alchemy)
                {
                    onePerTeamConfirm++;
                    break;
                }
            }

            foreach (TeamChooseController p in players)
            {
                if (p.team == TeamChooseController.Teams.Exploration)
                {
                    onePerTeamConfirm++;
                    break;
                }
            }

            if (allready && onePerTeamConfirm == 2) GoToGame();
        }
        else
        {
            if (allready) GoToGame();
        }

    }

    void UpdateList()
    {

        players.Clear();
        foreach (TeamChooseController obj in GameObject.Find("Canvas").transform.GetComponentsInChildren<TeamChooseController>())
        {
            
            players.Add(obj);
            
        }
        
        //Debug.Log("PLAYER SIZE IS " + players.Count);
    }

    void GoToGame()
    {
        AlchemyValues.alchemyPlayers.Clear();
        AlchemyValues.explorationPlayers.Clear();
       
        foreach (TeamChooseController obj in GameObject.Find("Canvas").transform.GetComponentsInChildren<TeamChooseController>())
        {
            if (DayTime.day > 1)
            {
                if(obj.team == TeamChooseController.Teams.Alchemy)
                {
                    obj.team = TeamChooseController.Teams.Exploration;
                }
                else
                {
                    obj.team = TeamChooseController.Teams.Alchemy;
                }

            }

            if (obj.team == TeamChooseController.Teams.Alchemy)
            {
                AlchemyValues.alchemyPlayers.Add(int.Parse(obj.gameObject.name.Substring(1))-1);
            }
            else
            {
                AlchemyValues.explorationPlayers.Add(int.Parse(obj.gameObject.name.Substring(1))-1);
            }

        }
        SceneManager.LoadScene("GameplayScene");

    }
    

}
