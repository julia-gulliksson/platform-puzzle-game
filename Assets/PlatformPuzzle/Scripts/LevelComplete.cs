using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        // Just end the game and restart the level
        FindObjectOfType<GameManager>().EndGame();
    }
}
