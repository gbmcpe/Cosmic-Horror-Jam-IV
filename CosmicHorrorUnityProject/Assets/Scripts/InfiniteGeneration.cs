using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGeneration : MonoBehaviour
{


    // variables

    public List<GameObject> Obstacles;
    public List<Transform> lanes;

private bool CreatingObstacle = false;

private int difficulty = 1;

    public int counter = 0;




    void Update()
    {
        if (CreatingObstacle == false)
        {
            CreatingObstacle = true;
            StartCoroutine(ObstacleGen());
            
        }
    }
       


private void SetPosition(GameObject Entity, Transform Position)
{
 Vector3 newPosition = Entity.transform.position;
                newPosition.x = Position.position.x;
                Entity.transform.position = newPosition;

}

    IEnumerator ObstacleGen()
    {
        //randomly picks object
        int obstaclenum = Random.Range(0, Obstacles.Count);
        
        int laneIndex;

        GameObject Clone = Instantiate(Obstacles[obstaclenum]);
        
       
        switch (Clone.GetComponent<ObstacleMover>().width )
        {
            case 1 - 0:
            //case where the object is 1 big

            laneIndex = Random.Range(0, 2);
            SetPosition(Clone, lanes[laneIndex]);

                break;

            case 2:
                //case where the object is 2 big
                laneIndex = Random.Range(3,4);
                SetPosition(Clone, lanes[laneIndex]);
            

                break;

            case 3:
            //case where the object is 3 big
                SetPosition(Clone, lanes[1]);

                break;
        }





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
