using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_start : MonoBehaviour
{
    // Start is called before the first frame update
   public string SceneToLoad;
  void Update()
    {

        
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneToLoad);
        }

    }
}
