using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    GameObject heldObject;
    [SerializeField] float pickUpRange = 5;
    [SerializeField] Transform player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position + "position");
        //Debug.Log("right" + transform.TransformDirection(Vector3.right));
        Vector3 forward = transform.TransformDirection(0, -1, 0) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (heldObject == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(0, -1, 0), out hit, pickUpRange))
            {
                Debug.Log(hit.transform.gameObject.name);
                //PickUpObject(hit.transform.gameObject);
            }
        }
    }
}
