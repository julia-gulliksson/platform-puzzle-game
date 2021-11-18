using UnityEngine;

public class Rock : MonoBehaviour, IDestroyable
{
    bool destroyed = false;
    [SerializeField] Vector3 initialPosition;
    Vector3 initialScale;
    [SerializeField] GameObject prefab;
    [SerializeField] float heightOffset = 0.7f;
    float destroyPoint = 5f;
    [SerializeField] ParticleSystem deathParticles;

    private void Start()
    {
        initialScale = transform.localScale;
    }

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
        GameObject newRock = Instantiate(prefab, new Vector3(initialPosition.x, initialPosition.y + heightOffset, initialPosition.z), Quaternion.identity);
        newRock.transform.SetParent(GameObject.FindGameObjectWithTag("RockParent").transform);
        newRock.GetComponent<Rigidbody>().isKinematic = false;
        newRock.transform.localScale = initialScale;
        destroyed = true;
        Destroy(gameObject);
    }

    public void HandleSpikeCollision()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        RespawnCube();
    }
}
