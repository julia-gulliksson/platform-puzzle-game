using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour, IObjectCollider
{
    public void HandleSpikeCollision()
    {
        Debug.Log("Here");
        gameObject.SetActive(false);
    }
}
