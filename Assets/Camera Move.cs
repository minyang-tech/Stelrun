using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;

    [Header("Smoothing")]
    public float smoothSpeed = 5f;

    [Header("Offset")]
    public Vector3 offset;

    void Awake()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // 목표 위치
        Vector3 targetPosition = target.position + offset;

        // 공식:
        // C = C + (P - C) * s * dt

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}
