using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    bool atTop = false;
    bool atBottom = true;
    float topPosition;
    float bottomPosition;
    // Field to set how high the object should travel
    [SerializeField] float travelAmount;
    void Start()
    {
        // Initial position
        bottomPosition = transform.position.y;
        topPosition = bottomPosition + travelAmount;
    }

    void FixedUpdate()
    {
        if(travelAmount <= 0)
        {
            return;
        }
        float y = transform.position.y;
        float speed = 0.5f;
    
        if (y <= bottomPosition)
        {
            atBottom = true;
            atTop = false;
        } else if (y >= topPosition)
        {
            atTop = true;
            atBottom = false;
        }

        if (atBottom)
        {
            y = y + speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0);
        } else if (atTop)
        {
            y = y - speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, y, 0);
        }
    }
}
