using UnityEngine;  // Unity 엔진을 사용하기 위해 필요
using UnityEngine.SceneManagement;  // 씬 전환을 위해 필요

public class MainMenu : MonoBehaviour
{
    // 더블탭 모드 시작 버튼
    public void StartDoubleTapMode()
    {
        SceneManager.LoadScene("DoubleTapMode"); // "DoubleTapMode" 씬으로 이동
    }

    // 랜덤 타겟 모드 시작 버튼
    public void StartRandomTargetMode()
    {
        SceneManager.LoadScene("RandomTargetMode"); // "RandomTargetMode" 씬으로 이동
    }

    // 타겟 반응 모드 시작 버튼
    public void StartTargetReactionMode()
    {
        SceneManager.LoadScene("TargetReactionMode"); // "TargetReactionMode" 씬으로 이동
    }
}