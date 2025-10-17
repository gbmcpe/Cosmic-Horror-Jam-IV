using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGeneration : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject[] Obstacles;
    public List<Transform> lanes;

private bool CreatingObstacle = false;

private int difficulty = 1;

private int counter = 0;

    void Update()
    {
        if (CreatingObstacle == false)
        {
        CreatingObstacle = true;
        StartCoroutine(ObstacleGen());
        } 
    }


    IEnumerator ObstacleGen()
    {
        int obstaclenum = Random.Range(0, 7);
        int laneIndex = Random.Range(0, lanes.Count);

        GameObject Clone = Instantiate(Obstacles[obstaclenum]);

        Vector3 newPosition = Clone.transform.position;
        newPosition.x = lanes[laneIndex].position.x;
        Clone.transform.position = newPosition;

        Clone.SetActive(true);
    
    
        
        yield return new WaitForSeconds(3 - (difficulty * 0.1f));

        counter++;

        if (counter > 5)
        {
            counter = 0;
            difficulty++;
            print("difficulty "+ difficulty);
        }

        CreatingObstacle = false;
    }



}
