using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] Animator animationController;
    List<GameObject> collidingObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        animationController.SetBool("trigger", true);
        collidingObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObjects.Remove(other.gameObject);
        if (collidingObjects.Count == 0)
        {
            //Make sure no other objects are colliding, for example the cube has exited but the player is still colliding
            animationController.SetBool("trigger", false);
        }
    }
}
