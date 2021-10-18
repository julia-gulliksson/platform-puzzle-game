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
        rb.velocity = new Vector3(horizontalInput * 2, rb.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
     
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
