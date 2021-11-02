using UnityEngine;
public class Coin : MonoBehaviour, IBaseCoin
{
    public delegate void CoinCount();
    public static event CoinCount coinIncrease;

    public void HandleCollision()
    {
        Increase();
        Destroy(gameObject);
    }

    public void Increase()
    {
        coinIncrease?.Invoke();
    }
}
