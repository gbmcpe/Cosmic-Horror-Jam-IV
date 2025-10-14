using UnityEngine;

public class ObstacleMover : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody Obstacle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Obstacle = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Obstacle.linearVelocity = new Vector3(0, 0, -speed);
    }
}
