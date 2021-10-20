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
    void Start()
    {
        playerTransform = transform.parent;
        handsCollider = GetComponent<Collider>();
        playerCollider = playerTransform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetButton("Fire3") + "FIRE");

        if (Input.GetButton("Fire3") && heldObject == null)
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
        else if (!Input.GetButton("Fire3") && heldObject != null)
        {
            HandleDrop();
        }
    }

    void HandlePickUp(GameObject objectToPickUp)
    {
        // Ignore collision with hands + player and object, to prevent kinematic collider to cause player to fly
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
