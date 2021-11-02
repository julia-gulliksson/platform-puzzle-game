using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            BoostCollidingObject(other);
        }
    }

    void BoostCollidingObject(Collider other)
    {
        Rigidbody colliderRb = other.gameObject.GetComponent<Rigidbody>();
        float forceNumber = 6;
        colliderRb.AddForce(Vector3.up * forceNumber, ForceMode.Impulse);
    }
}
