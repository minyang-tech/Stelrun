using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7f;
    public float jumpForce = 12f;

    [Header("Slide")]
    public float slideScaleY = 0.5f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Collider2D[] ownColliders;
    private bool isGrounded;
    private bool isSliding;

    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ownColliders = GetComponentsInChildren<Collider2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (rb == null)
        {
            return;
        }

        // 좌우 이동
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveInput = -1f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveInput = 1f;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // 바닥 체크
        isGrounded = CheckGrounded();

        // 점프
        if (
            isGrounded &&
            (
                Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.UpArrow)
            )
        )
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // 슬라이딩
        bool slideKey =
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow);

        if (slideKey && !isSliding)
        {
            isSliding = true;

            transform.localScale = new Vector3(
                originalScale.x,
                originalScale.y * slideScaleY,
                originalScale.z
            );
        }
        else if (!slideKey && isSliding)
        {
            isSliding = false;
            transform.localScale = originalScale;
        }
    }

    private bool CheckGrounded()
    {
        Vector2 checkPosition = groundCheck != null
            ? groundCheck.position
            : transform.position;

        Collider2D[] hits = Physics2D.OverlapCircleAll(checkPosition, groundRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit == null || IsOwnCollider(hit))
            {
                continue;
            }

            bool matchesLayer = groundLayer.value != 0 &&
                (groundLayer.value & (1 << hit.gameObject.layer)) != 0;

            if (matchesLayer || hit.CompareTag("Ground"))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsOwnCollider(Collider2D collider)
    {
        foreach (Collider2D ownCollider in ownColliders)
        {
            if (collider == ownCollider)
            {
                return true;
            }
        }

        return false;
    }
}
