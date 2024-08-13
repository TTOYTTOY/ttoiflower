using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Seen_Script : MonoBehaviour
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
