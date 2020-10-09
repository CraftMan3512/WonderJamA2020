using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlchemyValues
{

    public static List<Item> inventory = new List<Item>();
    public static List<Recipe> remainingRecipes = new List<Recipe>();
    public static List<Recipe> finishedRecipes = new List<Recipe>();
    public static Item[] materialPool = {};
    private static int[] itemsAt;


    public static void PopulateRecipes(int materialPerRecipe)
    {
        itemsAt = new int[materialPerRecipe]; 


        while (itemsAt[0] < materialPool.Length)
        {
            for(int i = itemsAt[materialPerRecipe-1]; i < materialPool.Length; i++)
            {
                Item[] newRecipe = new Item[materialPerRecipe];
                for(int j = 0; j < materialPerRecipe; j++)
                {
                    newRecipe[j] = materialPool[itemsAt[j]];
                }
                nextDigit(materialPerRecipe - 1);
            }
            
        
        }

        Debug.Log(remainingRecipes.Count);
        
    }

    private static void nextDigit(int pos)
    {
        if(pos > 0)
        {
            if(pos-1 < materialPool.Length - 1)
            {
                itemsAt[pos - 1]++;
                for(int i = pos; i < itemsAt.Length; i++)
                {
                    itemsAt[i] = itemsAt[pos - 1];
                }
            }
            else
            {
                nextDigit(pos - 1);
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
