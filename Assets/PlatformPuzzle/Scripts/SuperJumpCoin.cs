using UnityEngine;
public class SuperJumpCoin : MonoBehaviour, IBaseCoin
{
    public delegate void SuperJumpCoinCount();
    public static event SuperJumpCoinCount coinIncrease;

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
