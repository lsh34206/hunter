using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using System.Numerics;
public class bul_move : MonoBehaviour
{
          private float speed=1f;
 
void Start(){
    Destroy(gameObject,3f);
}
        void OnCollisionEnter2D(Collision2D col){
if(col.collider.CompareTag("monster")){
     Destroy(gameObject);
          
}
      

       



 
         
    }  
    // Update is called once per frame
    void Update()
    {


     gameObject.transform.Translate(new Vector3(-speed,0,0));
    }
}
