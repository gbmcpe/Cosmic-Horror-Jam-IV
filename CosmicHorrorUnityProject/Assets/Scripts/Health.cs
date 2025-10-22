using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int health;
    public int maxHP = 3;
    public bool invuln = false;
    public Sprite Broken;
    public GameObject DeathUI;
    
    
    [SerializeField] private Image health1;
    [SerializeField] private Image health2;
    [SerializeField] private Image health3;
    
    void Start()
    {
        health = maxHP;
    }
    void Update()
    {

    }


    public void TakeDamage(int Damage)
    {
        if (invuln == false)
        {
            StartCoroutine(Invulntime());
            health -= Damage;
            if (health <= 0)
            {
                health1.sprite = Broken;
                DeathUI.SetActive(true); // Show death ui
                // SceneManager.LoadScene("Main Menu");
            }
            if (health == 2)
            {
                health3.sprite = Broken;
            }
            if (health == 1)
            {
                health2.sprite = Broken;
            }
        }
    }
    IEnumerator Invulntime()
    {
        invuln = true;
        yield return new WaitForSeconds(1f);
        invuln = false;
    }
}