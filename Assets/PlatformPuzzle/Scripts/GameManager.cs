using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject completeLevelUI;
    bool gameHasEnded = false;
    [SerializeField] float restartDelay = 1f;
    [SerializeField] float gameOverUIDelay = 2f;

    private void OnEnable()
    {
        GameEventsManager.current.onGameOver += ShowGameOverUI;
    }

    private void OnDisable()
    {
        GameEventsManager.current.onGameOver -= ShowGameOverUI;
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void ShowGameOverWithDelay()
    {
        StartCoroutine(ShowGameOverUIAfterTime());
    }

    IEnumerator ShowGameOverUIAfterTime()
    {
        yield return new WaitForSeconds(gameOverUIDelay);

        FindObjectOfType<GameManager>().ShowGameOverUI();
    }
}
