using UnityEngine;
using TMPro;
using System;
public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsScore;
    [SerializeField] TextMeshProUGUI superJumpsScore;

    //Animators
    [SerializeField] Animator superJumpsTextAnimator;
    [SerializeField] Animator coinsTextAnimator;
    Animator coinsScoreAnimator;
    Animator superJumpsScoreAnimator;

    private void Start()
    {
        coinsScoreAnimator = coinsScore.GetComponent<Animator>();
        superJumpsScoreAnimator = superJumpsScore.GetComponent<Animator>();
    }
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
        if (Int32.Parse(superJumpsScore.text) < superJumps)
        {
            // Only play animation if the superjump coin has been picked up, not when it's used up
            superJumpsScoreAnimator.SetTrigger("pickedUp");
            superJumpsTextAnimator.SetTrigger("pickedUp");
        }
        superJumpsScore.text = superJumps.ToString();
    }

    void UpdateCoinText(int coins)
    {
        coinsScore.text = coins.ToString();
        coinsScoreAnimator.SetTrigger("pickedUp");
        coinsTextAnimator.SetTrigger("pickedUp");
    }
}
