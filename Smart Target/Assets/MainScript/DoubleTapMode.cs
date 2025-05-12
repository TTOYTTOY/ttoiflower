using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoubleTapMode : MonoBehaviour
{
    public GameObject target; // 타겟 오브젝트
    public Text timerText; // 타이머 UI
    public Button restartButton; // 재시작 버튼
    public AudioSource beepSound; // 신호음
    
    private float timer = 0f;
    private bool isTiming = false;
    private int hitCount = 0;
    
    void Start()
    {
        StartCoroutine(StartCountdown());
        restartButton.gameObject.SetActive(false); // 초기 상태에서 비활성화
        timerText.text = "0.00";
    }

    IEnumerator StartCountdown()
    {
        float waitTime = Random.Range(1f, 4f); // 1~4초 랜덤 대기
        yield return new WaitForSeconds(waitTime);
        
        beepSound.Play(); // 삐 소리 재생
        isTiming = true;
        timer = 0f;
    }

    void Update()
    {
        // 타이머 실행
        if (isTiming)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2"); // 소수점 2자리까지 표시
        }

        // 마우스로 타겟 클릭 감지
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Target")) // 타겟인지 확인
                {
                    HitTarget();
                }
            }
        }

        // 엔터 키로 게임 재시작
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RestartGame();
        }
    }

    public void HitTarget()
    {
        if (!isTiming) return;

        hitCount++;
        if (hitCount >= 2) // 두 번 맞추면 종료
        {
            isTiming = false;
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        hitCount = 0;
        isTiming = false;
        timer = 0f;
        timerText.text = "0.00";
        restartButton.gameObject.SetActive(false);
        StartCoroutine(StartCountdown());
    }
}
