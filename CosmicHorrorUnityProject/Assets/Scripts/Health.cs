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
    
    
    [SerializeField] private Image health1;
    [SerializeField] private Image health2;
    [SerializeField] private Image health3;
    [SerializeField] private CanvasGroup Blackout;
    void Start()
    {
        health = maxHP;
    }
    void Update()
    {

    }

/*public void blackout()
    {
        for (int i = 0; i < 100; i++)
        {
            Blackout.alpha += 0.01f;  Currently breaks, idk man
        }
    } 
    */
    public void TakeDamage(int Damage)
    {
        if (invuln == false)
        {
            StartCoroutine(Invulntime());
            health -= Damage;
            if (health <= 0)
            {
                health1.sprite = Broken;
                // blackout();
                SceneManager.LoadScene("Main Menu");
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