using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환용

public class MainMenu : MonoBehaviour
{
    [Header("설정창 UI")]
    public GameObject settingsPanel; // 설정창(Panel) 오브젝트 연결용

    // 1. Play 버튼: 다음 씬으로 이동
    public void PlayGame()
    {
        // Build Settings에 등록한 게임 씬의 인덱스 번호(1) 또는 이름("GameScene")
        SceneManager.LoadScene(1);
    }

    // 2. Settings 버튼: 설정창 켜기
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true); // 설정창 활성화
        }
    }

    // 2-1. Settings 닫기 버튼 (설정창 안에 만들 버튼용)
    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false); // 설정창 비활성화
        }
    }

    // 3. Quit 버튼: 게임 종료
    public void QuitGame()
    {
        Debug.Log("게임 종료!"); // 에디터에서는 꺼지지 않으므로 로그로 확인
        Application.Quit();     // 실제 빌드된 게임에서 작동
    }
}