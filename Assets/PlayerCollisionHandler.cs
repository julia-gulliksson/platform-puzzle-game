using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] float endTime = 2f;

    public void EndGame()
    {
        StartCoroutine(EndGameAfterTime());
    }

    IEnumerator EndGameAfterTime()
    {
        yield return new WaitForSeconds(endTime);

        FindObjectOfType<GameManager>().ShowGameOverUI();
    }
}
