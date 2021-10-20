using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    GameObject heldObject;
    [SerializeField] float pickUpRange = 5;
    [SerializeField] Transform player;
    bool shiftKeyIsPressed = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position + "position");
        //Debug.Log("right" + transform.TransformDirection(Vector3.right));
        Vector3 forward = transform.TransformDirection(0, -1, 0);
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Input.GetButton("Fire3") && heldObject == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(0, -1, 0), out hit, pickUpRange))
            {
                //Debug.Log(hit.transform.gameObject.name);
                PickUpObject(hit.transform.gameObject);
            }
        }
    }

    void PickUpObject(GameObject objectToPickUp)
    {
        if (objectToPickUp.layer == 9)
        {
            // Ignore collision with hands + player and object, to prevent kinematic collider to cause player to fly
            Physics.IgnoreCollision(objectToPickUp.GetComponent<Collider>(), transform.GetComponent<Collider>());
            Physics.IgnoreCollision(objectToPickUp.GetComponent<Collider>(), transform.parent.GetComponent<Collider>());

            Rigidbody objectRb;
            objectRb = objectToPickUp.GetComponent<Rigidbody>();
            objectToPickUp.transform.parent = transform.parent;
            objectRb.isKinematic = true;
            objectToPickUp.transform.position = new Vector3(objectToPickUp.transform.position.x, transform.parent.position.y - 0.2f, 0);
        }
    }
}
