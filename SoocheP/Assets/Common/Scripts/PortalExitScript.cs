using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitScript : MonoBehaviour
{
    public string sceneName;
    private Movement2D player;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
            player = FindObjectOfType<Movement2D>();

        if(sceneName == player.currentSceneName)
        {
            player.transform.position = transform.position;
        }
    }
}
