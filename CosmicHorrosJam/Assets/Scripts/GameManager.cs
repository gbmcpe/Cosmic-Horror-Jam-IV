using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        Debug.Log("Game Started");
    }

    public void DestroyThisGameObject()
    {
        Destroy(gameObject);
    }
}
