using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private TextMeshProUGUI scoreText; // UI Text reference to display score
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        scoreText.text = Score.ToString();
        StartCoroutine(ScoreIncrement());
    }

    // More efficient coroutine approach
    IEnumerator ScoreIncrement()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait 1 second
            Score += 1;
            scoreText.text = Score.ToString();
        }
    }
}
