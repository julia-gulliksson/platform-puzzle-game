using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    public Vector3 offset;
    void Update()
    {
        transform.position = player.position + offset;
    }
}