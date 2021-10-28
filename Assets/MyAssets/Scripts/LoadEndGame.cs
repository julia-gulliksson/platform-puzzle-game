using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEndGame : MonoBehaviour
{
    public void EndGame()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
