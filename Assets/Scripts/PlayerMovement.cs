using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 2000f;
    public float sidewaysForce = 50f;
    public Rigidbody player;
    public float jumpAmount = 5;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            player.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        player.AddForce(forwardForce * Time.deltaTime, 0, 0);
        if (Input.GetKey("d"))
        {
            //ForceMode.VelocityChange ignores the object's mass
            player.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            player.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

      
    }
}
