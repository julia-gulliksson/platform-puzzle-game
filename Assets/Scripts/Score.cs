using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text yellowCoinsText;
    public Player playerScript;


    // Update is called once per frame
    void Update()
    {
        yellowCoinsText.text = playerScript.superJumpsRemaining.ToString();
    }
}
