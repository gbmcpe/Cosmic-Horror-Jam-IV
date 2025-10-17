using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHP = 3;
    void Start()
    {
        health = maxHP;
    }
    void Update()
    {

    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}