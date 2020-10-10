using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public GameObject cursorPrefab;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 4; i++)
        {

            if (PlayerInputs.pControllers[i] != null)
            {
                //What team is player
                Vector3 position;
                if (AlchemyValues.alchemyPlayers.Contains(i))
                {
                    float addX = AlchemyValues.alchemyPlayers.IndexOf(i)*2;
                    position=(GameObject.Find("SpawnPointAlch").transform.position+new Vector3(addX-1,0,0));
                }else if (AlchemyValues.explorationPlayers.Contains(i))
                {
                    float addX = AlchemyValues.explorationPlayers.IndexOf(i)*2;
                    position=(GameObject.Find("SpawnPointExplo").transform.position+new Vector3(addX-1,0,0));
                }
                else
                {
                    Debug.Log("What the fuck happpened here");
                    position=Vector3.zero;
                }
                //Spawns Player
                GameObject newPlayer = Instantiate(playerPrefab, position, Quaternion.identity);
                newPlayer.name = "p" + i;
                newPlayer.GetComponent<PlayerControls>().GetPlayerGamepad(i);
            }
        }
        
        GameObject.Find("CurseManager").GetComponent<Manager>().NextDay();

        // Enemy spawn Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
