using UnityEngine;

public class Rock : MonoBehaviour, IDestroyable
{
    bool destroyed = false;
    [SerializeField] Vector3 initialPosition;
    [SerializeField] GameObject prefab;
    [SerializeField] float heightOffset = 0.7f;
    bool hasRespawned = false;
    float destroyPoint = 5f;

    void Update()
    {
        if (transform.position.y < initialPosition.y - destroyPoint && !destroyed)
        {
            // Cube has fallen down, destroy it and respawn in same location 
            RespawnCube();
        }
    }

    void RespawnCube()
    {
        Instantiate(prefab, new Vector3(initialPosition.x, initialPosition.y + heightOffset, initialPosition.z), Quaternion.identity);
        destroyed = true;
        Destroy(gameObject);
    }

    public void HandleSpikeCollision()
    {
        gameObject.SetActive(false);
        if (!hasRespawned)
        {
            Debug.Log("Hallå");
            hasRespawned = true;
            GameObject clone = Instantiate(prefab, new Vector3(initialPosition.x, initialPosition.y + heightOffset, initialPosition.z), Quaternion.identity);
            clone.SetActive(true);
        }
    }
}
