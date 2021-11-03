using UnityEngine;
using System;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager current;

    public event Action onSuperJumpCoinCollected;

    public event Action onSuperJumpCoinsUpdate;

    public event Action onCoinCollected;

    public event Action onCoinsUpdate;


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

    public void CoinCollected()
    {
        onCoinCollected?.Invoke();
    }

    public void CoinsUpdated()
    {
        onCoinsUpdate?.Invoke();
    }
}
