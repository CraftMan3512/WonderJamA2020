using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[Serializable]
public class OnEndSpin : UnityEvent<GameObject>
{
}

public class QTESpin : MonoBehaviour
{

    private Manette manette;

    public float forceTreshold = 0.5f;
    public float precisionMin = 0.4f;
    public int nbSpins = 20;
    private int spin = 0;
    public float accGain;

    private bool started;

    private GameObject ply;

    private bool l, r, d;

    public OnEndSpin onEndSpin;

    public void StartQTE(GameObject player)
    {

        if (!started && player.GetComponent<PlayerGrabs>().GetItemGrabbed() != null)
        {
            ply = player;
            manette = player.GetComponent<PlayerControls>().Manette;
            player.GetComponent<PlayerControls>().lockMovement = true;
            started = true;
            transform.Find("Joystick").GetComponent<SpriteRenderer>().enabled = true;
            spin = 0;

        }
        
    }

    private void Update()
    {

        if (manette != null && started)
        {
            
            //Debug.Log("LStick is " + manette.leftStick);   
            if (manette.leftStick.x > forceTreshold && Between(manette.leftStick.y, -precisionMin, precisionMin) && !r)
            {

                r = true;
                //Debug.Log("RIGHT");

            } else if (manette.leftStick.y < -forceTreshold &&
                       Between(manette.leftStick.x, -precisionMin, precisionMin) && r)
            {

                d = true;
                //Debug.Log("DOWN");

            } else if (manette.leftStick.x < -forceTreshold &&
                       Between(manette.leftStick.y, -precisionMin, precisionMin) && d)
            {

                l = true;
                //Debug.Log("LEFT");

            }else if (manette.leftStick.y > forceTreshold &&
                      Between(manette.leftStick.x, -precisionMin, precisionMin) && l)
            {

                spin++;
                if (spin == nbSpins) StartCoroutine(QTE());
                l = d = r = false;
                //Debug.Log("Spin!");

            } 

        }

    }

    IEnumerator QTE()
    {
        Debug.Log("Spinned Item!!!");
            ply.GetComponent<PlayerControls>().lockMovement = false;
        
            ply.GetComponent<PlayerGrabs>().GetItemGrabbed().accuracy += accGain;
        
            transform.Find("Joystick").GetComponent<SpriteRenderer>().enabled = false;
            
            onEndSpin.Invoke(ply);
        
            yield return new WaitForSeconds(1f);

            started = false;

    }
    public bool Between(float val, float min, float max)
    {

        return (val > min && val < max);

    }
    

}
