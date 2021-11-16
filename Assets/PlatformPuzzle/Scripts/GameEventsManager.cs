using UnityEngine;
using System;
using System.Collections.Generic;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager current;

    public event Action onSuperJumpCoinCollected;

    public event Action onSuperJumpCoinsUpdate;

    public event Action onSuperJumpUsed;

    public event Action onCoinCollected;

    public event Action onCoinsUpdate;

    public event Action onObjectPickedUp;

    public event Action<bool, int> onPlatformTriggered;

    public event Action onGameOver;

    void Awake()
    {
        current = this;
    }

    public void SuperJumpCoinCollected()
    {
        onSuperJumpCoinCollected?.Invoke();
    }

    public void SuperJumpCoinsUpdated()
    {
        onSuperJumpCoinsUpdate?.Invoke();
    }

    public void SuperJumpUsed()
    {
        onSuperJumpUsed?.Invoke();
    }

    public void CoinCollected()
    {
        onCoinCollected?.Invoke();
    }

    public void CoinsUpdated()
    {
        onCoinsUpdate?.Invoke();
    }

    public void PickedUpObject()
    {
        onObjectPickedUp?.Invoke();
    }

    public void PlatformTriggered(bool entered, int id)
    {
        onPlatformTriggered?.Invoke(entered, id);
    }

    public void GameOver()
    {
        onGameOver?.Invoke();
    }
}
