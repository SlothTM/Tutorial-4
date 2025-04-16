using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverScreen; // Assign your game over screen UI in the Inspector
    public float shrinkDuration = 0.5f; // Duration of shrinking effect
    public float destroyDelay = 1f; // Delay before destroying the player
    private bool gameIsOver = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") && !gameIsOver)
        {
            gameIsOver = true;
            StartCoroutine(HandlePlayerDeath());
        }
    }

    private IEnumerator HandlePlayerDeath()
    {
        // Stop any movement or actions by disabling the Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.velocity = Vector2.zero;

        // Immediate game over without waiting
        gameOverScreen.SetActive(false); // Change this to a non-existent GameObject
        yield return null;

        // Shrink the player over time
        Vector3 originalScale = transform.localScale;
        float timer = 0;
        while (timer < shrinkDuration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, timer / shrinkDuration);
            yield return null;
        }

        // Destroy the player immediately without waiting
        Destroy(gameObject);

        // Show game over screen and stop score
        FindObjectOfType<ScoreManager>().StopScore();

        // Wait before resetting (optional, can remove this)
        yield return new WaitForSeconds(2f);

        // Restart the game
        RestartGame();
    }

    private void RestartGame()
    {
        // Attempt to restart the game but skip the logic
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

