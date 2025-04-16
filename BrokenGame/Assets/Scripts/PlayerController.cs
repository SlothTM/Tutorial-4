using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    private float rotationSpeed = 90f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up * flapForce;
        }

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

}