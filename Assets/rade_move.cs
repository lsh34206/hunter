using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using Random = UnityEngine.Random;
public class rade_move : MonoBehaviour
{
      private float speed=1f;

     
void Start(){

}
    public void barctrl(){
        
    
     



    if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"){
    GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_obj.SetActive(true);
    }else if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="일반"){
           GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_obj.SetActive(false);
    }
       BigInteger myhp100_rade =GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val / 100;
          float mybarfill_rade = 0;
   for(BigInteger i = 0;i < GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val;i+= myhp100_rade){
mybarfill_rade+= 0.01f;
}
   GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_bar.fillAmount =mybarfill_rade;
   GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_text.text=(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val)+"/"+GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val.ToString();




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

GameObject.Find("all_canv").GetComponent<InGame>().txtload();
GameObject.Find("all_canv").GetComponent<InGame>().mode="일반";
GameObject.Find("all_canv").GetComponent<InGame>().stage=0;
GameObject.Find("all_canv").GetComponent<InGame>().stage_fan();

    }

    }
 void OnCollisionEnter2D(Collision2D col){
            
       GameObject.Find("all_canv").GetComponent<InGame>().at_sound_play();
    if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"){
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
    

        
          
}
       

           

 
         
      
    
    


