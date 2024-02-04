using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    private Movement2D player;
    //private bool flag = false;
    //private float x;
    private void Awake()
    {
        if (player == null)
            player = FindObjectOfType<Movement2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.currentSceneName = nextSceneName;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
