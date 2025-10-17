using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CosmicAttackScript : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn;
    public List<Transform> spawnSpots = new List<Transform>();

    private List<bool> spotTaken;
    private GameObject spawnedObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the spotTaken list with all spots available
        spotTaken = new List<bool>();
        for (int i = 0; i < spawnSpots.Count; i++)
        {
            spotTaken.Add(false);
        }

        StartCoroutine(SpawnObjectAtRandomSpot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Coroutine to spawn object at random spot and wait 10 seconds
    public IEnumerator SpawnObjectAtRandomSpot()
    {
        // Check if there are any available spots
        List<int> availableSpots = new List<int>();
        for (int i = 0; i < spawnSpots.Count; i++)
        {
            if (!spotTaken[i])
            {
                availableSpots.Add(i);
            }
        }
        
        // If no spots are available, exit coroutine
        if (availableSpots.Count == 0)
        {
            Debug.LogWarning("No available spawn spots!");
            yield break;
        }
        
        // Select a random available spot
        int randomIndex = Random.Range(0, availableSpots.Count);
        int selectedSpotIndex = availableSpots[randomIndex];
        
        // Mark the spot as taken
        spotTaken[selectedSpotIndex] = true;
        
        // Spawn the object at the selected spot
        if (objectToSpawn != null && spawnSpots[selectedSpotIndex] != null)
        {
            spawnedObject = Instantiate(objectToSpawn, spawnSpots[selectedSpotIndex].position, spawnSpots[selectedSpotIndex].rotation);
            spawnedObject.SetActive(true);
            Debug.Log($"Spawned object at spot {selectedSpotIndex}");
        }
        
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);
        
        // Mark the spot as available again after 10 seconds
        spotTaken[selectedSpotIndex] = false;
        Debug.Log($"Spot {selectedSpotIndex} is now available again");

        Destroy(spawnedObject);

    }
    
    // Public method to start the spawning coroutine
    public void StartSpawning()
    {
        
    }
    
    // Method to reset all spots to available
    public void ResetAllSpots()
    {
        for (int i = 0; i < spotTaken.Count; i++)
        {
            spotTaken[i] = false;
        }
        Debug.Log("All spawn spots reset to available");
    }
}
