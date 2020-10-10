using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlchemyValues
{

    public static List<Item> inventory = new List<Item>();
    public static List<Recipe> remainingRecipes = new List<Recipe>();
    public static List<Recipe> finishedRecipes = new List<Recipe>();
    private static int[] itemsAt;
    public static Item[] materialPool = {new Flower(), new Stone(), new Ore()};

    public static float JoystickTreshhold = 0.5f;

    public static void PopulateRecipes(int materialPerRecipe)
    {

        itemsAt = new int[materialPerRecipe]; 
        for(int i = 0; i < itemsAt.Length; i++)
        {
            itemsAt[i] = 0;
        }


          while (itemsAt[0] < materialPool.Length )        
          {
            for(int i = itemsAt[materialPerRecipe-1]; i < materialPool.Length; i++)
            {
                Item[] newRecipe = new Item[materialPerRecipe];
              
                for(int j = 0; j < materialPerRecipe; j++)
                {
                    newRecipe[j] = materialPool[itemsAt[j]];
                    
                }
                remainingRecipes.Add(new Recipe(newRecipe));
                itemsAt[materialPerRecipe - 1]++;
            }
            NextDigit(materialPerRecipe - 1);
            
        
          }


        foreach(Recipe recipe in remainingRecipes)
        {
            string values = "";
            for (int i = 0; i < recipe.items.Length; i++)
            {
                values = "" + values + " " + recipe.items[i].id;
            }
            Debug.Log(values);
        }


        
        
    }


    private static void NextDigit(int pos)
    {
        if(pos > 0)
        {
            if(itemsAt[pos-1] < materialPool.Length - 1)
            {
                itemsAt[pos - 1]++;
                for(int i = pos; i < itemsAt.Length; i++)
                {
                    itemsAt[i] = itemsAt[pos - 1];
                }
            }
            else
            {
                NextDigit(pos - 1);
            }
        }
        else
        {
            itemsAt[0]++;
        }

    }



    public static int GetQuantity(int id)
    {
        int amount = 0;
        foreach (Item item in inventory)
        {
            if (item.id == id)
            {
                amount++;
            }
        }
        return amount;
    }

    public static void RemoveItem(Item it)
    {

        
        foreach (var i in inventory)
        {

            if (i.id == it.id)
            {
                inventory.Remove(i);
                break;
            }

        }
        
    }

    public static void FinishRecipe(Recipe r)
    {

        if (remainingRecipes.Contains(r))
        {
            finishedRecipes.Add(r);
            remainingRecipes.Remove(r);
        }
        
    }



}
