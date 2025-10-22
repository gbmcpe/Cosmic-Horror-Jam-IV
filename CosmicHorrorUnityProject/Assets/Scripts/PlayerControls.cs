using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{

    private Rigidbody player;

    [SerializeField] private float StrafeSpeed;

    [SerializeField] private float JumpHeight;
    [SerializeField] private float JumpDuration;
    private bool grounded = true;
    private Animator animator;
    private bool isJumping = false; // Track if jump is in progress
    private bool isAttacking = false; // Track if attack is in progress

    private CosmicAttackTrigger cosmicAttackTrigger;
    [SerializeField] private AudioSource attackAudioSource; // AudioSource for attack sound
    [SerializeField] private AudioClip attackSound; // Attack sound clip


    private void Awake()
    {
        player = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Strafe();
        Jump();
        Attack();

    }

    private void Strafe()
    {
        player.linearVelocity = new Vector3(Input.GetAxis("Horizontal") * StrafeSpeed, player.linearVelocity.y, 0);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded && !isJumping)
        {
            attackAudioSource.PlayOneShot(attackSound); // Play attack sound
            animator.SetTrigger("jump");
            StartCoroutine(JumpSequence());
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F) && grounded && !isJumping)
        {
            attackAudioSource.PlayOneShot(attackSound); // Play attack sound
            isAttacking = true;
            animator.SetTrigger("attack");
            StartCoroutine(JumpSequence());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        cosmicAttackTrigger = other.gameObject.GetComponent<CosmicAttackTrigger>();
    }

    private IEnumerator JumpSequence()
    {
        isJumping = true;
        
        yield return new WaitForSeconds(3f / 12f); 
        
        grounded = false;
        
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        
        while (elapsedTime < JumpDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / JumpDuration;
            
            float heightMultiplier = 4f * progress * (1f - progress);
            float currentHeight = startPosition.y + (JumpHeight * heightMultiplier);

            transform.position = new Vector3(transform.position.x, currentHeight, startPosition.z);
            
            if (cosmicAttackTrigger != null && isAttacking)
            {
                Debug.Log("Attack triggered on Cosmic Attack Trigger");
                cosmicAttackTrigger.NotifyParentOfDestruction();
                isAttacking = false;
            }
            yield return null; // Wait for next frame
        }
        
        // Ensure we end at the starting height
        transform.position = new Vector3(transform.position.x, startPosition.y, startPosition.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        { 
            grounded = true;
            isJumping = false; // Reset jump state when landing
            animator.ResetTrigger("jump");
        }
    }
    
    




















//if you read this you need to kiss me
}



