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
    
    [Header("Player Detection")]
    public float countdownTime = 1f;
    private bool playerInTrigger = false;
    private GameObject playerInside;

    public bool fullAttacks;

    
    void Start()
    {
        fullAttacks = false;
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
            fullAttacks = true;
            yield break;
        }
        
        int randomIndex = Random.Range(0, availableSpots.Count);
        int selectedSpotIndex = availableSpots[randomIndex];

        spotTaken[selectedSpotIndex] = true;

        yield return new WaitForSeconds(10f);

        if (objectToSpawn != null && spawnSpots[selectedSpotIndex] != null)
        {
            spawnedObject = Instantiate(objectToSpawn, spawnSpots[selectedSpotIndex].position, spawnSpots[selectedSpotIndex].rotation);
            spawnedObject.SetActive(true);
            Debug.Log($"Spawned object at spot {selectedSpotIndex}");
        }
        
        // spotTaken[selectedSpotIndex] = false;
        // Debug.Log($"Spot {selectedSpotIndex} is now available again");

        // Destroy(spawnedObject);
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

    // These trigger methods won't work since this script is not on the object with the collider
    // You need to either:
    // 1. Move this script to the attack object prefab, OR
    // 2. Create a separate trigger script for the attack objects
    
    public void OnPlayerEnterAttack(GameObject player)
    {
        playerInTrigger = true;
        playerInside = player;
        StartCoroutine(PlayerCountdown());
        Debug.Log("Player entered cosmic attack trigger - countdown started!");
    }

    public void OnPlayerExitAttack(GameObject player)
    {
        playerInTrigger = false;
        playerInside = null;
        Debug.Log("Player left cosmic attack trigger - countdown cancelled!");
    }

    private IEnumerator PlayerCountdown()
    {
        Debug.Log($"Cosmic attack countdown started: {countdownTime}s");
        
        // Simple yield wait for the countdown time
        yield return new WaitForSeconds(countdownTime);

        // If player is still in trigger after countdown, destroy them
        if (playerInTrigger && playerInside != null)
        {
            Debug.Log("Player stayed too long in cosmic attack - destroying player!");
            Destroy(playerInside);
            playerInTrigger = false;
            playerInside = null;
        }
    }
}
