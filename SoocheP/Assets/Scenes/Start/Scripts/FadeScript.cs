using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{  
  public string SceneToLoad;
 public Image Panel;
 float time = 0f;
 float F_time = 1f;







  void Update()
    {

        
        if (Input.anyKeyDown)
        {
            StartCoroutine(FadeFlow());
        }

    }



 // public void Fade()
 //{}
 
 IEnumerator FadeFlow()
{
    Panel.gameObject.SetActive(true);
    time =0f;
    Color alpha = Panel.color;
    while (alpha.a < 1f)
    {

        time += Time.deltaTime / F_time;
        alpha.a = Mathf.Lerp(0,1,time);
        Panel.color = alpha;
        yield return null;
    }
    time =0f;

    SceneManager.LoadScene(SceneToLoad);

   /* yield return new WaitForSeconds(1f);
      while (alpha.a < 0f)
    {

        time += Time.deltaTime / F_time;
        alpha.a = Mathf.Lerp(1,0,time);
        Panel.color = alpha;
        yield return null;
    }
     Panel.gameObject.SetActive(false);
      
     */


 



    yield return null;
}





}


