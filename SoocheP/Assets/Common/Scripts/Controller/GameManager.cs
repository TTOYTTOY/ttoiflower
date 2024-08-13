using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
   public conver convermanager;
    public GameObject talkPanel;

    public Equipment equipment;

   
   
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public int Converindex;


   private static GameManager g_Instance = null;

   private void Awake ()
   {
       SL_Manager slManager = GameObject.FindObjectOfType<SL_Manager>();

      if (g_Instance)
      {
         DestroyImmediate(this.gameObject);
         return;
      }
         g_Instance = this ;
         DontDestroyOnLoad(this.gameObject);
         
        

           float f = slManager.LoadFloat("9993");
           int i = slManager.LoadInt("9992");
           string s = slManager.LoadString("9991");
          
         Debug.Log(f);
         Debug.Log(i);
         Debug.Log(s);
   }

    public void Action(GameObject scanObj)
    {

      





     
     if (isAction){
        isAction = false;
     }
     else{
            isAction = true;
            scanObject = scanObj;
            ObjectManager objDate = scanObject.GetComponent<ObjectManager>();
            
            



            
           Conver (objDate.id,objDate.isNpc);
            
     }


        talkPanel.SetActive(isAction);



    }

    //대화 스크립트 불러오기
    // 여기서 미니게임으로 진행

    void Conver(int id,bool isNpc)
    {
         SL_Manager slManager = GameObject.FindObjectOfType<SL_Manager>();
       string condate = convermanager.getConver (id,Converindex);
         string name = id.ToString();
         
        if(id == 9993){
           slManager.SaveFloat(name,1);
         }else if (id == 9992){
               slManager.SaveInt(name,1);
         }else if (id == 9991){
            slManager.SaveString(name,"일");
         }

      

         if(isNpc){


            talkText.text = condate;


            
        }else 

            talkText.text = condate;

            


      
     
    }
}