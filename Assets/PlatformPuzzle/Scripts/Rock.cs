using UnityEngine;

public class Rock : MonoBehaviour, IDestroyable
{
    bool destroyed = false;
    Vector3 initialPosition;
    Vector3 initialScale;
    [SerializeField] float destroyPoint = 5f;
    [SerializeField] GameObject prefab;
    [SerializeField] float heightOffset = 0.7f;
    [SerializeField] ParticleSystem deathParticles;

    private void Start()
    {
        initialScale = transform.localScale;
        initialPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < initialPosition.y - destroyPoint && !destroyed)
        {
            // Cube has fallen down
            RespawnCube();
        }
    }

    void RespawnCube()
    {
        GameObject newRock = Instantiate(prefab, new Vector3(initialPosition.x, initialPosition.y + heightOffset, initialPosition.z), Quaternion.identity);
        // Fixes bug where rock respawns with kinematic set to true and wrong scale
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
