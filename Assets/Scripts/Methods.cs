using UnityEngine;

public class Methods : MonoBehaviour
{
    Vector3 first;
    Vector3 second;
    Vector3 shorthand;
    int numberOfCars = 10;
    bool update = true;
    public Rigidbody child;
    public float speed = 2f;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    void Start()
    {
        //first = new Vector3(1, 1, 1);
        //second = new Vector3(1, 1, 1);
        //shorthand = Vector3.back;
        //Debug.Log(first.Equals(second));
        //Debug.Log(shorthand);
        //Debug.Log(first[1]);
        //Debug.Log($"subtract: {shorthand - first}");
        //Debug.Log($"multipyly: {first * 2}");
        //Debug.Log(Vector3.Normalize(first));
        Debug.Log(child.transform.position);
        bool isChild = child.transform.IsChildOf(transform);
        Debug.Log(isChild);
    }

    // Update is called once per frame
    void Update()
    {
        //if(numberOfCars < 200 && update)
        //{
        //    numberOfCars = numberOfCars + 10;
        //    Debug.Log(numberOfCars);
        //} else
        //{
        //    if(update) Debug.Log($"Max number of cars reached: {numberOfCars}");
        //    update = false;
            
        //}
    }

    void FixedUpdate()
    {
        child.AddForce(forwardForce * Time.deltaTime, 0, 0);

        if (Input.GetKey("d"))
        {
            //ForceMode.VelocityChange ignores the object's mass
            child.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            child.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
