using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI superjumpsText;
    [SerializeField] PlayerCollision playerCollision;

    private void OnEnable()
    {
        PlayerCollision.superJumpCountChange += UpdateSuperJumpText;
        PlayerCollision.coinCountChange += UpdateCoinText;
    }

    private void OnDisable()
    {
        PlayerCollision.superJumpCountChange -= UpdateSuperJumpText;
        PlayerCollision.coinCountChange -= UpdateCoinText;
    }

    void UpdateSuperJumpText(int superJumps)
    {
        superjumpsText.text = superJumps.ToString();
    }

    void UpdateCoinText(int coins)
    {
        coinsText.text = coins.ToString();
        coinsText.GetComponent<Animator>().SetBool("pickedUp", true);
    }
}
