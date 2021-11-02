using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : BaseCoin
{
    public delegate void CoinCount(int coins);
    public static event CoinCount coinCountChange;
    private int coins = 0;
    public override void HandleCollision(Collider coinCollider)
    {
        Debug.Log("Collided");
        //Destroy(coinCollider.gameObject);
        //coins++;
        //coinCountChange?.Invoke(coins);
    }

    public override void Increase()
    {
        coins++;
    }

    public override void Decrease()
    {
        coins--;
    }
}
