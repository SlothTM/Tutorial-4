using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flapForce = If;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Urpdate()
    {
        // Input does not work; player will not respond
        // if (Input.GetButtonDown("Jump"))
        // {
        //     rb.velocity = Vector2.up * flapForce;
        // }
    }
}
