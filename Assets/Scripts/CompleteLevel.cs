using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            gameManager.CompleteLevel();
        }
    }
}
