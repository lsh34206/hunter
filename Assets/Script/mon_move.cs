using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using Random = UnityEngine.Random;
public class mon_move : MonoBehaviour
{
      private float speed=1f;

                public Slider zuc_slider;
                
                   public GameObject mon;
    void Start()
    {
        Destroy(gameObject, 30f);
        BigInteger max = 100;
        BigInteger subxp = GameObject.Find("all_canv").GetComponent<InGame>().xp;
        GameObject.Find("all_canv").GetComponent<InGame>().lv = 1;
        for(BigInteger i=subxp;max < subxp;subxp-=max){
            GameObject.Find("all_canv").GetComponent<InGame>().lv++;
            max += (max/100);
        }




        BigInteger max100 = max / 100;
        float lvfill = 0;
        for(BigInteger i = 0;i < subxp;i += max100){
            lvfill+= 0.01f;
        }
        GameObject.Find("all_canv").GetComponent<InGame>().xp_bar.fillAmount= lvfill;
        GameObject.Find("all_canv").GetComponent<InGame>().xp_text.text=GameObject.Find("all_canv").GetComponent<InGame>().lv+"lv".ToString();




    }

    public void barctrl(){
        
    
     

if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"){
    GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_obj.SetActive(true);
       BigInteger myhp100_rade =GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val / 100;
          float mybarfill_rade = 0;
   for(BigInteger i = 0;i < GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val;i+= myhp100_rade){
mybarfill_rade+= 0.01f;
}
   GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_bar.fillAmount =mybarfill_rade;
   GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_text.text=(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val)+"/"+GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val.ToString();

}
 
                           BigInteger myhp100 =GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val / 100;
          float mybarfill = 0;
   for(BigInteger i = 0;i < GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val;i+= myhp100){
mybarfill+= 0.01f;
}
   zuc_slider.value =mybarfill;




    BigInteger max = 100;
   BigInteger subxp = GameObject.Find("all_canv").GetComponent<InGame>().xp;
  GameObject.Find("all_canv").GetComponent<InGame>().lv = 1;
  for(BigInteger i=subxp;max < subxp;subxp-=max){
    GameObject.Find("all_canv").GetComponent<InGame>().lv++;
    max += (max/100);
}




   BigInteger max100 = max / 100;
  float lvfill = 0;
   for(BigInteger i = 0;i < subxp;i += max100){
 lvfill+= 0.01f;
}
GameObject.Find("all_canv").GetComponent<InGame>().xp_bar.fillAmount= lvfill;
GameObject.Find("all_canv").GetComponent<InGame>().xp_text.text=GameObject.Find("all_canv").GetComponent<InGame>().lv+"lv".ToString();



                  
                   if(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val <=0){
                   if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"){
                    GameObject.Find("all_canv").GetComponent<InGame>().rade_time=0;
                   }
 GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val=GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val;
Destroy(gameObject);


 GameObject.Find("all_canv").GetComponent<InGame>().Save();
                   
          
GameObject.Find("all_canv").GetComponent<InGame>().xp+=GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_xp+GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_xp/100*GameObject.Find("all_canv").GetComponent<InGame>().stat_xp_lv_eff*GameObject.Find("all_canv").GetComponent<InGame>().xp_ad_eff_set;
            GameObject.Find("all_canv").GetComponent<InGame>().G += GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_G+GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_G/100*GameObject.Find("all_canv").GetComponent<InGame>().G_plus_eff*GameObject.Find("all_canv").GetComponent<InGame>().gold_ad_eff_set;
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val = GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val;
if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="일반"){
    if (Random.Range(1, 101) < 4)
            {
                GameObject.Find("all_canv").GetComponent<InGame>().dia += GameObject.Find("all_canv").GetComponent<InGame>().dia_drop_lv_eff+GameObject.Find("all_canv").GetComponent<InGame>().yeongu_get_dia_plus_eff;
            }

        
GameObject.Find("all_canv").GetComponent<InGame>().xp+=GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_xp+GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_xp/100*GameObject.Find("all_canv").GetComponent<InGame>().stat_xp_lv_eff*GameObject.Find("all_canv").GetComponent<InGame>().xp_ad_eff_set;
      

            if (Random.Range(1, 101) < GameObject.Find("all_canv").GetComponent<InGame>().jackpot_hwac_lv)
            {
                GameObject.Find("all_canv").GetComponent<InGame>().G += GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_G+GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_G/100*GameObject.Find("all_canv").GetComponent<InGame>().G_plus_eff + GameObject.Find("all_canv").GetComponent<InGame>().jackpot_lv_eff*GameObject.Find("all_canv").GetComponent<InGame>().gold_ad_eff_set;
            }

            int kill_count=0;
          for(int i =0;i<GameObject.Find("all_canv").GetComponent<InGame>().stage;i++){
            kill_count+=300;
            
 if(GameObject.Find("all_canv").GetComponent<InGame>().kill_count >= (kill_count-=300)&&GameObject.Find("all_canv").GetComponent<InGame>().kill_count < kill_count){
        
    }else{
        GameObject.Find("all_canv").GetComponent<InGame>().kill_count++;
    }

          }
}
            






barctrl();
            GameObject.Find("all_canv").GetComponent<InGame>().txtload();
                   }
                GameObject.Find("all_canv").GetComponent<InGame>().txtload();
    }
    

           void OnCollisionEnter2D(Collision2D col){
            
              GameObject.Find("all_canv").GetComponent<InGame>().at_sound_play();
              
     if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="일반"){
    if (Random.Range(1, 101) < GameObject.Find("all_canv").GetComponent<InGame>().crihwac_lv_eff)
        {
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val -= GameObject.Find("all_canv").GetComponent<InGame>().my_at_val + GameObject.Find("all_canv").GetComponent<InGame>().my_at_val / 100 * GameObject.Find("all_canv").GetComponent<InGame>().cridem_lv_eff*GameObject.Find("all_canv").GetComponent<InGame>().at_ad_eff_set;
       }
        else
        {
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val -= GameObject.Find("all_canv").GetComponent<InGame>().my_at_val*GameObject.Find("all_canv").GetComponent<InGame>().at_ad_eff_set;
            }
     }else if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"){
   if (Random.Range(1, 101) < GameObject.Find("all_canv").GetComponent<InGame>().crihwac_lv_eff)
        {
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val -= GameObject.Find("all_canv").GetComponent<InGame>().my_at_val + GameObject.Find("all_canv").GetComponent<InGame>().my_at_val / 100 * GameObject.Find("all_canv").GetComponent<InGame>().cridem_lv_eff*GameObject.Find("all_canv").GetComponent<InGame>().at_ad_eff_set;
        }
        else
        {
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val -= GameObject.Find("all_canv").GetComponent<InGame>().my_at_val*GameObject.Find("all_canv").GetComponent<InGame>().at_ad_eff_set;
        }
     }
 
   




           barctrl();
        
          

       

           

 
         
    }  
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("all_canv").GetComponent<InGame>().stage == 1)
        {
           
        }
        else if(GameObject.Find("all_canv").GetComponent<InGame>().stage == 2)
        {
           
        }

        if(GameObject.Find("all_canv").GetComponent<InGame>().stage==0){
           
        }
        speed=180;
        if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"){
            speed=18;
        }
        
        transform.Translate(new Vector3(speed, 0, 0)*Time.deltaTime);
       
    }
}

