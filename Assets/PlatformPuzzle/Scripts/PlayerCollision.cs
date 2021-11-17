using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour, IDestroyable
{
    [SerializeField] ParticleSystem deathSplatter;
    void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.gameObject.GetComponent<ICollectible>();
        collectible?.HandleCollect();
    }

    public void HandleSpikeCollision()
    {
        gameObject.SetActive(false);
        Instantiate(deathSplatter, transform.position, Quaternion.identity);

        FindObjectOfType<GameManager>().ShowGameOverWithDelay();
    }
}
