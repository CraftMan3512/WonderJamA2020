using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlchemyValues
{

    public static List<Item> inventory = new List<Item>();
    public static List<Recipe> remainingRecipes = new List<Recipe>();
    public static List<Recipe> finishedRecipes = new List<Recipe>();

    private static int[] itemsAt;

    //All materials
    public static Item[] materialPool =
    {
        new Item("Diamant", Resources.Load<Sprite>("Sprites/Materials/diamant"), 0,1),
        new Item("Fleur", Resources.Load<Sprite>("Sprites/Materials/fleur"), 1,1),
        new Item("Roche", Resources.Load<Sprite>("Sprites/Materials/roche"), 2,1),
    };

    public static List<int> alchemyPlayers = new List<int>();
    public static List<int> explorationPlayers = new List<int>();
    public static List<Item>[] playerInventory;

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

    public static void AddItems()
    {

        foreach (List<Item> pInv in playerInventory)
        {

            foreach (var newItem in pInv)
            {

                bool found = false;
                for (int i = 0; i < inventory.Count; i++)
                {

                    //si item existe on ajoute 1 à la quantité
                    if (inventory[i].id == newItem.id)
                    {

                        inventory[i].qty++;
                        found = true;
                        break;

                    }
                
                }
                
                if (!found) inventory.Add(newItem);
                
                
            }
            
            pInv.Clear();
            
        }
        
    }

    public static void AddItemToPlayer(int p, Item item)
    {

        if (playerInventory[p] != null)
        {

            bool found = false;
            foreach (Item current in playerInventory[p])
            {

                if (current.id == item.id)
                {

                    found = true;
                    current.qty++;
                    break;

                }
                
            }
            
            if (!found) playerInventory[p].Add(item);
            
        }
        
    }
    public static void RemoveItem(Item it)
    {

        
        foreach (var i in inventory)
        {

            if (i.id == it.id)
            {
                if (i.qty > 1) i.qty--;
                else inventory.Remove(i);
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
