using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Health : MonoBehaviour
{
    public int health;
    public int maxHP = 3;
    public bool invuln = false;
    public Sprite Broken;
    public GameObject DeathUI;
    public TextMeshProUGUI playScore; // Reference to the playScore text object in DeathUI
    private int HighScore;
    
    
    [SerializeField] private Image health1;
    [SerializeField] private Image health2;
    [SerializeField] private Image health3;
    [SerializeField] private ScoringSystem scoring;
    
    void Start()
    {
        HighScore = 0;
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
                
                if (scoring.Score > HighScore)
                {
                    HighScore = scoring.Score;
                }
                Debug.Log("High Score: " + scoring.Score.ToString());
                playScore.text = HighScore.ToString();
                
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