using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public delegate void CoinChange(int coins);
    public static event CoinChange coinChange;

    public delegate void SuperJumpCoinChange(int coins);
    public static event SuperJumpCoinChange superJumpCoinChange;

    public int superJumpCoins = 0;
    int coins = 0;

    private void OnEnable()
    {
        SuperJumpCoin.coinIncrease += IncreaseSuperJumps;
        Coin.coinIncrease += IncreaseCoins;
    }

    private void OnDisable()
    {
        SuperJumpCoin.coinIncrease -= IncreaseSuperJumps;
        Coin.coinIncrease -= IncreaseCoins;

    }

    void IncreaseSuperJumps()
    {
        superJumpCoins++;
        superJumpCoinChange?.Invoke(superJumpCoins);
    }

    public void DecreaseSuperJumps()
    {
        superJumpCoins--;
        superJumpCoinChange?.Invoke(superJumpCoins);
    }

    void IncreaseCoins()
    {
        coins++;
        coinChange?.Invoke(coins);
    }
}
