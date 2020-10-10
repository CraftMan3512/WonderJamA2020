using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlchemyResults : MonoBehaviour
{
    public float minX, maxX; // -250,20

    void Start()
    {
        float distanceBetweenDisplays = (maxX - minX)/AlchemyValues.alchemyPlayers.Count;
        for(int i = 0; i < AlchemyValues.alchemyPlayers.Count; i++)
        {
            GameObject display = Instantiate((GameObject)Resources.Load("Prefabs/PlayerResult"), GameObject.Find("Canvas").transform);
            display.transform.localPosition = display.transform.localPosition = new Vector3(minX + i * distanceBetweenDisplays, display.transform.localPosition.y, display.transform.localPosition.z);
            string text = "Player " + AlchemyValues.alchemyPlayers[i]+"\n\n";
            foreach(Effect effect in GameObject.Find("CurseManager").GetComponent<Manager>().playerEffects[AlchemyValues.alchemyPlayers[i]])
            {
                text = text + "\n-" + effect.name;
            }
            display.GetComponent<TextMeshProUGUI>().text = text;
        }
        
        //add player inventories to amazonbox
        AlchemyValues.AddItems();

    }


}
