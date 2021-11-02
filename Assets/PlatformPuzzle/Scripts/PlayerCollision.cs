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

    void OnTriggerEnter(Collider other)
    {
        BaseCoin b = other.gameObject.GetComponent<BaseCoin>();
        b?.HandleCollision(other);
    }

    void HandleSuperjumpCoinCollision(Collider coin)
    {
        Destroy(coin.gameObject);
    }

    public int GetSuperJumps()
    {
        return 0;
    }
}
