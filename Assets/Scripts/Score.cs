using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text yellowCoinsText;
    public PlayerCollision playerCollision;


    // Update is called once per frame
    void Update()
    {
        yellowCoinsText.text = playerCollision.superJumpsRemaining.ToString();
    }
}
