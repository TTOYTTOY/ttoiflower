using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_Manager : MonoBehaviour
{
    

        //게임저장
        public void SaveFloat(string Fname,float f)
        {   
            PlayerPrefs.SetFloat(Fname,f);
            PlayerPrefs.Save();
        }
        public float LoadFloat(string Fname){
             float f = PlayerPrefs.GetFloat(Fname);                   
             return f ;
        }

         public void SaveInt(string Iname,int i )
        {   
            PlayerPrefs.SetInt(Iname,i);
            PlayerPrefs.Save();
        }

        public int LoadInt(string Iname ){
            int i = PlayerPrefs.GetInt(Iname);
              
              return i ;
        }


        public void SaveString( string Sname,string s)
        {   
            PlayerPrefs.SetString(Sname,s);
            PlayerPrefs.Save();
        }
        public string LoadString(string Sname ){
            string s = PlayerPrefs.GetString(Sname);
              return s;
        }







            //게임불러오기
               public void GameLoad()
               {    

                  
                   

                
               }


}
