using UnityEngine;

// Ensure your file name is "GroundLoop.cs"
public class GroundLoop : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 12f;
    public float boostSpeed = 24f;

    [Header("Loop Settings")]
    // The point where the ground is completely out of the screen
    public float destroyPosX = -15f;
    // Total width to jump (Width of 1 piece * 4 pieces = 60)
    public float loopDistance = 60f;

    private void Update()
    {
        // 1. Determine move speed
        float currentSpeed = speed;

        // Boost speed if Shift, D, or RightArrow is pressed
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed = boostSpeed;
        }

        // 2. Move ground to the left
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        // 3. Check for reset (Infinite loop logic)
        if (transform.position.x <= destroyPosX)
        {
            // Calculate the gap caused by frame drop (offset)
            float offset = transform.position.x - destroyPosX;

            // Teleport to the right side seamlessly
            Vector3 nextPos = transform.position;
            nextPos.x += loopDistance + offset;
            transform.position = nextPos;
        }
    }
}