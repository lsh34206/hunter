using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;
using System.Numerics;
   using Random = UnityEngine.Random;
using System.Text.RegularExpressions;
using Vector3 = UnityEngine.Vector3;
 [System.Serializable]
public class data{
    public string G;
public int dia;
public int at_lv;
public int hp_lv;
public int speed_lv;
public int sazung_lv;


}
public class InGame : MonoBehaviour
{

        public BigInteger G;
public int dia;
public int at_lv;
public int hp_lv;
public int speed_lv;
public int sazung_lv;
   data datavar = new data();
public Text G_t;
public Text dia_t;
public int bul_speed=1;
public int mon_speed=1;

       public BigInteger my_at_val;
              public BigInteger zuc_at_val;
                      public BigInteger my_hp_val;
              public BigInteger zuc_hp_val;
                public BigInteger my_hhp_val;
              public BigInteger zuc_hhp_val;

           
            
                          
                             
    // Start is called before the first frame update
void Awake(){
    my_hp_val=100;
             my_hhp_val=100;
               zuc_hp_val=100;
             zuc_hhp_val=100;
                my_at_val=15;
}
    void Start()
    {
    Load();
        txtload();
      // barctrl();
       my_hp_val=100;
             my_hhp_val=100;
               zuc_hp_val=100;
             zuc_hhp_val=100;
                my_at_val=15;
    }
  
    // Update is called once per frame
    void Update()
    {

    }
      
    public void txtload(){
        G_t.text=G.ToString();
           dia_t.text=dia.ToString();
           my_at_val=15;
           if(hp_lv==1){
            my_hp_val=100;
             my_hhp_val=100;
               zuc_hp_val=100;
             zuc_hhp_val=100;
           }


          
    }
       public void Load(){
      
   string path = Application.persistentDataPath + "/data.Json";
if(File.Exists(path)){
    string json = File.ReadAllText(path);
 data datavar = JsonUtility.FromJson<data>(json);
     

      
    
            G = BigInteger.Parse(datavar.G); 
                 

dia=datavar.dia;
at_lv=datavar.at_lv;
hp_lv=datavar.hp_lv;
speed_lv=datavar.speed_lv;
sazung_lv=datavar.sazung_lv;
}else{
G=0;
dia=0;
at_lv=1;
speed_lv=1;
sazung_lv=1;
hp_lv=1;
    return;
}

}

 public void Save(){
        
      
        datavar.G = G.ToString();
                
datavar.dia=dia;
datavar.at_lv=at_lv;
datavar.speed_lv=speed_lv;
datavar.sazung_lv=sazung_lv;
datavar.hp_lv=hp_lv;


        string json = JsonUtility.ToJson(datavar);
        Debug.Log(json);
        string path = Application.persistentDataPath + "/data.Json";
        File.WriteAllText(path,json);
    }

    void OnApplicationPause(bool pauseStatus){
    if(pauseStatus){
        Save();
    }
}

void OnApplicationQuit(){

Save();
}
}
