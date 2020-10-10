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
                GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
                newPlayer.name = "p" + i;
                newPlayer.GetComponent<PlayerControls>().GetPlayerGamepad(i);
            }

        }

        Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
