using UnityEngine;
public class Player : MonoBehaviour, IObjectCollider
{
    public void HandleCollision()
    {
        Destroy(gameObject);
    }
}
