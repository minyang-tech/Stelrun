using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public float jumpForce = 30f; // 점프 힘 (조금 키웠습니다)

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // 중요: 캐릭터가 회전해서 넘어지지 않게 고정
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        // Space 키를 누르고 + 바닥일 때만 점프!
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 기존 속도를 0으로 초기화하고 점프해야 힘이 일정하게 전달됩니다.
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            isGrounded = false; // 점프하는 순간 공중 상태로 변경
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥 태그를 가진 오브젝트와 충돌하면 점프 가능 상태로
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}