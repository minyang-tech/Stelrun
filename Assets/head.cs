using UnityEngine; // 세미콜론 추가

public class LookAtMouse2D : MonoBehaviour
{
    public float rotateSpeed = 10f;

    private void Update()
    {
        // 1. 마우스 위치 계산
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        // 2. 각도 계산 (Rad -> Deg 변환)
        // Mathf.Rad2Deg를 곱해야 유니티가 알아먹는 0~360도 단위가 됩니다.
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 3. 목표 회전값 생성 (Z축 기준 회전)
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        // 4. 부드러운 회전 적용
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}