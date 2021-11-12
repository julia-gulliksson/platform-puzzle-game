using UnityEngine;
public class Coin : MonoBehaviour, ICollectible
{
    public void HandleCollect()
    {
        GameEventsManager.current.CoinCollected();
        AudioManager.current.Play("PickedCoin");
        Destroy(gameObject);
    }
}
