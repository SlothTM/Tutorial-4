using UnityEngine;
using TMPro; // Change to TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Use TextMeshPro instead of UI Text
    private int score;
    private bool gameIsActive = true;

    void Update()
    {
        if (gameIsActive)
        {
            // Score remains fixed (e.g., score = 10)
            score = 10; // Fixed score value for testing
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void StopScore()
    {
        gameIsActive = false;
        scoreText.text = "Westminster: " + score.ToString(); // Keep showing the last score
    }
}
