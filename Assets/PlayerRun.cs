using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 15f; // Recommended value with Gravity Scale 4

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Freeze Z rotation so the player doesn't roll like a ball
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        // 1. Check for Jump Input (Space OR W OR UpArrow)
        bool isJumpPressed = Input.GetKeyDown(KeyCode.Space) ||
                             Input.GetKeyDown(KeyCode.W) ||
                             Input.GetKeyDown(KeyCode.UpArrow);

        // 2. Execute Jump if on ground
        if (isJumpPressed && isGrounded)
        {
            // Reset vertical velocity for consistent jump height
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);

            // Apply jump force
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            isGrounded = false; // Player is now in the air
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player touched the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}