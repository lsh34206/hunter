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
         StartCoroutine("mon_sp_coru",2);
    }
    public void des(){
        Destroy(mon);
    }

     IEnumerator mon_sp_coru(float delayTime) {
        Instantiate(mon,mon_pos.transform.position,mon_pos.transform.rotation);
      yield return new WaitForSeconds(2);
           StartCoroutine("mon_sp_coru",2);
 
   }
  
    // Update is called once per frame
    void Update()
    {
  
    }
}
