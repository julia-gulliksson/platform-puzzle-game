using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cube;
    private Vector3 offset;

    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - cube.transform.position;
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = cube.transform.position + offset;
        Debug.Log(transform.position);
    }
}
