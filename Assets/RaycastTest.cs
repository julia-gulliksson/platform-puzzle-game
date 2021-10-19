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
        if (heldObject == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, pickUpRange))
            {
                Debug.Log(hit.transform.gameObject.name);
                //PickUpObject(hit.transform.gameObject);
            }
        }
    }
}
