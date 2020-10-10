using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    private CircleCollider2D collider2d;

    [SerializeField] Item contains;
    // Start is called before the first frame update
    void Start()
    {
        collider2d=GetComponent<CircleCollider2D>();
    }

    public void setItem(Item item)
    {
        contains = item;
        GetComponent<SpriteRenderer>().sprite = item.image;
    }

    public Item getItem()
    {
        return contains;
    }

    public void AddInventory(GameObject ply)
    {
        Debug.Log("I interacted with box");
        AlchemyValues.playerInventory[int.Parse(ply.name.Substring(1))].Add(contains);
        Destroy(gameObject);
    }

}
