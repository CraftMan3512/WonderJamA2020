using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlchemyValues
{

    public static List<Item> inventory = new List<Item>();
    public static List<Recipe> remainingRecipes = new List<Recipe>();
    public static List<Recipe> finishedRecipes = new List<Recipe>();
    public static int materialsPerRecipe = 3;
    public static float potionProgress = 0;
    public static int posX=0;//TODO Reset ca quand la game restart
    
    public

    static int[] itemsAt;

    //All materials
    public static Item[] materialPool =
    {
        new Item("Wood", Resources.Load<Sprite>("Sprites/Materials/buche"), 0,6),
        new Item("Mushroom", Resources.Load<Sprite>("Sprites/Materials/mushroom"), 1, 1),
        new Item("Rose", Resources.Load<Sprite>("Sprites/Materials/tulip"), 2,2),
        new Item("Cactus", Resources.Load<Sprite>("Sprites/Materials/cactus"), 3,3),
        new Item("Brain", Resources.Load<Sprite>("Sprites/Materials/cerveau"), 4,6),
        new Item("Tulipe", Resources.Load<Sprite>("Sprites/Materials/fleur"), 5,2),
        new Item("Herb", Resources.Load<Sprite>("Sprites/Materials/fern"), 6,1),
        new Item("Branch", Resources.Load<Sprite>("Sprites/Materials/branche"), 7,1),
        new Item("Iron", Resources.Load<Sprite>("Sprites/Materials/iron"), 8,5),
        new Item("Vines", Resources.Load<Sprite>("Sprites/Materials/junglebranche"), 9,6),
        new Item("Rock", Resources.Load<Sprite>("Sprites/Materials/rochette"), 10,6),
        new Item("Ladybug", Resources.Load<Sprite>("Sprites/Materials/rumba"), 11,4),
        new Item("Uranium", Resources.Load<Sprite>("Sprites/Materials/uranium"), 12,5),
        new Item("Spider Leg", Resources.Load<Sprite>("Sprites/Materials/patte"), 13,6),
        new Item("Wool", Resources.Load<Sprite>("Sprites/Materials/laine"), 14,6),
        new Item("Venom", Resources.Load<Sprite>("Sprites/Materials/venom"), 15,6),
    };

    public static List<int> alchemyPlayers = new List<int>();
    public static List<int> explorationPlayers = new List<int>();
    public static List<Item>[] playerInventory;

    public static float JoystickTreshhold = 0.5f;

    public static void PopulateRecipes(int materialPerRecipe)
    {
       // materialsPerRecipe = materialPerRecipe;

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

                        inventory[i].qty+= newItem.qty;
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


    public static void AddProgress(float amount)
    {
        potionProgress += amount;
        if(potionProgress >= 100 && posX >= TileGenerator.endLength)
        {
            DayTime.Win();
        }
    }



}
