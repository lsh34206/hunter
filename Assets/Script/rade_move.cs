
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System;
using System.Data;
using System.IO;
using System.Numerics;
using Random = UnityEngine.Random;
using System.Text.RegularExpressions;
using Vector3 = UnityEngine.Vector3;
using TMPro;
public class rade_move : MonoBehaviour
{
      private float speed=1f;
 public static class BigIntegerManager
    {      
        private static readonly BigInteger _unitSize = 1000;  
        private static Dictionary<string, BigInteger> _unitsMap = new Dictionary<string, BigInteger>();
        private static Dictionary<string, int> _idxMap = new Dictionary<string, int>(); 
        private static readonly List<string> _units = new List<string>();
        private static int _unitCapacity = 5; 
        private static readonly int _asciiA = 65;
        private static readonly int _asciiZ = 90;
        private static bool isInitialize = false;
        private static void UnitInitialize(int capacity)
        {
            _unitCapacity += capacity;
            
            //Initialize 0~999
            _units.Clear();  
            _unitsMap.Clear();
            _idxMap.Clear(); 
            _units.Add("");
            _unitsMap.Add("", 0);
            _idxMap.Add("", 0);   
            
            
            //capacity만큼 사전생성, capacity가 1인경우 A~Z
            //capacity가 2인경우 AA~AZ
            //capacity 1마다 ascii 알파벳 26개 생성되는 원리
            for (int n = 0; n <= _unitCapacity; n++)
            {
                for (int i = _asciiA; i <= _asciiZ; i++)
                {
                    string unit = null;
                    if (n == 0) 
                        unit = ((char) i).ToString();
                    else
                    {
                        var nCount = (float)n / 26; 
                        var nextChar = _asciiA + n - 1;  
                        var fAscii = (char) nextChar;
                        var tAscii = (char) i;
                        unit = $"{fAscii}{tAscii}"; 
                    }  
                    _units.Add(unit); 
                    _unitsMap.Add(unit, BigInteger.Pow(_unitSize, _units.Count-1)); 
                    _idxMap.Add(unit, _units.Count-1);
                }
            }    
            isInitialize = true;
        }


        private static int GetPoint(int value)
        {
                return (value % 1000) / 100; 
        }
        
        private static (int value, int idx, int point) GetSize(BigInteger value)
        { 
            //단위를 구하기 위한 값으로 복사
            var currentValue = value; 
            var current = (value / _unitSize) % _unitSize;
            var idx = 0; 
            var lastValue = 0;
            // 현재 값이 999(unitSize) 이상인경우 나눠야함.
            while (currentValue > _unitSize -1)
            {
                var predCurrentValue = currentValue / _unitSize;
                if (predCurrentValue <= _unitSize - 1)
                    lastValue = (int)currentValue;
                currentValue = predCurrentValue;
                idx += 1; 
            }

            var point = GetPoint(lastValue);  
            var originalValue = currentValue * 1000; 
            while (_units.Count <= idx) 
                UnitInitialize(5);  
            return ((int)currentValue, idx, point);
        }

        /// <summary>
        /// 숫자를 단위로 리턴
        /// </summary>
        /// <param name="value">값</param>
        /// <returns></returns>
        public static string GetUnit(BigInteger value)
        {
            if (isInitialize == false) 
                UnitInitialize(5);
            
            var sizeStruct = GetSize(value);
            return $"{sizeStruct.value}.{sizeStruct.point}{_units[sizeStruct.idx]}"; 
        }  
        
        /// <summary>
        /// 단위를 숫자로 변경
        /// 10A = 10000으로 리턴
        /// 1.2A = 1200으로 리턴
        /// 소수점 1자리만 지원함
        /// </summary>
        /// <param name="unit">단위</param>
        /// <returns></returns>
        public static BigInteger UnitToValue(string unit)
        {       
            if (isInitialize == false) 
                UnitInitialize(5);
            
            var split = unit.Split('.');
            //소수점에 관한 연산 들어감
            if (split.Length >= 2)
            { 
                var value = BigInteger.Parse(split[0]); 
                var point = BigInteger.Parse((Regex.Replace(split[1], "[^0-9]", "")));
                var unitStr = Regex.Replace(split[1], "[^A-Z]", "");

                if (point == 0) return (_unitsMap[unitStr] * value);
                else
                {
                    var unitValue = _unitsMap[unitStr];
                    return (unitValue * value) + (unitValue/10) * point;
                }
          
            }
            //비소수 연산 들어감
            else
            {
                var value = BigInteger.Parse((Regex.Replace(unit, "[^0-9]", ""))); 
                var unitStr = Regex.Replace(unit, "[^A-Z]", ""); 
                while (_unitsMap.ContainsKey(unitStr) == false) 
                    UnitInitialize(5); 
                var result = _unitsMap[unitStr] * value;

                if (result == 0) 
                    return int.Parse((unit));
                else 
                    return result;
            } 
        }
    }
     
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
   GameObject.Find("all_canv").GetComponent<InGame>().rade_hp_text.text=BigIntegerManager.GetUnit(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val)+"/"+BigIntegerManager.GetUnit(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hp_val).ToString();




if(GameObject.Find("all_canv").GetComponent<InGame>().zuc_hhp_val <=0){
                   if(GameObject.Find("all_canv").GetComponent<InGame>().mode=="레이드"){
                    GameObject.Find("all_canv").GetComponent<InGame>().rade_time=0;
                    GameObject.Find("all_canv").GetComponent<InGame>().rade_end_func();
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
       

           

 
         
      
    
    


