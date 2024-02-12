using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pause_panel_UI;
    private static PauseMenu pauseMenu = null;

    private void Awake()
    {
        pause_panel_UI.SetActive(false);

        if(pauseMenu)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        pauseMenu = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (!GameManager.isPause)
            {
                CallMenu();
            }
            else
                CloseMenu();
        }
    }

    private void CallMenu()
    {
        GameManager.isPause = true;
        pause_panel_UI.SetActive(true);
        Time.timeScale = 0.0f; // Ω√∞£ ∏ÿ√ﬂ±‚
    }

    private void CloseMenu()
    {
        GameManager.isPause = false;
        pause_panel_UI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
