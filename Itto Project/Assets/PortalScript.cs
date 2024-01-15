using UnityEngine;

public class PortalScript : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("Player").transform.position = this.gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (this.gameObject.name == "Portal_Garden")
            {
                SceneController.instance.NextScene("Store");
            }
            else if (this.gameObject.name == "Portal_Store")
            {
                SceneController.instance.NextScene("Garden");
            }
        }
    }
}
