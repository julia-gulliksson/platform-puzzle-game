using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    // Declare delegate and event
    public delegate void PlatformTriggered(bool entered, int id);
    public static event PlatformTriggered platformTriggered;

    [SerializeField] Animator animationController;
    List<GameObject> collidingObjects;
    // Identifier of this platform trigger
    [SerializeField] int id;

    private void OnEnable()
    {
        collidingObjects = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animationController.SetBool("trigger", true);

        // Add the colliding gameobject to the list, to be checked later
        collidingObjects.Add(other.gameObject);

        // If defined (at least one function is subscribed), invoke event
        platformTriggered?.Invoke(true, id);
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObjects.Remove(other.gameObject);

        // Make sure no other objects are colliding (for example if the cube has exited but the player is still colliding)
        if (collidingObjects.Count == 0)
        {
            animationController.SetBool("trigger", false);
            platformTriggered?.Invoke(false, id);
        }
    }
}
