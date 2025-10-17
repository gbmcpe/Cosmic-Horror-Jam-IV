using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CosmicAttackScript : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject objectToSpawn;
    public List<Transform> spawnSpots;

    private List<bool> spotTaken;
    private GameObject spawnedObject;
    
    void Start()
    {
        spotTaken = new List<bool>();
        for (int i = 0; i < spawnSpots.Count; i++)
        {
            spotTaken.Add(false);
        }

        StartCoroutine(SpawnObjectAtRandomSpot());
    }

    void Update()
    {
        
    }
    
    public IEnumerator SpawnObjectAtRandomSpot()
    {
        List<int> availableSpots = new List<int>();
        for (int i = 0; i < spawnSpots.Count; i++)
        {
            if (!spotTaken[i])
            {
                availableSpots.Add(i);
            }
        }
        
        if (availableSpots.Count == 0)
        {
            Debug.LogWarning("No available spawn spots!");
            yield break;
        }
        
        int randomIndex = Random.Range(0, availableSpots.Count);
        int selectedSpotIndex = availableSpots[randomIndex];
        
        spotTaken[selectedSpotIndex] = true;
        
        if (objectToSpawn != null && spawnSpots[selectedSpotIndex] != null)
        {
            spawnedObject = Instantiate(objectToSpawn, spawnSpots[selectedSpotIndex].position, spawnSpots[selectedSpotIndex].rotation);
            spawnedObject.SetActive(true);
            Debug.Log($"Spawned object at spot {selectedSpotIndex}");
        }
        
        yield return new WaitForSeconds(10f);
        
        spotTaken[selectedSpotIndex] = false;
        Debug.Log($"Spot {selectedSpotIndex} is now available again");

        Destroy(spawnedObject);
        StartCoroutine(SpawnObjectAtRandomSpot());

    }
    
    // public void StartSpawning()
    // {
        
    // }
    
    public void ResetAllSpots()
    {
        for (int i = 0; i < spotTaken.Count; i++)
        {
            spotTaken[i] = false;
        }
        Debug.Log("All spawn spots reset to available");
    }
}
