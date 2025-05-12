using UnityEngine;

public class Customer : MonoBehaviour
{
    private CustomerGameManager gameManager;

    void Start()
    {
        Debug.Log("손님: 안녕하세요! 꽃을 사고 싶어요.");
    }

    public void SetGameManager(CustomerGameManager manager)
    {
        gameManager = manager;
    }

    // 클릭해도 손님이 바로 나가지 않도록 변경
    void OnMouseDown()
    {
        Debug.Log("손님: 꽃다발을 만들어 주세요!");
    }
}
