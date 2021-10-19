using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    bool destroyed = false;
    Vector3 initialPosition;
    public Transform prefab;
    [SerializeField] float heightOffset = 0.7f;
    void Start()
    {
        // Set the initial position of the cube
        initialPosition = new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z);
    }

    void FixedUpdate()
    {
        if(transform.position.y < -1f && !destroyed)
        {
            //Cube has fallen down, destroy it and respawn in same location 
            RespawnCube();
            destroyed = true;
        }
    }

    void RespawnCube()
    {
        Instantiate(prefab, initialPosition, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }
}
