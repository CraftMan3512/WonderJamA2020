using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public Recipe(Item[] items)
    {
        this.items = items;
    }
    public Item[] items;
    public Effect effect;


    public bool Compare(Recipe recipe)
    {
        int[] idHolder1 = new int[recipe.items.Length];
        List<int> idHolder2 = new List<int>();


        for(int i = 0; i < recipe.items.Length; i++) {
            idHolder1[i] = recipe.items[i].id;
        }

        for (int i = 0; i < items.Length; i++)
        {
            idHolder2.Add(items[i].id);
        }

        for(int i = 0; i < recipe.items.Length; i++)
        {
            int remove = -1;
            for(int j = 0; j < idHolder2.Count; j++)
            {
                if(idHolder1[i] == idHolder2[j])
                {
                    remove = j;
                }
            }
            if(remove >= 0)
            {
                idHolder2.RemoveAt(remove);
            }
        }

        if(idHolder2.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }




    }

}
