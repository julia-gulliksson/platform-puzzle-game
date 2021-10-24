using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int superJumpsRemaining = 0;
    public int coins = 0;

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
        superJumpsRemaining++;
    }

    void HandleCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
        coins++;
    }
}
