using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        float force = 9f;
        // Boost objects upwards
        //other.rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        other.rigidbody.AddForce(new Vector3(0.1f, 0.7f, 0) * force, ForceMode.Impulse);
    }
}
