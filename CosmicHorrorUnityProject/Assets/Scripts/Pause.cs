  using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes if needed

public class PauseManager : MonoBehaviour
{
    public GameObject PauseUI; // Assign your pause menu panel here
    private bool isPaused = false;

    void Start()
    {
        if (PauseUI != null)
        {
            PauseUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Stop game time
        if (PauseUI != null)
        {
            PauseUI.SetActive(true); // Show pause menu
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume game time
        if (PauseUI != null)
        {
            PauseUI.SetActive(false); // Hide pause menu
        }
    }
}