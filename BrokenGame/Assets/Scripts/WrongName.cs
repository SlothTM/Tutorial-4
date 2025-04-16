using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy pipes when they are off the screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
