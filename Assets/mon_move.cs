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
        Destroy(gameObject, 7f);
       
    }

    public void barctrl(){
                           BigInteger myhp100 =GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val / 100;
          float mybarfill = 0;
   for(BigInteger i = 0;i < GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val;i+= myhp100){
mybarfill+= 0.01f;
}
   zuc_slider.value =mybarfill;
                  
                   if(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val <=0){
           
Destroy(gameObject);
            GameObject.Find("all_canv").GetComponent<InGame>().G += GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_G;
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val = GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val;

            if (Random.Range(1, 101) < 4)
            {
                GameObject.Find("all_canv").GetComponent<InGame>().dia += GameObject.Find("all_canv").GetComponent<InGame>().dia_drop_lv_eff;
            }



            if (Random.Range(1, 101) < GameObject.Find("all_canv").GetComponent<InGame>().jackpot_hwac_lv)
            {
                GameObject.Find("all_canv").GetComponent<InGame>().G += GameObject.Find("all_canv").GetComponent<InGame>().zuc_drop_G * GameObject.Find("all_canv").GetComponent<InGame>().jackpot_lv_eff;
            }

          


            GameObject.Find("all_canv").GetComponent<InGame>().txtload();
                   }
              
    }
    

           void OnCollisionEnter2D(Collision2D col){
        if (Random.Range(1, 101) < GameObject.Find("all_canv").GetComponent<InGame>().crihwac_lv_eff)
        {
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val -= GameObject.Find("all_canv").GetComponent<InGame>().my_at_val + GameObject.Find("all_canv").GetComponent<InGame>().my_at_val / 100 * GameObject.Find("all_canv").GetComponent<InGame>().cridem_lv_eff;
        }
        else
        {
            GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val -= GameObject.Find("all_canv").GetComponent<InGame>().my_at_val;
        }
     

           barctrl();
          

       



 
         
    }  
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("all_canv").GetComponent<InGame>().stage == 1)
        {
            speed = 0.5f;
        }
        else if(GameObject.Find("all_canv").GetComponent<InGame>().stage == 2)
        {
            speed = 0.5f;
        }
        transform.Translate(new Vector3(speed, 0, 0));
    }
}
