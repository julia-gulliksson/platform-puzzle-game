using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        float force = 9f;
        // Boost objects upwards
        other.rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
