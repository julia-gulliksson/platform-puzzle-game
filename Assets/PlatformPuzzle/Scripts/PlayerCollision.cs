using UnityEngine;

public class PlayerCollision : MonoBehaviour, IObjectCollider
{
    void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.gameObject.GetComponent<ICollectible>();
        collectible?.HandleCollect();
    }

    public void HandleSpikeCollision()
    {
        gameObject.SetActive(false);
    }
}
