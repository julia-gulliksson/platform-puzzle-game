using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float y = transform.position.y;
        float speed = 0.5f;
        if (y < 3)
        {
            y = y + speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0);
            return;
        }
        else if (y >= 3)
        {
            y = y - speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0);

        }

    }

    //    private void OnCollisionEnter(Collision collision)
    //    {
    //        if(collision.gameObject.layer == 6)
    //        {
    //            Debug.Log(transform.position + "Before");
    //            transform.position = new Vector3(transform.position.x, transform.position.y + 2, 0);
    //            Debug.Log(transform.position + "After");
    //        }
    //    }
}
