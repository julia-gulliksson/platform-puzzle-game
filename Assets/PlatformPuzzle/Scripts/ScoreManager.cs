using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int superJumpCoins = 0;
    public int coins = 0;

    private void OnEnable()
    {
        GameEventsManager.current.onSuperJumpCoinCollected += IncreaseSuperJumps;
        GameEventsManager.current.onCoinCollected += IncreaseCoins;
    }

    private void OnDisable()
    {
        GameEventsManager.current.onSuperJumpCoinCollected -= IncreaseSuperJumps;
        GameEventsManager.current.onCoinCollected -= IncreaseCoins;
    }

    void IncreaseSuperJumps()
    {
        superJumpCoins++;
        GameEventsManager.current.SuperJumpCoinsUpdated();
    }

    public void DecreaseSuperJumps()
    {
        superJumpCoins--;
        GameEventsManager.current.SuperJumpCoinsUpdated();
    }

    void IncreaseCoins()
    {
        coins++;
        GameEventsManager.current.CoinsUpdated();
    }
}
