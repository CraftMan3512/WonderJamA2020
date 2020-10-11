using System.Collections;
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
                GameObject.Find("ToDoList").GetComponent<RecipesToDo>().RemoveRecipe(potion);
                correctRecipe = true;
                break;
            }
            
        }
        float severity = 1f;
        foreach (Item item in ingredients)
        {
            severity += item.accuracy;
            if(item.id == 0 || item.id == 15)
            {
                severity += 0.2f;
            }
            else
            {
                severity += (float)(item.zone) / 10f;
            }
          

        }
        if (!correctRecipe)
        {
            GameObject.Find("ToDoList").GetComponent<RecipesToDo>().RefreshTodo();

        }
        else
        {
           

            //quand c'est la bonne recette (pas besoin de toucher à todolist)
           
            AlchemyValues.AddProgress(severity*15 / (DayTime.maxDays));           
          
        }
        severity *= AlchemyValues.potionProgress / 20f;
        GameObject.Find("CurseManager").GetComponent<Manager>().AddCurse(severity, player);


    }


    public void TrashIngredients()
    {
        ingredients.Clear();
    }






}
