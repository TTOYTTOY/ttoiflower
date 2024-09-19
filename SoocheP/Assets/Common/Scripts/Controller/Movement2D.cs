using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Color;

public class Movement2D : MonoBehaviour
{
    public string currentSceneName;
    public GameManager manager;
    SpriteRenderer spriter;
    Animator anim;


    private float moveSpeed = 50f;    
    
    private float x;
    private float y;
             // �̵� �ӵ�

    private GameObject scanObject; //상호작용 오브젝트 스캔
    
    private Rigidbody2D rigid2D;
    private static Movement2D s_Instance = null;

    private Vector3 moveDirection = Vector3.zero;   // �̵� ����
    

  
     

   

    
  
    
    

   
 

    // dont destroy on load.


    
   

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

        //상호작용
         scanObject = GetComponent<GameObject>();
        //캐릭터 시선
        spriter = GetComponent<SpriteRenderer>();
        //캐릭터 애니메이션 
        anim = GetComponent<Animator>();
    }

    // TODO : export different Script
    private void Update()
    {   
         
        //manager.isAction ? 0 :  = 대화창 출력시에 움직임 제한 
        x = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");   // �¿� �̵�
        y = manager.isAction ? 0 : Input.GetAxisRaw ("Vertical");    // ���� �̵�

     

        // �̵� ���� ����
        // moveDirection = new Vector3(x, y, 0);

        // ���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

      
        //캐릭터 방향

          if (y == 1){
                moveDirection = Vector3.up;
                moveSpeed = 5f;
            }else if (x == 1){
                moveDirection = Vector3.right;
                spriter.flipX = true;
               moveSpeed = 5f;
            }else if (y == -1){
                moveDirection = Vector3.down;
                 moveSpeed = 5f;
            }else if (x == -1){
                moveDirection = Vector3.left;
                spriter.flipX = false ;
               moveSpeed = 5f;
            }else 
             moveSpeed = 0f;

                  //스페이스바 누를경우 오브젝트 스캔
         if(Input.GetButtonDown("Jump") && scanObject != null)

         manager.Action(scanObject);


                

    }

    //상호작용부분
    private void FixedUpdate()
    {
        
      
         Debug.DrawRay (rigid2D.position ,moveDirection * 50f, new Color(0,1,0) );
         RaycastHit2D rayHit = Physics2D.Raycast (rigid2D.position,moveDirection,50f,LayerMask.GetMask("Object"));
       
   

         if(rayHit.collider != null){
                     scanObject = rayHit.collider.gameObject;
                 }else 
                    scanObject = null;

    }

    private void LateUpdate()
    {
       
        anim.SetFloat("moveSpeed",moveSpeed);
         

    }

}



  



