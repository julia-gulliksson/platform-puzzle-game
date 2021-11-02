using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public delegate void ObjectPickedUp();
    public static event ObjectPickedUp objectPickedUp;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] float pickUpRange = 5;
    [SerializeField] LayerMask _interactionMask;

    GameObject heldObject;
    Transform playerTransform;
    Collider handsCollider;
    Collider playerCollider;
    bool hasPickedUp = false;

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
            HandleRayCast();
        }

        if ((!Input.GetButton("Fire3") && heldObject != null) || (!playerMovement.isGrounded && heldObject != null))
        {
            HandleDrop();
        }
    }

    void HandleRayCast()
    {
        Vector3 forward = transform.TransformDirection(0, -1, 0);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, forward, out hit, pickUpRange, _interactionMask))
        {
            HandlePickUp(hit.transform.gameObject);
        }
    }

    float GetXPosition(Transform object1, Transform object2)
    {
        float offset = 0.75f;
        if (object1.position.x > object2.position.x)
        {
            // Object is on the right of the player, so offset with a positive number
            return playerTransform.position.x + offset;
        }
        else
        {
            return playerTransform.position.x - offset;
        }
    }

    void HandlePickUp(GameObject objectToPickUp)
    {
        /* Ignore collision with hands + player
          (to prevent kinematic collider to cause player to fly when moving) */
        Physics.IgnoreCollision(objectToPickUp.GetComponent<Collider>(), handsCollider);
        Physics.IgnoreCollision(objectToPickUp.GetComponent<Collider>(), playerCollider);

        // Make object possible to pick up
        Rigidbody objectRb;
        objectRb = objectToPickUp.GetComponent<Rigidbody>();
        objectToPickUp.transform.parent = playerTransform;
        objectRb.isKinematic = true;

        // Position object correctly
        float xPosition = GetXPosition(objectToPickUp.transform, transform);
        objectToPickUp.transform.position = new Vector3(xPosition, playerTransform.position.y - 0.1f, 0);
        objectToPickUp.transform.eulerAngles = new Vector3(0, 0, 0);
        heldObject = objectToPickUp;

        //If player has not picked an object up before, invoke event
        if (!hasPickedUp)
        {
            objectPickedUp?.Invoke();
        }
        hasPickedUp = true;
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
