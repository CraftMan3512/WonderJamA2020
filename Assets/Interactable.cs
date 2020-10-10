using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class OnInteract : UnityEvent<GameObject> {}
public class Interactable : MonoBehaviour
{

    public OnInteract onInteract;

    public void Interact(GameObject player)
    {
        
        onInteract.Invoke(player);
        
    }
    
}
