using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conver : MonoBehaviour
{
    Movement2D movement2D;

    Equipment equipment;

    Dictionary<int, string[]> ConverDate;

    private static conver c_Instance = null;

    void Awake()
    {
          if(c_Instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        c_Instance = this;
        DontDestroyOnLoad(this.gameObject);

            ConverDate = new Dictionary<int, string[]>();
            GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        //대화 스크립트
        ConverDate.Add(1000,new string[] {"안녕"} );

        


        //꽃 관리 스크립트 
         
        //장비
        

       
         ConverDate.Add(9991,new string[] {"꽃이다"} );
        
         ConverDate.Add(10000,new string[] {"미니게임이다"} );
        


         ConverDate.Add(9992,new string[] {"벌레다"} );
         ConverDate.Add(9993,new string[] {"가지다"} );

    }

    void update ()
    {  


       

    }
    
    
    public string getConver (int id ,int Converindex )
    {
        
         return ConverDate[id][Converindex];
    }
}
