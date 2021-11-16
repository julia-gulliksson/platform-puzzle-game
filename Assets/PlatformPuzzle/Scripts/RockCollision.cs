using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour, IDestroyable
{
    public void HandleSpikeCollision()
    {
        gameObject.SetActive(false);
    }
}
