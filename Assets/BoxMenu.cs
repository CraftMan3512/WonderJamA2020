using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMenu : MonoBehaviour
{

    private Manette manette;
    
    private List<Item> items;
    private List<Item> deduplicatedItems;

    public float xPadding,yPadding;
    public GameObject materialPrefab;
    public Vector2 offset;
        
    // Start is called before the first frame update
    void Start()
    {


        items = AlchemyValues.inventory;
        //dummy adding to inventory
        items.Add(new Flower());
        items.Add(new Flower());
        items.Add(new Stone());
        items.Add(new Ore());
        
        deduplicatedItems = GetDeduplicatedList();
        SetupDisplay(3);
        
        AlchemyValues.PopulateRecipes(3);

    }

    List<Item> GetDeduplicatedList()
    {
        
        List<Item> newList = new List<Item>();
        foreach (Item dup in items)
        {

            bool add = true;
            foreach (Item content in newList)
            {

                if (content.id == dup.id) add = false;

            }
            
            if (add) newList.Add(dup);
            
        }

        Debug.Log("DEDUPLICATED SIZE IS " + newList.Count);
        return newList;

    }

    void SetupDisplay(int nbItemsParLigne)
    {

        int x = 0, y = 0;
        foreach (Item item in deduplicatedItems)
        {

            GameObject newButton = Instantiate(materialPrefab, new Vector3(transform.position.x + offset.x + xPadding*x,transform.position.y + offset.y - y*yPadding), Quaternion.identity, transform);
            newButton.GetComponent<ItemButton>().SetItem(item,14);
            x++;
            if (x == nbItemsParLigne)
            {
                y++;
                x = 0;
            }

        }

    }

    public void OnPressItem(Item item)
    {
        
        
        
    }
    
    public void GetPlayerGamepad(int index)
    {

        manette = PlayerInputs.GetPlayerController(index);

    }
    
}
