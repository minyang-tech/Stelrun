using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}