using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform groundCheckTransform = null;
    [SerializeField] Transform handgroundCheckTransform = null;
    [SerializeField] LayerMask playerMask;
    [SerializeField] LayerMask handColliderMask;
    [SerializeField] ScoreManager scoreManager;
    bool jumpKeyWasPressed = false;
    float horizontalInput;
    Rigidbody rb;
    public bool isGrounded;
    public GameObject gameOverUI;

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
        CheckIfFalling();

        MovePlayer();

        CheckIfGrounded();

        HandleJump();
    }

    void MovePlayer()
    {
        //Make player move on the x axis
        rb.velocity = new Vector3(horizontalInput * 3, rb.velocity.y, 0);
        transform.LookAt(transform.position + new Vector3(horizontalInput, 0.0f, 0));
    }

    void CheckIfGrounded()
    {
        if (Physics.OverlapSphere(handgroundCheckTransform.position, 0.1f, handColliderMask).Length != 0)
        {
            // Player is stuck with hands on platform, enable jumping
            isGrounded = true;
        }
        else
        {
            isGrounded = Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length != 0;
        }
    }

    void CheckIfFalling()
    {
        if (rb.position.y <= -1.4f)
        {
            // Player has fallen off the edge, show Game over ui
            gameOverUI.SetActive(true);
        }
    }

    void HandleJump()
    {
        if (!isGrounded)
        {
            // Player is in the air, return to prevent jump
            return;
        }
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;

            if (scoreManager.superJumpCoins > 0)
            {
                jumpPower *= 1.5f;
                scoreManager.DecreaseSuperJumps();
            }
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }
}
