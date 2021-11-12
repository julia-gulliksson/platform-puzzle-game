using UnityEngine;
public class SuperJumpCoin : MonoBehaviour, ICollectible
{
    public void HandleCollect()
    {
        GameEventsManager.current.SuperJumpCoinCollected();
        Destroy(gameObject);
    }
}
