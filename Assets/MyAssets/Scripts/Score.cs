using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI superjumpsText;
    [SerializeField] PlayerCollision playerCollision;

    // Update is called once per frame
    void Update()
    {
        coinsText.text = playerCollision.coins.ToString();
        superjumpsText.text = playerCollision.superJumpsRemaining.ToString();
    }
}
