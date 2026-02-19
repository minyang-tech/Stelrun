using UnityEngine;

public class loop : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 12f;
    public float boost = 2f;

    [Header("Loop Settings")]
    public float destroyPosX  = -60f;
    public float loopDistance = 60f;

    private PlayerRun player;

    private void Start()
    {
        player = Object.FindFirstObjectByType<PlayerRun>();
    }

    private void Update()
    {
        float currentSpeed = speed;

        if (player != null && !player.isGrounded)
        {
            currentSpeed *= boost;
        }

        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (transform.position.x <= destroyPosX)
        {
            transform.position = new Vector3(transform.position.x + loopDistance, transform.position.y, transform.position.z);
        }
    }
}