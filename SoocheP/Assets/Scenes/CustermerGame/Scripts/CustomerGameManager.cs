using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomerGameManager : MonoBehaviour
{
    public GameObject[] customerPrefabs;
    public Transform customerSpawnPoint;
    public TMP_Text timerText;
    public TMP_InputField flowerInput;
    public TMP_InputField wrapInput;
    public TMP_InputField ribbonInput;
    public Image selectedFlowerImage;
    public Image selectedWrapImage;
    public Image selectedRibbonImage;
    public TMP_Text resultText;
    public GameObject bouquetPrefab; // 최종 꽃다발 프리팹

    public Sprite[] flowerSprites;  // 꽃 이미지 배열 (1, 2, 3)
    public Sprite[] wrapSprites;    // 포장지 이미지 배열 (1, 2, 3)
    public Sprite[] ribbonSprites;  // 리본 이미지 배열 (1, 2, 3)

    private GameObject currentCustomer;
    private bool isGameActive = false;

    void Start()
    {
        StartRound();
    }

    void StartRound()
    {
        isGameActive = true;
        StartCoroutine(RoundTimer());
        SpawnCustomer();
    }

IEnumerator RoundTimer()
{
    float timeLeft = 60f; // 제한시간 60초
    while (timeLeft > 0)
    {
        int seconds = Mathf.CeilToInt(timeLeft);  // float → int 변환
        timerText.text = seconds.ToString("D2");  // 정수형에서만 "D2" 사용 가능
        timeLeft -= Time.deltaTime;
        yield return null;
    }
    isGameActive = false;
    timerText.text = "00";
}

   void SpawnCustomer()
{
    if (!isGameActive) return;

    if (currentCustomer != null)
    {
        Destroy(currentCustomer);
    }

    int randomIndex = Random.Range(0, customerPrefabs.Length);
    currentCustomer = Instantiate(customerPrefabs[randomIndex], customerSpawnPoint.position, Quaternion.identity);

    // ✅ 새 손님이 오면 꽃다발 이미지를 다시 숨김
    selectedFlowerImage.gameObject.SetActive(false);
    selectedWrapImage.gameObject.SetActive(false);
    selectedRibbonImage.gameObject.SetActive(false);

    resultText.text = "꽃다발을 만들어주세요!";
}

    public void MakeBouquet()
{
    int flowerIndex, wrapIndex, ribbonIndex;

    // 입력값 검증 및 숫자 변환
    if (!int.TryParse(flowerInput.text, out flowerIndex) || 
        !int.TryParse(wrapInput.text, out wrapIndex) || 
        !int.TryParse(ribbonInput.text, out ribbonIndex))
    {
        resultText.text = "숫자를 정확히 입력하세요!";
        Debug.LogError("❌ 숫자 입력이 잘못되었습니다!");
        return;
    }

    // 입력값 범위 체크 (1~3이 아닐 경우 오류 메시지)
    if (!IsValidChoice(flowerIndex) || !IsValidChoice(wrapIndex) || !IsValidChoice(ribbonIndex))
    {
        resultText.text = "1~3 사이의 숫자를 입력하세요!";
        Debug.LogError($"❌ 입력값이 1~3 범위를 벗어났습니다! 입력값: 꽃({flowerIndex}), 포장({wrapIndex}), 리본({ribbonIndex})");
        return;
    }

    // 🔴 이미지가 연결되지 않았을 경우 오류 방지
    if (selectedFlowerImage == null || selectedWrapImage == null || selectedRibbonImage == null)
    {
        Debug.LogError("❌ 선택된 이미지 (SelectedFlowerImage, SelectedWrapImage, SelectedRibbonImage)가 연결되지 않았습니다!");
        return;
    }

    // 🔴 스프라이트 배열이 null이거나 비어있는 경우 오류 방지
    if (flowerSprites == null || wrapSprites == null || ribbonSprites == null)
    {
        Debug.LogError("❌ 스프라이트 배열 (flowerSprites, wrapSprites, ribbonSprites)이 설정되지 않았습니다!");
        return;
    }

    if (flowerSprites.Length < 3 || wrapSprites.Length < 3 || ribbonSprites.Length < 3)
    {
        Debug.LogError("❌ 스프라이트 배열 크기가 부족합니다! (3개 이상 필요)");
        return;
    }

    // 🌸 선택한 이미지 설정
    selectedFlowerImage.sprite = flowerSprites[flowerIndex - 1];
    selectedWrapImage.sprite = wrapSprites[wrapIndex - 1];
    selectedRibbonImage.sprite = ribbonSprites[wrapIndex - 1];

    // ✅ 선택한 이미지 표시 (숨겨져 있던 이미지 활성화)
    selectedFlowerImage.gameObject.SetActive(true);
    selectedWrapImage.gameObject.SetActive(true);
    selectedRibbonImage.gameObject.SetActive(true);

    // ✅ 디버깅 로그 추가
    Debug.Log("🌸 꽃 선택: " + flowerSprites[flowerIndex - 1].name);
    Debug.Log("🎀 포장 선택: " + wrapSprites[wrapIndex - 1].name);
    Debug.Log("🎗 리본 선택: " + ribbonSprites[wrapIndex - 1].name);

    resultText.text = "꽃다발 완성! 🎉";
    
    // ✅ 5초 후 새로운 손님 등장 (딜레이 추가)
    Invoke("SpawnCustomer", 5f);
}

    private bool IsValidChoice(int value)
    {
        return value >= 1 && value <= 3;
    }
}
