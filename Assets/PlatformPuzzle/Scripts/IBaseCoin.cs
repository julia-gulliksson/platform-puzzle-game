using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseCoin
{
    abstract public void HandleCollision();
    abstract public void Increase();
}

