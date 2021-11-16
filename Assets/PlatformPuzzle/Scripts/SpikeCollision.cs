using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IDestroyable objectCollider = other.gameObject.GetComponent<IDestroyable>();
        objectCollider?.HandleSpikeCollision();
    }
}
