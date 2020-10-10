using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarAdjustment : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;

    public Healthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        for(float i = 0.1f; i < damage;)
        {
            healthbar.SetCurrentHealth(currenthealth - i);
            currenthealth -= i;
        }

    }
}
