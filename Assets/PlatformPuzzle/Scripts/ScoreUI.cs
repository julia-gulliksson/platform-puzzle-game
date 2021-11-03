using UnityEngine;
using TMPro;
using System;
public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsScore;
    [SerializeField] TextMeshProUGUI superJumpsScore;
    [SerializeField] ScoreManager scoreManager;

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

        GameEventsManager.current.onSuperJumpCoinsUpdate += UpdateSuperJumpText;
        GameEventsManager.current.onCoinsUpdate += UpdateCoinText;
    }

    private void OnDestroy()
    {
        GameEventsManager.current.onSuperJumpCoinsUpdate -= UpdateSuperJumpText;
        GameEventsManager.current.onCoinsUpdate += UpdateCoinText;
    }

    void AnimateCoins(Animator[] animators)
    {
        foreach (Animator animator in animators)
        {
            animator.SetTrigger("pickedUp");
        }
    }

    void UpdateSuperJumpText()
    {
        if (Int32.Parse(superJumpsScore.text) < scoreManager.superJumpCoins)
        {
            // Only play animation if the superjump coin has been picked up, not when it's being used up (player is jumping)
            AnimateCoins(superJumpCoinAnimators);
        }
        superJumpsScore.text = scoreManager.superJumpCoins.ToString();
    }

    void UpdateCoinText()
    {
        coinsScore.text = scoreManager.coins.ToString();

        Debug.Log(scoreManager.coins + " IN UI");
        AnimateCoins(coinAnimators);
    }
}
