using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesToDo : MonoBehaviour
{
    public List<Recipe> recipesToDo = new List<Recipe>();
    public float yOffSet;
    public float xOffSet;
    public float scale;
    public List<Item> itemsAvaible = new List<Item>();
    public List<List<GameObject>> recipesObjects = new List<List<GameObject>>();
    int totalAmountOfItems;
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    void Init()
    {
        foreach (Item item in AlchemyValues.inventory)
        {
            itemsAvaible.Add(item.Copy());
        }
        totalAmountOfItems = 0;
        foreach (Item item in itemsAvaible)
        {
            totalAmountOfItems += item.qty;
        }

        int recipesShown = 3;
        if (totalAmountOfItems / AlchemyValues.materialsPerRecipe < recipesShown)
        {
            recipesShown = (int)(totalAmountOfItems / AlchemyValues.materialsPerRecipe);
        }


        for (int i = 0; i < recipesShown; i++)
        {
            AddRecipeToDo();
        }
    }

    public void UpdateDisplay()
    {
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;
        foreach(List<GameObject> l in recipesObjects)
        {
            foreach(GameObject o in l)
            {
                Destroy(o);
            }
        }
        recipesObjects.Clear();
        
        foreach(Recipe recipe in recipesToDo)
        {
            y += yOffSet;
            List<GameObject> recipeObjects = new List<GameObject>();
            for(int i = 0; i < recipe.items.Length; i++)
            {
                GameObject item = Instantiate((GameObject)Resources.Load("Item"), gameObject.transform);
                item.GetComponent<SpriteRenderer>().sprite = recipe.items[i].image;
                item.transform.position = new Vector3(x + xOffSet * i, y,-0.02f);
                item.transform.localScale = new Vector3(scale, scale, 1);
                item.name = recipe.items[i].name;
                recipeObjects.Add(item);               
            }
            recipesObjects.Add(recipeObjects);
           
        }
    }


    public bool RemoveRecipe(Recipe recipe)
    {
        string[] recipeNames = new string[recipe.items.Length];
        for(int i = 0; i < recipeNames.Length; i++)
        {
            recipeNames[i] = recipe.items[i].name;
            Debug.Log(recipeNames[i] + "            " + i);
        }
     
        List<GameObject> objectsToRemove = null;     
        foreach(List<GameObject> recipesShown in recipesObjects)
        {
           
            List<GameObject> recipePlaceHolder = new List<GameObject>(recipesShown);
           
            for(int i = 0; i < recipeNames.Length; i++)
            {
                GameObject recipeToRemove = null;              
                foreach (GameObject placeHolder in recipePlaceHolder)
                {
                    if (recipeNames[i].Equals(placeHolder.name))
                    {                                            
                        recipeToRemove = placeHolder;
                        break;
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

                break;
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
            AddRecipeToDo();
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
                recipe[i] = itemsAvaible[randomItem];
                itemsAvaible[randomItem].qty--;
                totalAmountOfItems--;
                if (itemsAvaible[randomItem].qty < 1)
                {
                    itemsAvaible.Remove(itemsAvaible[randomItem]);                  
                }
                   

            }
            Recipe recipeMade = new Recipe(recipe);
            recipesToDo.Add(recipeMade);
        }
        UpdateDisplay();
    }


    public void RefreshTodo()
    {
        recipesToDo.Clear();
        Init();
    }
}
