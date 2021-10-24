using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPositioning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 10)
        {
            // Make sure that game object is not player's hands
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 10)
        {
            other.transform.parent = null;
        }
    }
}
