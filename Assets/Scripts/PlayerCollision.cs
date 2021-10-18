using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody rb;
    public int superJumpsRemaining = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
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
            float force = 9f;
            // Boost player upwards
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
