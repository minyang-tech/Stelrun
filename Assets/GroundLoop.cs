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
            // 현재 위치에서 30(바닥 두 개 길이)만큼만 딱 더해줌!
            transform.position = new Vector2(transform.position.x + 30f, transform.position.y);
        }
    }
}