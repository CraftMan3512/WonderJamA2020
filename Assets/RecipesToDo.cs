using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesToDo : MonoBehaviour
{
    public List<Recipe> recipesToDo = new List<Recipe>();
    public float yOffSet;
    public float xOffSet;
    List<Item> itemsAvaible = AlchemyValues.inventory;
    List<List<GameObject>> recipesObjects = new List<List<GameObject>>();
    int totalAmountOfItems;
    // Start is called before the first frame update
    void Start()
    {
        totalAmountOfItems = 0;
        foreach(Item item in itemsAvaible)
        {
            totalAmountOfItems += item.qty;
        }

        int recipesShown = 3;
        if(totalAmountOfItems / AlchemyValues.materialsPerRecipe < recipesShown)
        {
            recipesShown = (int)(totalAmountOfItems / AlchemyValues.materialsPerRecipe);
        }

        for(int i = 0; i < recipesShown; i++)
        {
            AddRecipeToDo();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplay()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        recipesObjects.Clear();
        
        foreach(Recipe recipe in recipesToDo)
        {
            List<GameObject> recipeObjects = new List<GameObject>();
            for(int i = 0; i < recipe.items.Length; i++)
            {
                GameObject item = Instantiate((GameObject)Resources.Load("Item"), null);
                item.GetComponent<SpriteRenderer>().sprite = recipe.items[i].image;
                item.transform.position = new Vector2(x + xOffSet * i, y);
                item.name = recipe.items[i].name;
                recipeObjects.Add(item);

                
            }
            recipesObjects.Add(recipeObjects);
            y += yOffSet;
        }
    }


    public bool RemoveRecipe(Recipe recipe)
    {
        string[] recipeNames = new string[recipe.items.Length];
        List<GameObject> objectsToRemove = null;
        foreach(List<GameObject> recipesShown in recipesObjects)
        {
           
            List<GameObject> recipePlaceHolder = new List<GameObject>(recipesShown);
            GameObject recipeToRemove = null;
            for(int i = 0; i < recipeNames.Length; i++)
            {
             foreach(GameObject placeHolder in recipePlaceHolder)
                {
                    if (recipeNames[i].Equals(placeHolder.name))
                    {
                        recipeToRemove = placeHolder;
                    }
                }
                if (recipeToRemove != null)
                {
                    recipePlaceHolder.Remove(recipeToRemove);
                }
            }
            if(recipePlaceHolder.Count == 0)
            {
                objectsToRemove = recipesShown;
            }
        }

        if(objectsToRemove != null)
        {
            recipesObjects.Remove(objectsToRemove);
            foreach(Recipe r in recipesToDo)
            {
                if (r.Compare(recipe))
                {
                    recipesToDo.Remove(r);
                    break;
                }
            }
            
            foreach(GameObject item in objectsToRemove)
            {
                Destroy(item);
            }
            UpdateDisplay();
            return true;
        }
        else
        {
            return false;
        }
    }

    
    
    public void AddRecipeToDo()
    {
        Item[] recipe = new Item[AlchemyValues.materialsPerRecipe];
        if(AlchemyValues.materialsPerRecipe <= totalAmountOfItems)
        {
            for(int i = 0; i < recipe.Length; i++)
            {
                int randomItem = Random.Range(0, itemsAvaible.Count);
                recipe[i] = itemsAvaible[i];
                itemsAvaible[i].qty--;
                totalAmountOfItems--;
                if (itemsAvaible[i].qty < 1)
                {
                    itemsAvaible.Remove(itemsAvaible[i]);                  
                }
                   

            }
            Recipe recipeMade = new Recipe(recipe);
            recipesToDo.Add(recipeMade);
        }
        UpdateDisplay();
    }
}
