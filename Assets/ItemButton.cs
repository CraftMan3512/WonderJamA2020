using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    private Item item;

    public void SetItem(Item it, int quantity)
    {

        item = it;
        GetComponent<Image>().sprite = item.image;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "x" + quantity;

    }
    
}
