using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody rb;
    public int superJumpsRemaining = 0;
    bool shiftKeyIsPressed = false;
    [SerializeField] Transform guide;
    //bool isHolding = false;
    //SAVE GAME OBJECT holding
    GameObject heldObject;
    [SerializeField] float pickUpRange = 50;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //if (Input.GetButton("Fire3"))
        //{
        //    shiftKeyIsPressed = true;
        //if (heldObject == null)
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, pickUpRange))
        //    {
        //        Debug.Log(hit.transform.gameObject.name);
        //        //PickUpObject(hit.transform.gameObject);
        //    }
        //}
        //} else
        //{
        //    shiftKeyIsPressed = false;
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            HandleCoinCollision(other);
        }
        //if (other.gameObject.layer == 9)
        //{
        //    if (shiftKeyIsPressed && !isHolding)
        //    {
        //        Debug.Log("Start holding");
        //        other.attachedRigidbody.isKinematic = true;
        //        other.transform.parent = transform;
        //        isHolding = true;
        //    }
        //}
    }

    //private void OnTriggerStay(Collider other)
    //{

    //    if (other.gameObject.layer == 9)
    //    {
    //        Debug.Log("Staying");
    //        HandleCubeCollision(other);
    //        // ADD HELDOBJECT 
    //    }
    //}

    //void HandleCubeCollision(Collider cube)
    //{
    //    //Add check to see if jumping, disable if jumping

    //    //Check if on left or right side of object
    //    //Only move if dragging object with you
    //    Debug.Log(isHolding);
    //    if (shiftKeyIsPressed && !isHolding)
    //    {
    //            Debug.Log("Start holding");
    //            cube.attachedRigidbody.isKinematic = true;
    //            cube.transform.parent = transform;
    //            cube.transform.eulerAngles = new Vector3(0, 0, 0);
    //            cube.transform.localPosition = new Vector3(transform.position.x - 0.1f, cube.transform.position.y, 0);
    //            isHolding = true; 
    //    }
    //    else if(!shiftKeyIsPressed && isHolding)  
    //    {
    //        Debug.Log("Stop holding");

    //        cube.attachedRigidbody.isKinematic = false;
    //        cube.transform.parent = null;
    //        isHolding = false;
    //    }
    //}

    void HandleCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
        superJumpsRemaining++;
    }

}
