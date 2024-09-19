using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contingency : MonoBehaviour
{

    private Countdown countdown ;
    //먼지털이 40초
    int dustevent = 40;
    //진상손님 90초
    int basterdsevent = 90;
    //손님맞이 
    int Cutermerevent = 30;
    

    float accidenttime = 0f ;
    
    int eventtiom = 0;
    void Update()
    {
        
        accidenttime += Time.deltaTime;
        eventtiom =(int)accidenttime;
      
        if (dustevent == eventtiom){

            Debug.Log(accidenttime + "먼지이벤트발생");
            dustevent += 40;

        }else if (basterdsevent == eventtiom ){
            
            Debug.Log(accidenttime + "진상고객이벤트발생");
            basterdsevent += 90;


        }else if (Cutermerevent == eventtiom){
            

            Debug.Log(accidenttime + "손님맞이");
            Cutermerevent += 30;

        }

        

    



            

    }


}
