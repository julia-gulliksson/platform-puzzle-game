using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /**
     * This class handles player collision with coins and superjump coins
     * (Goal is to only manipulate the private properties and serve as a provider of events)
     */
    public delegate void SuperJumpCount(int superJumps);
    public static event SuperJumpCount superJumpCountChange;

    public delegate void CoinCount(int coins);
    public static event CoinCount coinCountChange;

    private int superJumpsRemaining = 0;
    private int coins = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            HandleCoinCollision(other);
        }
        if (other.gameObject.layer == 12)
        {
            HandleSuperjumpCoinCollision(other);
        }
    }

    void HandleSuperjumpCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
        IncreaseSuperJump();
    }

    void HandleCoinCollision(Collider coin)
    {
        IncreaseCoins();
        Destroy(coin.gameObject);
    }

    void IncreaseCoins()
    {
        coins++;
        coinCountChange?.Invoke(coins);
    }

    public void DecreaseSuperJump()
    {
        superJumpsRemaining--;
        superJumpCountChange?.Invoke(superJumpsRemaining);
    }

    public void IncreaseSuperJump()
    {
        superJumpsRemaining++;
        superJumpCountChange?.Invoke(superJumpsRemaining);
    }

    public int GetSuperJumps()
    {
        return superJumpsRemaining;
    }
}
