using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
public class mon_sp : MonoBehaviour
{
    public Transform mon_pos;
    public GameObject mon;
    // Start is called before the first frame update
    void Start()
    {
      
            StartCoroutine("mon_sp_coru",2.5f);

         
    }
    public void des(){
        Destroy(mon);
    }

     IEnumerator mon_sp_coru(float delayTime) {

if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"||GameObject.Find("all_canv").GetComponent<InGame>().stage<=0){

}else{
       Instantiate(mon,mon_pos.transform.position,mon_pos.transform.rotation);
   GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val=GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val;
}
      
          
        
      yield return new WaitForSeconds(2.5f);
           StartCoroutine("mon_sp_coru",2.5f);

         
 
   }
  
  
    // Update is called once per frame
    void Update()
    {
  
    }
}
