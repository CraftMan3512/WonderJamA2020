using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class QTESpam : MonoBehaviour
{

    public float timeToSpam = 3;
    private bool started = false;
    private int spamNb = 0;
    private PlayerControls pControls;


    public void StartQTE(GameObject player)
    {

        if (!started && player.GetComponent<PlayerGrabs>().GetItemGrabbed() != null)
        {
            
            pControls = player.GetComponent<PlayerControls>();
            pControls.lockMovement = true;
            StartCoroutine(QTE());   
            
        }

    }

    private void Update()
    {

        if (started && pControls.Manette.aButton.wasPressedThisFrame) spamNb++;

    }

    public IEnumerator QTE()
    {

        started = true;
        
        yield return new WaitForSeconds(timeToSpam);

        pControls.lockMovement = false;
        //pControls.GetComponent<PlayerGrabs>().GetItemGrabbed().accuracy += (float)(Math.Round(spamNb / 10f) * 0.1f);
        Debug.Log("Added " + (float) (Math.Round(spamNb / 20f) * 0.1f) + " To item accuracy. it is now " +
                  pControls.GetComponent<PlayerGrabs>().GetItemGrabbed().accuracy);
        yield return new WaitForSeconds(1);
        started = false;

    }
    
}
