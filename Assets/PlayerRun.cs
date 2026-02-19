using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 15f;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    private int maxJumps = 2;
    private int remainingJumps = 2;
    private bool jumpRequested = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded || remainingJumps > 0)
            {
                jumpRequested = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequested)
        {
            isGrounded = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            remainingJumps -= 1;
            jumpRequested = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            remainingJumps = maxJumps;
        }
    }
}