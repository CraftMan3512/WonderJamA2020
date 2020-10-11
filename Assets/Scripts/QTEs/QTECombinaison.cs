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
    private bool kb = false;

    private List<GameObject> buttonObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        display = Instantiate(Resources.Load<GameObject>("Prefabs/UI/CombinaisonUI"),new Vector3(transform.position.x+displayOffset.x,transform.position.y+displayOffset.y),Quaternion.identity,transform);
        display.GetComponent<Canvas>().sortingLayerName = "UI";

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
            
            combinaison.Clear();
            buttonObjects.Clear();
            started = true;
            playerObj = player;
            player.GetComponent<PlayerControls>().lockMovement = true;
            kb = playerObj.GetComponent<PlayerControls>().Manette.isKeyboardandMouse;
            
            //SFX
            GameObject.Find("SoundManager").GetComponent<SoundPlayer>().PlaySFX(Resources.Load<AudioClip>("SFX/SFX_PotionBrew"));
            
            GenerateCombinaison();

        }

    }

    private void GenerateCombinaison()
    {

        //Debug.Log("GENERATE");
            for (int i = 0; i < nbButtons; i++)
            {

                Buttons butt;
                int what = Random.Range(1, 7); 
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
            SetupDisplay();
    }

    void CheckButton(Buttons button)
    {

        if (combinaison.Count != 0)
        {
            
            if (button == combinaison.Peek())
            {

                combinaison.Dequeue();
                if (combinaison.Count == 0)
                {

                    //end qte
                    playerObj.GetComponent<PlayerControls>().lockMovement = false;
                    playerObj.GetComponent<PlayerGrabs>().GetItemGrabbed().accuracy += accuracyBoost;
                    kb = false;
                    StartCoroutine(DelayEnd());


                }

                UpdateDisplay();

            }
            
        }

    }

    IEnumerator DelayEnd()
    {
        
        yield return new WaitForSeconds(1);
        started = false;

    }

    void UpdateDisplay()
    {

        GameObject toDelete = buttonObjects[0];
        buttonObjects.Remove(toDelete);
        Destroy(toDelete);
        foreach (GameObject o in buttonObjects)
        {

            o.transform.localPosition -= new Vector3(padding,0);

        }
        
    }
    void SetupDisplay()
    {
        
        //Debug.Log("SETUP QTE");
        Queue<Buttons> clone = new Queue<Buttons>(combinaison);
        
        for (int i = 0; i < combinaison.Count; i++)
        {

            GameObject button = Instantiate(Resources.Load<GameObject>("Prefabs/UI/button"),display.transform.position + new Vector3(i*padding,0),Quaternion.identity,display.transform);
            
            buttonObjects.Add(button);
            
            //Debug.Log("Keyboard? : " + kb);
            
            Sprite spr;
            switch (clone.Dequeue())
            {
                
                case Buttons.a : 
                    if (kb) spr = Resources.Load<Sprite>("Sprites/xboxButtons/space");
                    else spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonA"); 
                    
                    break;
                case Buttons.b : 
                    if (kb) spr = Resources.Load<Sprite>("Sprites/xboxButtons/keyF");
                    else spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonB"); 
                    break;
                case Buttons.x : 
                    if (kb) spr = Resources.Load<Sprite>("Sprites/xboxButtons/keyX");
                    else spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonX"); 
                    break;
                case Buttons.y : 
                    if (kb) spr = Resources.Load<Sprite>("Sprites/xboxButtons/keyZ");
                        else spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonY"); 
                    break;
                case Buttons.ltrigger : 
                    if (kb) spr = Resources.Load<Sprite>("Sprites/xboxButtons/keyC");
                        else spr = Resources.Load<Sprite>("Sprites/xboxButtons/TriggerLeft"); 
                    break;
                case Buttons.rtrigger : 
                    if (kb) spr = Resources.Load<Sprite>("Sprites/xboxButtons/keyV");
                        else spr = Resources.Load<Sprite>("Sprites/xboxButtons/TriggerRight"); 
                    break;
                default :
                    if (kb) spr = Resources.Load<Sprite>("Sprites/xboxButtons/space");
                        else spr = Resources.Load<Sprite>("Sprites/xboxButtons/ButtonA"); 
                    break;
                
            }

            button.GetComponent<Image>().sprite = spr;

        }
        
    }
    
}
