using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Damager : MonoBehaviour
{
    public bool hurt = false;
    public int Damage = 1;
    public Health playerHealth;
    void Start()
    {

    }
    void Update()
    {

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hurt == false)
            {
                hurt = true;
                playerHealth = collision.gameObject.GetComponent<Health>();
                playerHealth.TakeDamage(Damage); 
                hurt = false;
            }
        }
        
    }
}