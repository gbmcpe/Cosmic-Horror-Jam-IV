  using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes if needed

public class PauseManager : MonoBehaviour
{
    public GameObject PauseUI; // Assign your pause menu panel here
    private bool isPaused = false;
    [SerializeField] private AudioClip pauseSound; // Sound to play on pause/resume
    [SerializeField] private AudioClip resumeSound; // Sound to play on resume
    [SerializeField] private AudioSource audioSource; // AudioSource to play the sounds
    [SerializeField] private AudioSource gameAudioSource; // AudioSource for game audio

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
        gameAudioSource.Pause(); // Pause all game audio
        audioSource.PlayOneShot(pauseSound); // Play pause sound
        isPaused = true;
        Time.timeScale = 0f; // Stop game time
        if (PauseUI != null)
        {
            PauseUI.SetActive(true); // Show pause menu
        }
    }

    public void ResumeGame()
    {
        audioSource.PlayOneShot(resumeSound); // Play resume sound
        gameAudioSource.UnPause(); // Resume all game audio
        isPaused = false;
        Time.timeScale = 1f; // Resume game time
        if (PauseUI != null)
        {
            PauseUI.SetActive(false); // Hide pause menu
        }
    }
}