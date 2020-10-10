using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxMenu : MonoBehaviour
{

    private Manette manette;
    
    private List<Item> items;
    private List<Item> deduplicatedItems;

    public float xPadding,yPadding;
    public GameObject materialPrefab;
    public Vector2 offset;

    private int selectedMat = 0;

    public GameObject playerInteracted;
        
    // Start is called before the first frame update
    void Start()
    {

        manette = PlayerInputs.GetPlayerController(0);
        items = AlchemyValues.inventory;
        
        deduplicatedItems = GetDeduplicatedList();
        SetupDisplay(3);
        SelectMat(0);
        //AlchemyValues.PopulateRecipes(3);

    }

    private bool CanPressJoyStick = false;
    private void Update()
    {

        if (CanPressJoyStick)
        {

            //Debug.Log("JOSTICK PORESSAGE,STICK IS " + manette.leftStick.ToString());
            if (!(manette.leftStick.x <= AlchemyValues.JoystickTreshhold &&
                manette.leftStick.x >= -AlchemyValues.JoystickTreshhold))
            {

                if (manette.leftStick.x < -AlchemyValues.JoystickTreshhold) OnJoystickMove(-1,0);
                else  if (manette.leftStick.x > AlchemyValues.JoystickTreshhold) OnJoystickMove(1,0);

            } else if (!(manette.leftStick.y <= AlchemyValues.JoystickTreshhold &&
                       manette.leftStick.y >= -AlchemyValues.JoystickTreshhold))
            {
                
                if (manette.leftStick.y < -AlchemyValues.JoystickTreshhold) OnJoystickMove(0,-1);
                else if (manette.leftStick.y > AlchemyValues.JoystickTreshhold) OnJoystickMove(0,1);
                
            }

        }else
        {

            if (manette.leftStick.magnitude < 0.2f) CanPressJoyStick = true;

        }
        
        if (manette.aButton.wasPressedThisFrame) OnItemGrab();
        if (manette.bButton.wasPressedThisFrame) Cancel();

    }

    private void Cancel()
    {
        //TODO redonner movement au joueur
        Destroy(gameObject);
    }

    private void OnJoystickMove(int x, int y)
    {

        CanPressJoyStick = false;
        if (x > 0)  SelectMat(selectedMat+1);
        else if (x < 0) SelectMat(selectedMat-1);
        if (y > 0) SelectMat(selectedMat+3);
        else if (y < 0) SelectMat(selectedMat-3);

    }

    void SelectMat(int mat)
    {

        if (mat >= 0 && mat < deduplicatedItems.Count)
        {
                        
            GetSelectedMat().GetComponent<Image>().color = Color.white;
            selectedMat = mat;
            GetSelectedMat().GetComponent<Image>().color = Color.magenta;
            Debug.Log("SELECTED ITEM IS NOW " + selectedMat); ;

        }
        
    }

    void OnItemGrab()
    {
        //TODO redonner movement au joueur
        Item item = deduplicatedItems[selectedMat];
        playerInteracted.GetComponent<PlayerGrabs>().GrabItem(item);
        Debug.Log("PLAYER GRABBED " + item.name);
        AlchemyValues.RemoveItem(item);
        Cancel();
        
    }

    private GameObject GetSelectedMat()
    {
        return transform.Find(selectedMat.ToString()).gameObject;
    }

    List<Item> GetDeduplicatedList()
    {
        
        List<Item> newList = new List<Item>();
        foreach (Item dup in items)
        {

            bool add = true;
            foreach (Item content in newList)
            {

                if (content.id == dup.id) add = false;

            }
            
            if (add) newList.Add(dup);
            
        }

        //Debug.Log("DEDUPLICATED SIZE IS " + newList.Count);
        return newList;

    }

    void SetupDisplay(int nbItemsParLigne)
    {

        int x = 0, y = 0;
        foreach (Item item in deduplicatedItems)
        {
            
            GameObject newButton = Instantiate(materialPrefab, new Vector3(transform.position.x + offset.x + xPadding*x,transform.position.y + offset.y - y*yPadding), Quaternion.identity, transform);
            newButton.name = (3 * y + x).ToString();
            newButton.GetComponent<ItemButton>().SetItem(item,AlchemyValues.GetQuantity(item.id));
            x++;
            if (x == nbItemsParLigne)
            {
                y++;
                x = 0;
            }

        }

    }

    public void GetPlayerGamepad(int index)
    {

        manette = PlayerInputs.GetPlayerController(index);

    }
    
}
