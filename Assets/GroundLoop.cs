using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    public float speed = 12f;
    public float boostSpeed = 24f; // 목표로 하시는 24!
    public float resetPosX = 30f;
    public float destroyPosX = -30f;

    private void Update()
    {
        // 1. 기본 속도로 시작
        float currentSpeed = speed;

        // 2. 누르는 동안만 속도를 24로 고정 (Update 문 바로 아래에서 체크해야 함)
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // i don't know that why it doesn't work.
        {
            currentSpeed = boostSpeed; // 위 코드가 左측에 있는 "Shift"키를, 또는 D 키와 RightArrow 키를 Input 하고있는 경우, currentSpeed를 위 변수에서 선언한 boostSpeed로 바꾼다는건데 이게 왜 안됨? 다 맞는거아님?
            // 확인용 로그 (이제 매 프레임 찍힐 겁니다)
            // Debug.Log("부스트 가속 중! 현재 속도: " + currentSpeed);
        }

        // 3. 이동
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        // 4. 루프 리셋 (이건 이전과 동일)
        if (transform.position.x <= destroyPosX)
        {
            float offset = transform.position.x - destroyPosX;
            transform.position = new Vector2(resetPosX + offset, transform.position.y);
        }
    }
}