using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    // Start is called before the first frame update

    bool atTop = false;
    bool atBottom = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float y = transform.position.y;
        float speed = 0.5f;
        float topPosition = 3;
        float bottomPosition = 1.19f;
        if(y <= bottomPosition)
        {
            atBottom = true;
            atTop = false;
        }
        if(y >= topPosition)
        {
            atTop = true;
            atBottom = false;
        }
        if (atBottom)
        {
            y = y + speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0);
        }
        if (atTop)
        {
            y = y - speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0);
        }

    }

 
}
