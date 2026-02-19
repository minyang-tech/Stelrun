using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    public float speed = 12f;
    public float boostSpeed = 24f; // like spiderman
    public float resetPosX = 30f;
    public float destroyPosX = -30f;

    private void Update()
    {
        // 1. this is current speed
        float currentSpeed = speed;

        // 2. oh yesyes!!!!!
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // i don't know that why it doesn't work.
        {
            currentSpeed = boostSpeed; // wtf?
        }

        // 3. move
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        // 4. reset loop
        if (transform.position.x <= destroyPosX)
        {
            float offset = transform.position.x - destroyPosX;
            transform.position = new Vector2(resetPosX + offset, transform.position.y);
        }
    }
}