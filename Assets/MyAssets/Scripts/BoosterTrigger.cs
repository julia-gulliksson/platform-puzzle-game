using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Rigidbody colliderRb = other.gameObject.GetComponent<Rigidbody>();
        float forceNumber = 8;
        Vector3 force;
        if (colliderRb)
        {
            if (other.gameObject.layer == 6)
            {
                // If player, boost only upwards 
                force = Vector3.up * forceNumber;
            }
            else
            {
                force = new Vector3(0.3f, 0.7f, 0) * forceNumber;
            }
            colliderRb.AddForce(force, ForceMode.Impulse);
        }
    }
}
