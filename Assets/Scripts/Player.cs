using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    bool jumpKeyWasPressed = false;
    float horizontalInput;
    Rigidbody playerRigidBody;
    public int superJumpsRemaining;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
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
        playerRigidBody.velocity = new Vector3(horizontalInput * 2, playerRigidBody.velocity.y, 0);
        if (transform.position.y < -4)
        {
            Debug.Log("Game over");
        }
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {

            return;
        }
     
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;

            if (superJumpsRemaining > 0)
            {
                jumpPower *= 1.5f;
                superJumpsRemaining--;
            }
            playerRigidBody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

      
    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.layer == 7)
        {
            HandleCoinCollision(other);
        }
    }

    void HandleCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
        superJumpsRemaining++;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8)
        {
            float force = 5f * 1.5f;
            // Boost player upwards
            playerRigidBody.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
       
    }
}
