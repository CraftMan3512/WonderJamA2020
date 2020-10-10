using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    private CircleCollider2D collider2d;

    public Item contains;
    // Start is called before the first frame update
    void Start()
    {
        collider2d=GetComponent<CircleCollider2D>();
    }

    public void setItem(Item item)
    {
        contains = item;
        Debug.Log(item.name+ " Lol");
        gameObject.GetComponent<SpriteRenderer>().sprite = item.image;
    }

    public Item getItem()
    {
        return contains;
    }

    public void AddInventory(GameObject ply)
    {
        Debug.Log("I interacted with box");
        AlchemyValues.AddItemToPlayer(int.Parse(ply.name.Substring(1)),contains);
        Destroy(gameObject);
    }

}
