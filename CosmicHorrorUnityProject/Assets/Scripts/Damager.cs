using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Damager : MonoBehaviour
{
    public int Damage = 1;
    public Health playerHealth;
    void Start()
    {

    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth = other.gameObject.GetComponent<Health>();
            playerHealth.TakeDamage(Damage); 

        }
        
    }
}