using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExplorationResult : MonoBehaviour
{
    public float minX, maxX; // 130,390

    void Start()
    {

        float distanceBetweenDisplays = (maxX - minX) / AlchemyValues.explorationPlayers.Count;
        for (int i = 0; i < AlchemyValues.explorationPlayers.Count; i++)
        {
            GameObject display = Instantiate((GameObject)Resources.Load("Prefab/PlayerResult"), GameObject.Find("Canvas").transform);
            display.transform.localPosition = display.transform.localPosition = new Vector3(minX + i * distanceBetweenDisplays, display.transform.localPosition.y, display.transform.localPosition.z);
            string text = "Player " + AlchemyValues.explorationPlayers[i] + "\n\n";
            for(int j = 0; j < AlchemyValues.playerInventory[i].Count; j++)
            {
                text = text + "\n" + AlchemyValues.playerInventory[i][j].name + " X 1";
            }
            display.GetComponent<TextMeshProUGUI>().text = text;
        }
    }

    
}
