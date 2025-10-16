using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private string sceneName; // Name of the scene to load
    [SerializeField] private int sceneIndex;  // Build index of the scene to load
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Public function to change to a specific scene by name
    public void ChangeSceneN()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Alternative function to change scene by build index
    public void ChangeSceneI()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
