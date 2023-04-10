using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using System.Numerics;
public class mon_move : MonoBehaviour
{
      private float speed=5f;

                public Slider zuc_slider;
                
                   public GameObject mon;
                          

                public void barctrl(){
                           BigInteger myhp100 =GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val / 100;
          float mybarfill = 0;
   for(BigInteger i = 0;i < GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val;i+= myhp100){
mybarfill+= 0.01f;
}
   zuc_slider.value =mybarfill;
                  
                   if(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val <=0){
Destroy(gameObject);
GameObject.Find("all_canv").GetComponent<InGame>().G+=10;
GameObject.Find("all_canv").GetComponent<InGame>().txtload();
                   }
                }

           void OnCollisionEnter2D(Collision2D col){

        GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val -=GameObject.Find("all_canv").GetComponent<InGame>().my_at_val;
           barctrl();
          

       



 
         
    }  
    // Update is called once per frame
    void Update()
    {
       
transform.Translate(new Vector3(speed,0,0));
    }
}
