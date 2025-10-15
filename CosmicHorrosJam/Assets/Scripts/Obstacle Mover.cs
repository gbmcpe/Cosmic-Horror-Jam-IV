using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{

    [SerializeField] private float speed;
    
    private Rigidbody ObRigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       ObRigid.linearVelocity = new Vector3(0, 0, -speed);


        if (ObRigid.position.z < -10)
        { Destroy(gameObject); }
    }
}
