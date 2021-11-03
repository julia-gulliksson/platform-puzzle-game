using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

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

        // Add the colliding gameobject to the list, to be checked in OnTriggerExit
        collidingObjects.Add(other.gameObject);

        GameEventsManager.current.PlatformTriggered(true, id);
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObjects.Remove(other.gameObject);

        // Make sure no other objects are colliding (for example if the cube has exited but the player is still colliding)
        if (collidingObjects.Count == 0)
        {
            animationController.SetBool("trigger", false);
            GameEventsManager.current.PlatformTriggered(false, id);
        }
    }
}
