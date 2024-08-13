using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Equipment : MonoBehaviour
{
     Movement2D movement2D;

     public GameManager manager;

     public GameObject EQui;

     public bool SelectUi = false;  //장비인벤토리 on off 

     public int CharaterEQ;
 

    void Update()
    {

     

        if (manager.isAction == false ){
             if (Input.GetKeyDown(KeyCode.Tab)){
                if (SelectUi == false){
                SelectUi = true ;
                
               
                 Debug.Log(SelectUi);

                }else if (SelectUi == true){
                    Debug.Log ("select off");
                    SelectUi = false ;
               
                     Debug.Log(SelectUi);
                     
                }

                // EQui.SetActive(SelectUi);
                
             }

             if (SelectUi == true){
                     if (Input.GetKeyDown(KeyCode.Alpha1)){
                        CharaterEQ = 9991;
                        Debug.Log(CharaterEQ);
                        SelectUi = false ;
                    }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                         CharaterEQ = 9992;
                        Debug.Log(CharaterEQ);
                        SelectUi = false ;
                    }else if (Input.GetKeyDown(KeyCode.Alpha3)){
                        CharaterEQ = 9993;
                        Debug.Log(CharaterEQ);
                        SelectUi = false ;
                    }
                }
          
                  EQui.SetActive(SelectUi);







    }


    }


      public float getCharaterEQ(){
        
      Debug.Log(this.CharaterEQ + "아니다");
        return CharaterEQ;
       
    }

}
