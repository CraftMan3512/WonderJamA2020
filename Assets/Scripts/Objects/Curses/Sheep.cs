using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Effect
{
    float time;
    GameObject sheep;
    GameObject manager;
    public Sheep(float timeTransformed)
    {
        time = timeTransformed;
        manager = GameObject.Find("CurseManager");
    }
    public override void Invoke(GameObject player)
    {
        playerAffected = player;       
        manager.GetComponent<Manager>().StartChildCoroutine(Transformation());

    }

    IEnumerator Transformation()
    {
        PlayerControls controls = playerAffected.GetComponent<PlayerControls>();
        Object sheepObject = Object.Instantiate(Resources.Load("Prefab/Sheep"), null);
        sheep = ((GameObject)sheepObject); 
        sheep.transform.position = playerAffected.transform.position;
        GenericMovement sheepMovement = sheep.AddComponent<GenericMovement>();
        sheepMovement.Manette = controls.Manette;
        sheepMovement.moveSpeed = controls.moveSpeed / 2;        
        playerAffected.SetActive(false);

        yield return new WaitForSeconds(time);
        if (playerAffected != null)
        {
            if (!playerAffected.activeSelf)
            {
                playerAffected.SetActive(true);
                playerAffected.transform.position = sheep.transform.position;
                GameObject.Destroy(sheep);
            }
        }


    }

    public override void NextDay()
    {
        if (playerAffected != null)
        {
            if (!playerAffected.activeSelf)
            {
                playerAffected.SetActive(true);
                playerAffected.transform.position = sheep.transform.position;
                GameObject.Destroy(sheep);
            }
        }
    }
}
