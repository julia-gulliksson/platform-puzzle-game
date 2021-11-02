using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCoin : MonoBehaviour
{
    abstract public void HandleCollision(Collider collider);
    abstract public void Increase();
    abstract public void Decrease();
}



//public class SuperJumpCoin: BaseCoin
//{
//    public delegate void SuperJumpCount(int superJumps);
//    public static event SuperJumpCount superJumpCountChange;
//    public override void HandleCollision(Collider coinCollider)
//    {
//        Destroy(coinCollider.gameObject);
//        Increase();
//        superJumpCountChange?.Invoke(superJumpCoins);
//    }

//    public override void Increase()
//    {
//        superJumpCoins++;
//    }

//    public override void Decrease()
//    {
//        superJumpCoins--;
//    }
//}

public class PlayerCollision : MonoBehaviour
{
    /**
     * This class handles player collision with coins and superjump coins
     * (Goal is to only manipulate the private properties and serve as a provider of events)
     */

    private int superJumpsRemaining = 0;
    private int coins = 0;

    void OnTriggerEnter(Collider other)
    {
        //if (LayerMask.LayerToName(other.gameObject.layer) == "Coin")
        //{
        //    HandleCoinCollision(other);
        //}
        //if (LayerMask.LayerToName(other.gameObject.layer) == "SuperJumpCoin")
        //{
        //    HandleSuperjumpCoinCollision(other);
        //}

        Debug.Log(other.gameObject.name);

        BaseCoin b = (BaseCoin)other.gameObject.GetComponent<BaseCoin>();

        if (b != null)
            b.HandleCollision(other);

    }

    void HandleSuperjumpCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
        IncreaseSuperJump();
    }

    void HandleCoinCollision(Collider coin)
    {
        //IncreaseCoins();
        Destroy(coin.gameObject);
    }

    public void DecreaseSuperJump()
    {
        superJumpsRemaining--;
        //superJumpCountChange?.Invoke(superJumpsRemaining);
    }

    public void IncreaseSuperJump()
    {
        superJumpsRemaining++;
        //superJumpCountChange?.Invoke(superJumpsRemaining);
    }

    public int GetSuperJumps()
    {
        return superJumpsRemaining;
    }
}
