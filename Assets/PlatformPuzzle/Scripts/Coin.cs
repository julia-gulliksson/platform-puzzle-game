using UnityEngine;
public class Coin : MonoBehaviour, IBaseCoin
{
    public void HandleCollision()
    {
        GameEventsManager.current.CoinCollected();
        Destroy(gameObject);
    }
}
