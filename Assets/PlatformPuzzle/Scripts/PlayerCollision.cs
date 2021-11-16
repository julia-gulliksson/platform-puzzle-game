using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour, IDestroyable
{
    void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.gameObject.GetComponent<ICollectible>();
        collectible?.HandleCollect();
    }

    public void HandleSpikeCollision()
    {
        gameObject.SetActive(false);
        FindObjectOfType<PlayerCollisionHandler>().EndGame();
    }
}
