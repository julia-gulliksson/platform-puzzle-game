using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int superJumpCoins = 0;
    public int coins = 0;

    private void Start()
    {
        GameEventsManager.current.onSuperJumpCoinCollected += IncreaseSuperJumps;
        GameEventsManager.current.onCoinCollected += IncreaseCoins;
        GameEventsManager.current.onSuperJumpUsed += DecreaseSuperJumps;
    }

    private void OnDestroy()
    {
        GameEventsManager.current.onSuperJumpCoinCollected -= IncreaseSuperJumps;
        GameEventsManager.current.onCoinCollected -= IncreaseCoins;
        GameEventsManager.current.onSuperJumpUsed -= DecreaseSuperJumps;
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
        Debug.Log(coins + " IN SCORE MANAGER");
        GameEventsManager.current.CoinsUpdated();
    }
}
