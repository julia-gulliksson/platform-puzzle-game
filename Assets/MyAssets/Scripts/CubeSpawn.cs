using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    bool destroyed = false;
    Vector3 initialPosition;
    public Transform prefab;
    [SerializeField] float heightOffset = 0.7f;
    void Start()
    {
        // Save the initial position of the cube
        initialPosition = new Vector3(transform.position.x, transform.position.y + heightOffset, transform.position.z);
    }

    void FixedUpdate()
    {
        float destroyPoint = 5f;
        if (transform.position.y < initialPosition.y - destroyPoint && !destroyed)
        {
            // Cube has fallen down, destroy it and respawn in same location 
            RespawnCube();
            destroyed = true;
        }
    }

    void RespawnCube()
    {
        Instantiate(prefab, initialPosition, Quaternion.identity);
        Destroy(gameObject);
    }
}
