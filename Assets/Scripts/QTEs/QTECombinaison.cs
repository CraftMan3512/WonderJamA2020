using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QTECombinaison : MonoBehaviour
{
    public enum Buttons
    {
        
        a,b,x,y,ltrigger,rtrigger
        
    }

    public float accuracyBoost = 0.1f;

    private GameObject display;
    public Vector2 displayOffset;
    public float padding;
        
    private Queue<Buttons> combinaison = new Queue<Buttons>();

    public int nbButtons = 6;
    private bool started = false;
    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {

        display = Instantiate(Resources.Load<GameObject>("Prefabs/UI/CombinaisonUI"),new Vector3(transform.position.x+displayOffset.x,transform.position.y+displayOffset.y),Quaternion.identity,transform);

    }

    // Update is called once per frame
    void Update()
    {

        if (started) {CheckInputs(playerObj.GetComponent<PlayerControls>().Manette);}

    }

    private void CheckInputs(Manette manette)
    {

        if (manette.aButton.wasPressedThisFrame) { CheckButton(Buttons.a); }
        if (manette.bButton.wasPressedThisFrame) { CheckButton(Buttons.b); }
        if (manette.xButton.wasPressedThisFrame) { CheckButton(Buttons.x); }
        if (manette.yButton.wasPressedThisFrame) { CheckButton(Buttons.y); }
        if (manette.leftTrigger.wasPressedThisFrame) { CheckButton(Buttons.ltrigger); }
        if (manette.rightTrigger.wasPressedThisFrame) { CheckButton(Buttons.rtrigger); }
        
    }

    public void StartQTE(GameObject player)
    {

        if (!started && player.GetComponent<PlayerGrabs>().GetItemGrabbed() != null)
        {
            
            GenerateCombinaison();
            started = true;
            playerObj = player;
            player.GetComponent<PlayerControls>().lockMovement = true;

        }

    }

    private void GenerateCombinaison()
    {
        
            for (int i = 0; i < nbButtons; i++)
            {

                Buttons butt;
                int what = Random.Range(1, 6); 
                switch (what)
                {
                
                    case 1: butt = Buttons.a; break;
                    case 2: butt = Buttons.b; break;
                    case 3: butt = Buttons.x; break;
                    case 4: butt = Buttons.y; break;
                    case 5: butt = Buttons.ltrigger; break;
                    case 6: butt = Buttons.rtrigger; break;
                    default: butt = Buttons.a; break;
                    
                }
                combinaison.Enqueue(butt);
            
            }
            UpdateDisplay();
    }

    void CheckButton(Buttons button)
    {
        
        if (button == combinaison.Peek())
        {

            combinaison.Dequeue();
            if (combinaison.Count == 0)
            {

                //end qte
                playerObj.GetComponent<PlayerControls>().lockMovement = false;
                playerObj.GetComponent<PlayerGrabs>().GetItemGrabbed().accuracy += accuracyBoost;
                started = false;


            }
            UpdateDisplay();

        }
        
    }

    void UpdateDisplay()
    {
        
        if (display.transform.childCount > 0)
        {
            
            foreach (var tf in display.transform.GetComponentsInChildren<Transform>())
            {
            
                Destroy(tf.gameObject);
                
            }
            
        }
        
        Queue<Buttons> clone = new Queue<Buttons>(combinaison);
        
        for (int i = 0; i < combinaison.Count; i++)
        {

            GameObject button = Instantiate(Resources.Load<GameObject>("Prefabs/UI/button"),display.transform.position + new Vector3(i*padding,0),Quaternion.identity,display.transform);

            Sprite spr;
            switch (clone.Dequeue())
            {
                
                case Buttons.a : spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonA"); break;
                case Buttons.b : spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonB"); break;
                case Buttons.x : spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonX"); break;
                case Buttons.y : spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonY"); break;
                case Buttons.ltrigger : spr = Resources.Load<Sprite>("Sprites/xboxButtons/TriggerLeft"); break;
                case Buttons.rtrigger : spr = Resources.Load<Sprite>("Sprites/xboxButtons/TriggerRight"); break;
                default :spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonA"); break;
                
            }

            button.GetComponent<Image>().sprite = spr;

        }
        
    }
    
}
