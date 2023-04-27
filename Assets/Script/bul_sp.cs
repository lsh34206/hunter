using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
public class bul_sp : MonoBehaviour
{
     public Transform balsa_pos;
    public GameObject balsa_bon_1;
     public GameObject balsa_bon_2;
        public GameObject balsa_bon_3;

           public GameObject balsa_bon_4;   
           public GameObject balsa_bon_5;
              public GameObject balsa_bon_6;

                 public GameObject balsa_bon_7;
                    public GameObject balsa_bon_8;
                       public GameObject balsa_bon_9;

                          public GameObject balsa_bon_10;

                             public GameObject balsa_bon_11;

                                public GameObject balsa_bon_12;
                                   public GameObject balsa_bon_13;
                                      public GameObject balsa_bon_14;
                                   
      public float speed=1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("auto_balsa_coru", GameObject.Find("all_canv").GetComponent<InGame>().auto_lv_eff);
        StartCoroutine("auto_eff_coru",0.05f);
    }
    
    public void bul_balsa(){
      
             if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==1){
        Instantiate(balsa_bon_1,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==2){
          Instantiate(balsa_bon_2,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==3){
          Instantiate(balsa_bon_3,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==4){
          Instantiate(balsa_bon_4,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==5){
          Instantiate(balsa_bon_5,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==6){
          Instantiate(balsa_bon_6,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==7){
          Instantiate(balsa_bon_7,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==8){
          Instantiate(balsa_bon_8,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==9){
          Instantiate(balsa_bon_9,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==10){
          Instantiate(balsa_bon_10,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==11){
          Instantiate(balsa_bon_11,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==12){
          Instantiate(balsa_bon_12,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==13){
          Instantiate(balsa_bon_13,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }else if(GameObject.Find("all_canv").GetComponent<InGame>().bul_zin_lv==14){
          Instantiate(balsa_bon_14,balsa_pos.transform.position,balsa_pos.transform.rotation);
      }
        
     
        
       
    }

    IEnumerator auto_balsa_coru(float delayTime)
    {
       
        bul_balsa();
        
        yield return new WaitForSeconds(delayTime);
        StartCoroutine("auto_balsa_coru", GameObject.Find("all_canv").GetComponent<InGame>().auto_lv_eff);
    }
    IEnumerator auto_eff_coru(float delayTime) {
        if(GameObject.Find("all_canv").GetComponent<InGame>().auto_bool){
            bul_balsa();
        }else{

        }

        yield return new WaitForSeconds(0.05f);
        StartCoroutine("auto_eff_coru",0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
