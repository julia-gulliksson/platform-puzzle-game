using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int superJumpsRemaining = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            HandleCoinCollision(other);
        }
    }

    void HandleCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
        superJumpsRemaining++;
    }
}
