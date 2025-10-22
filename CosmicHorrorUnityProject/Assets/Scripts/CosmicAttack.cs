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
    public float countdownTime = 2f;
    private bool playerInTrigger = false;
    private GameObject playerInside;
    private CosmicAttackTrigger triggerScript;


    
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
            // END GAME HERE
            yield break;
        }
        
        int randomIndex = Random.Range(0, availableSpots.Count);
        int selectedSpotIndex = availableSpots[randomIndex];

        spotTaken[selectedSpotIndex] = true;

        yield return new WaitForSeconds(10f);

        if (objectToSpawn != null && spawnSpots[selectedSpotIndex] != null)
        {
            spawnedObject = Instantiate(objectToSpawn, spawnSpots[selectedSpotIndex].position, spawnSpots[selectedSpotIndex].rotation);
            
            Collider attackCollider = spawnedObject.GetComponent<Collider>();
            if (attackCollider != null && attackCollider.isTrigger)
            {
                Debug.Log("Attack object collider found and is set as trigger");
                
                triggerScript = spawnedObject.GetComponent<CosmicAttackTrigger>();
                if (triggerScript == null)
                {
                    triggerScript = spawnedObject.AddComponent<CosmicAttackTrigger>();
                }
                triggerScript.parentScript = this;
                triggerScript.laneIndex = selectedSpotIndex;
            }
            else if (attackCollider != null)
            {
                Debug.LogWarning("Attack object has collider but 'Is Trigger' is not checked!");
            }
            else
            {
                Debug.LogError("Attack object has no collider component!");
            }

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

    // Called by CosmicAttackTrigger component on spawned attack objects
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

        yield return new WaitForSeconds(countdownTime);
        if (playerInTrigger && playerInside != null)
        {
            Debug.Log("Player stayed too long in cosmic attack - destroying player!");

            Health playerHealth = playerInside.GetComponent<Health>();
            playerHealth.TakeDamage(1);

            playerInTrigger = false;
            playerInside = null;
        }
    }
    
    public void OnAttackObjectDestroyed(int laneIndex)
    {
        if (laneIndex >= 0 && laneIndex < spotTaken.Count)
        {
            spotTaken[laneIndex] = false;
            playerInTrigger = false;
            playerInside = null;
            
            // Destroy the spawned attack object if it exists
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
                Debug.Log($"Attack object in lane {laneIndex} destroyed - spot is now available");
            }
            else
            {
                Debug.LogWarning($"No attack object found to destroy in lane {laneIndex}");
            }
        }
        else
        {
            Debug.LogWarning("Invalid lane index received for attack object destruction");
        }
    }
}
