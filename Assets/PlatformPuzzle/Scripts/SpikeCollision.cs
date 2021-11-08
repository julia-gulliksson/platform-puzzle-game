using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IObjectCollider objectCollider = other.gameObject.GetComponent<IObjectCollider>();
        objectCollider?.HandleCollision();
    }
}
