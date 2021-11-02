using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        IBaseCoin baseCoin = other.gameObject.GetComponent<IBaseCoin>();
        baseCoin?.HandleCollision();
    }

    public int GetSuperJumps()
    {
        return 0;
    }
}
