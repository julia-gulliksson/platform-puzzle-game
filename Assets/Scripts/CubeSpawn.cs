using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    Rigidbody rb;
    bool destroyed = false;
    Vector3 initialPosition;
    public Transform prefab;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);

    }

    void FixedUpdate()
    {
        if(transform.position.y < -1f && !destroyed)
        {
            DestroyCube();
            destroyed = true;
        }
    }

    void DestroyCube()
    {
        Instantiate(prefab, initialPosition, Quaternion.identity);

        Destroy(gameObject);
        Debug.Log("Destroyed");
    }
}
