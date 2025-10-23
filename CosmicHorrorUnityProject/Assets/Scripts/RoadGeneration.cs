using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadGeneration : MonoBehaviour
{

    // variables

    public GameObject Obstacles;
    public Transform lanes;

    private bool CreatingObstacle = false;

    private int difficulty = 1;

    private int counter = 0;

    [SerializeField] private InfiniteGeneration infiniteGeneration;


    void Update()
    {
        if (CreatingObstacle == false)
        {
        CreatingObstacle = true;
        StartCoroutine(ObstacleGen());
        } 
    }
private void SetPosition(GameObject Clone, Transform Entity)
{
    // Set the clone's position to match the entity's position
    Clone.transform.position = Entity.position;
}

    IEnumerator ObstacleGen()
    {
        Debug.Log("Generating Obstacle");
        GameObject Clone = Instantiate(Obstacles);
        
        SetPosition(Clone, lanes);
        Clone.SetActive(true);
        yield return new WaitForSeconds(12 - (difficulty * 0.1f));

        counter = infiniteGeneration.counter;

        if (counter > 5)
        {
            counter = 0;
            difficulty++;
            print("difficulty "+ difficulty);
        }

        CreatingObstacle = false;
    }
}
