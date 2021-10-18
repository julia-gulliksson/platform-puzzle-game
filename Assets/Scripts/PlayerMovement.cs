using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    bool jumpKeyWasPressed = false;
    float horizontalInput;
    Rigidbody rb;
    [SerializeField] PlayerCollision playerCollision;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //Make player move right-left
        rb.velocity = new Vector3(horizontalInput * 2, rb.velocity.y, 0);
        if (CheckIfNotGrounded())
        {
            // Player is in the air, return to prevent jump
            return;
        }
        HandleJump();
    }

    bool CheckIfNotGrounded()
    {
        return Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0;
    }

    void HandleJump()
    {
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;

            if (playerCollision.superJumpsRemaining > 0)
            {
                jumpPower *= 1.5f;
                playerCollision.superJumpsRemaining--;
            }
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }
}
