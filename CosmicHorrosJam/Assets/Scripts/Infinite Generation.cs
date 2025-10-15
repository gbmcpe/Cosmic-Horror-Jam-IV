using System.Collections;
using UnityEngine;

public class InfiniteGeneration : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public GameObject[] Obstacles;
    


private bool CreatingObstacle = false;



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
        int obstaclenum= Random.Range (0, 7);

        GameObject Clone = Instantiate(Obstacles[obstaclenum]);

        Clone.SetActive(true);
        
        
        
        yield return new WaitForSeconds(3);

        CreatingObstacle = false;
    }



}
