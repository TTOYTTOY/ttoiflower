using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 // 이동 속도
    private Vector3 moveDirection = Vector3.zero;   // 이동 방향
    private Rigidbody2D rigid2D;

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
        float x = Input.GetAxisRaw("Horizontal");   // 좌우 이동
        float y = Input.GetAxisRaw ("Vertical");    // 상하 이동

        // 이동 방향 설정
        // moveDirection = new Vector3(x, y, 0);

        // 새로운 위치 = 현재 위치 + (방향 * 속도)
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //string sceneName = null;
        //if(collision.gameObject.name == "Portal_Store")
        //{
        //    sceneName = "Garden";
        //}

        //else if(collision.gameObject.name == "Portal_Garden")
        //{
        //    sceneName = "Store";
        //}

        //string portalName = "Portal_" + sceneName;
        //this.gameObject.transform.position = GameObject.Find(portalName).gameObject.transform.position;
        //SceneController.instance.NextScene(portalName);
    }
}
