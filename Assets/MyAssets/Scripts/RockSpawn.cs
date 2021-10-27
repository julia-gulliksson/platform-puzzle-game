using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    bool destroyed = false;
    [SerializeField] Vector3 initialPosition;
    public Transform prefab;
    [SerializeField] float heightOffset = 0.7f;

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
        Instantiate(prefab, new Vector3(initialPosition.x, initialPosition.y + heightOffset, initialPosition.z), Quaternion.identity);
        Destroy(gameObject);
    }
}
