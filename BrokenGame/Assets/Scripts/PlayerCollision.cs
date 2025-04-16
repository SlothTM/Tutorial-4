using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverScreen; 
    public float shrinkDuration = 0.5f; 
    public float destroyDelay = 1f; 

    [SerializeField] private bool gameIsOver = false; 

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

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.velocity = Vector2.zero;

        // Shrink the player over time
        Vector3 originalScale = transform.localScale;
        float timer = 0;
        while (timer < shrinkDuration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, timer / shrinkDuration);
            yield return null;
        }

 
        gameOverScreen.SetActive(true);
        FindObjectOfType<ScoreManager>().StopScore();

 
        yield return new WaitForSeconds(4f);

        GameManager.instance.RestartGame();

        // Destroy the player after shrinking
        Destroy(gameObject, destroyDelay);

    }

}
