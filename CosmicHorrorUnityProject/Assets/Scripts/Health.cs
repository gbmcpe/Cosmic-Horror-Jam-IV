using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHP = 3;
    [SerializeField] private GameObject health1;
    [SerializeField] private GameObject health2;
    [SerializeField] private GameObject health3;
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
            health1.SetActive(false);
            Destroy(gameObject);
        }
        if (health == 2)
        {
            health3.SetActive(false);
        }
        if (health == 1)
        {
            health2.SetActive(false);
        }
    }
}