using UnityEngine;

public class PlayerCollision : MonoBehaviour, IObjectCollider
{
    void OnTriggerEnter(Collider other)
    {
        IBaseCoin baseCoin = other.gameObject.GetComponent<IBaseCoin>();
        baseCoin?.HandleCollision();
    }

    public void HandleSpikeCollision()
    {
        Destroy(gameObject);
    }
}
