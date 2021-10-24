using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPositioning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 10)
        {
            other.transform.parent = transform;
        }
        else
        {
            // Game object is the player's hands, set its parent's transform (the player) to this transform
            other.transform.parent.parent = transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10 && other.transform.parent.parent == null)
        {
            // Fixes issue with hands stop triggering collider
            other.transform.parent.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 10)
        {
            other.transform.parent = null;
        }
        else
        {
            other.transform.parent.parent = null;
        }
    }
}
