using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2D : MonoBehaviour
{
    public string currentSceneName;

    private float moveSpeed = 5.0f;                 // �̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero;   // �̵� ����
    private Rigidbody2D rigid2D;

    private float x;
    private float y;

    // dont destroy on load
    private static Movement2D s_Instance = null;

    private void Awake()
    {
        if(s_Instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        s_Instance = this;
        rigid2D = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {   
        x = Input.GetAxisRaw("Horizontal");   // �¿� �̵�
        y = Input.GetAxisRaw ("Vertical");    // ���� �̵�

        // �̵� ���� ����
        // moveDirection = new Vector3(x, y, 0);

        // ���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }
}
