using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Rigidbody rb;
    public int superJumpsRemaining = 0;
    bool shiftKeyIsPressed = false;
    [SerializeField] Transform guide;
    bool isHolding = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftKeyIsPressed = true;
        } else
        {
            shiftKeyIsPressed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            HandleCoinCollision(other);
        }
        if (other.gameObject.layer == 9)
        {
            HandleCubeCollision(other);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            HandleCubeCollision(other);
        }
    }

    void HandleCubeCollision(Collider cube)
    {
        //Add check to see if jumping, disable if jumping

        //Check if on left or right side of object
        //Only move if dragging object with you
        if (shiftKeyIsPressed && !isHolding)
        {
            cube.attachedRigidbody.isKinematic = true;
            cube.transform.parent = guide;
            isHolding = true;
        }
        else
        {
            cube.attachedRigidbody.isKinematic = false;
            cube.transform.parent = guide;
            isHolding = false;
        }
    }

    void HandleCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
        superJumpsRemaining++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 && !isHolding)
        {
            // Object is a cube
            //if (shiftKeyWasPressed)
            //{
                //collision.rigidbody.useGravity = false;
                //collision.rigidbody.isKinematic = true;
                //collision.transform.position = guide.transform.position;
                //collision.transform.rotation = guide.transform.rotation;
                //collision.transform.parent = guide;
                //isHolding = true;
            //}
            //else if (isHolding && !shiftKeyWasPressed)
            //{
            //    collision.rigidbody.useGravity = true;
            //    collision.rigidbody.isKinematic = false;
            //    collision.transform.position = guide.transform.position;
            //    collision.transform.parent = null;
            //    isHolding = false;
            //}
        }
    }

}
