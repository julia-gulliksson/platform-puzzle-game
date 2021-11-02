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
    Animator[] superJumpCoinAnimators;
    Animator[] coinAnimators;

    private void Start()
    {
        coinsScoreAnimator = coinsScore.GetComponent<Animator>();
        superJumpsScoreAnimator = superJumpsScore.GetComponent<Animator>();
        superJumpCoinAnimators = new Animator[] { superJumpsScoreAnimator, superJumpsTextAnimator };
        coinAnimators = new Animator[] { coinsScoreAnimator, coinsTextAnimator };
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

    void AnimateCoins(Animator[] animators)
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("pickedUp");
        }
    }

    void UpdateSuperJumpText(int superJumps)
    {
        if (Int32.Parse(superJumpsScore.text) < superJumps)
        {
            // Only play animation if the superjump coin has been picked up, not when it's being used up (player is jumping)
            AnimateCoins(superJumpCoinAnimators);
        }
        superJumpsScore.text = superJumps.ToString();
    }

    void UpdateCoinText(int coins)
    {
        coinsScore.text = coins.ToString();
        AnimateCoins(coinAnimators);
    }
}
