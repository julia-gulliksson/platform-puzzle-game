using UnityEngine;
public class SuperJumpCoin : MonoBehaviour, IBaseCoin
{
    public void HandleCollision()
    {
        GameEventsManager.current.SuperJumpCoinCollected();
        Destroy(gameObject);
    }
}
