using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
public class bul_sp : MonoBehaviour
{
     public Transform balsa_pos;
    public GameObject balsa_bon;
      public float speed=1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void bul_balsa(){
        Instantiate(balsa_bon,balsa_pos.transform.position,balsa_pos.transform.rotation);
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
