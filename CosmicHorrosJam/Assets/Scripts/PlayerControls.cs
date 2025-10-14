using System;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{

    private Rigidbody player;

    [SerializeField] private float StrafeSpeed;

    [SerializeField] private float JumpSpeed;

    private bool grounded = true;

    private void Awake()
    {
        player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Strafe();
        Jump();

    }

    private void Strafe()
    {
        player.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * StrafeSpeed, player.linearVelocity.y, 0);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space)
                   && grounded)
        {
            // print("we got spacebar");


            player.linearVelocity = new Vector3(player.linearVelocity.x, JumpSpeed, 0);

            grounded = false;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        { grounded = true; }
    }
    
    





















//if you read this you need to kiss me
}



