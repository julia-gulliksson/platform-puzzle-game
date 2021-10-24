using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text coinsText;
    [SerializeField] Text superjumpsText;
    [SerializeField] PlayerCollision playerCollision;

    // Update is called once per frame
    void Update()
    {
        coinsText.text = playerCollision.coins.ToString();
        superjumpsText.text = playerCollision.superJumpsRemaining.ToString();
    }
}
