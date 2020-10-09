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

        if (allready) GoToGame();

    }

    void UpdateList()
    {

        players.Clear();
        foreach (TeamChooseController obj in GameObject.Find("Canvas").transform.GetComponentsInChildren<TeamChooseController>())
        {
            
            players.Add(obj);
            
        }
        
        Debug.Log("PLAYER SIZE IS " + players.Count);
    }

    void GoToGame()
    {

        SceneManager.LoadScene("GameplayScene");

    }
    

}
