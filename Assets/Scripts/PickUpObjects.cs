using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    GameObject heldObject;
    [SerializeField] float pickUpRange = 5;
    Transform playerTransform;
    Collider handsCollider;
    Collider playerCollider;
    [SerializeField] PlayerMovement playerMovement;
    void Start()
    {
        playerTransform = transform.parent;
        handsCollider = GetComponent<Collider>();
        playerCollider = playerTransform.GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetButton("Fire3") && heldObject == null && playerMovement.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(0, -1, 0);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, forward, out hit, pickUpRange))
            {
                if (hit.transform.gameObject.layer == 9)
                {
                    // Object is a rock, pick it up
                    HandlePickUp(hit.transform.gameObject);
                }
            }
        }

        if ((!Input.GetButton("Fire3") && heldObject != null) || (!playerMovement.isGrounded && heldObject != null))
        {
            HandleDrop();
        }
    }

    void HandlePickUp(GameObject objectToPickUp)
    {
        /* Ignore collision with hands + player and object
          (to prevent kinematic collider to cause player to fly when moving) */
        Physics.IgnoreCollision(objectToPickUp.GetComponent<Collider>(), handsCollider);
        Physics.IgnoreCollision(objectToPickUp.GetComponent<Collider>(), playerCollider);

        Rigidbody objectRb;
        objectRb = objectToPickUp.GetComponent<Rigidbody>();
        objectToPickUp.transform.parent = playerTransform;
        objectRb.isKinematic = true;
        objectToPickUp.transform.position = new Vector3(objectToPickUp.transform.position.x, playerTransform.position.y - 0.2f, 0);

        heldObject = objectToPickUp;
    }

    void HandleDrop()
    {
        // Stop ignoring collision
        Physics.IgnoreCollision(heldObject.GetComponent<Collider>(), handsCollider, false);
        Physics.IgnoreCollision(heldObject.GetComponent<Collider>(), playerCollider, false);

        Rigidbody heldObjectRb = heldObject.GetComponent<Rigidbody>();
        heldObject.transform.parent = null;
        heldObjectRb.isKinematic = false;

        heldObject = null;
    }
}
