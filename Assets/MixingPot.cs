using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingPot : MonoBehaviour
{
    public List<Item> ingredients = new List<Item>();
    
    

    public void AddIngredient(GameObject player)
    {
        Item item = player.GetComponent<PlayerGrabs>().GetItemGrabbed();
        if (item != null)
        {
            ingredients.Add(item);
            if (ingredients.Count == AlchemyValues.materialsPerRecipe)
            {
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
        }
        


    }


    public void TrashIngredients()
    {
        ingredients.Clear();
    }






}
