using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Player playerScript;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScript.superJumpsRemaining.ToString();
    }
}
