﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingPot : MonoBehaviour
{
    public List<Item> ingredients = new List<Item>();
    
    

    public void AddIngredient(GameObject player)
    {
        Item item = player.GetComponent<PlayerGrabs>().GetItemGrabbed();
        player.GetComponent<PlayerGrabs>().RemoveItem();
        if (item != null)
        {
            ingredients.Add(item);
            GameObject.Find("Ingredient" + ingredients.Count).GetComponent<SpriteRenderer>().sprite = item.image;
            if (ingredients.Count == AlchemyValues.materialsPerRecipe)
            {
                for(int i = 1; i < 4; i++) {
                    GameObject.Find("Ingredient" + i).GetComponent<SpriteRenderer>().sprite = null;
                }
                
                AddPotion(player);
                TrashIngredients();
            }
        }
    }


    public void AddPotion(GameObject player)
    {
        Item[] recipe = new Item[ingredients.Count];
        for(int i = 0; i < recipe.Length; i++)
        {
            recipe[i] = ingredients[i];
        }
        Recipe potion = new Recipe(recipe);
        bool correctRecipe = false;
        foreach(Recipe r in GameObject.Find("ToDoList").GetComponent<RecipesToDo>().recipesToDo)
        {
           if(r.Compare(potion))
            {
                GameObject.Find("ToDoList").GetComponent<RecipesToDo>().RemoveRecipe(r);
                correctRecipe = true;
                break;
            }
            
        }

        if (!correctRecipe)
        {
            //quand la recette est la mauvaise
        }
        else
        {

            //quand c'est la bonne recette (pas besoin de toucher à todolist)
            float severity = 0.2f;
            foreach(Item item in ingredients)
            {
                severity += item.accuracy;                         
                
            }
            AlchemyValues.AddProgress(severity / (DayTime.maxDays));

            severity *= AlchemyValues.potionProgress / 10f;
        }
        


    }


    public void TrashIngredients()
    {
        ingredients.Clear();
    }






}
