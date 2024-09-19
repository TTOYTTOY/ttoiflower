using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

     private string nextSceneName;
     //자정구분 1 : 자정이후 0 : 이전
    int midnight  ;   
     float elapsedTime = 715.0f ;

    //float elapsedTime = 230.0f ;
  void Start ()
  {

       timerText.gameObject.SetActive(true);

      midnight = 0 ; 
  }
  
  

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
    // Debug.Log(elapsedTime);
           if (minutes == 12  ){
                elapsedTime = 0 ;
                midnight = 1 ; 
                // Debug.Log(elapsedTime);
                
                //  Debug.Log(midnight);


        
        }

            if (minutes == 4 && midnight == 1){
               

                SceneManager.LoadScene("Garden");

            }


        
        
         timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);

     

    }
}
