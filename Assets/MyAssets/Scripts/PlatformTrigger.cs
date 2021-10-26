using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    // Declare delegate and event
    public delegate void PlatformTriggered(bool entered);
    public static event PlatformTriggered platformTriggered;

    [SerializeField] Animator animationController;
    List<GameObject> collidingObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        animationController.SetBool("trigger", true);
        // Add the colliding gameobject to the list, to be checked later
        collidingObjects.Add(other.gameObject);

        // If defined (at least one function is subscribed), invoke event
        platformTriggered?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObjects.Remove(other.gameObject);
        if (collidingObjects.Count == 0)
        {
            // Make sure no other objects are colliding, for example the cube has exited but the player is still colliding
            animationController.SetBool("trigger", false);
            platformTriggered?.Invoke(false);
        }
    }
}
