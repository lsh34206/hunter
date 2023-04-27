
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using System.Numerics;
   using Random = UnityEngine.Random;
using System.Text.RegularExpressions;
using Vector3 = UnityEngine.Vector3;
using TMPro;

 [System.Serializable]
public class data{
    public string G;
        public string xp;
public int dia;
public int at_lv;
public int kill_count;
    public int crihwac_lv;
    public int cridem_lv;
    public int dia_drop_lv;
    public int jackpot_lv;
    public int auto_lv;
    public int jackpot_hwac_lv;
    public int at_dia_lv;
    public int gold_dia_lv;

        public int bul_zin_lv;
    public int yongold_lv;
    public int him_lv;
        public int point;
         public int stat_at_lv;
           public int stat_cridem_lv;
             public int stat_gold_lv;
               public int stat_xp_lv;
               public int xp_ad_point;
                  public int gold_ad_point;
                     public int at_ad_point;

                     public int rade_ticket;
                     public string rade_1_hhp;
                     public string rade_2_hhp;
                     public string rade_3_hhp;
                     
                   

}
public class InGame : MonoBehaviour
{
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
public AudioSource audioSource;

 public AudioClip bgm;

  public bool pop_up_in_monster=false;
    public int xp_ad_point;
                  public int gold_ad_point;
                     public int at_ad_point;

                      public int xp_ad_time;
                  public int gold_ad_time;
                     public int at_ad_time;
 public int rade_ticket;
                     public int rade_time=0;


                      public bool rade_bool=false;

                   
    public bool xp_ad_bool;
                  public bool gold_ad_bool;
                     public bool at_ad_bool;

    public int yongold_lv;
    public int him_lv;
 public int point;
    public BigInteger G;
    public BigInteger rade_1_hhp;
                     public BigInteger rade_2_hhp;
                     public BigInteger rade_3_hhp;

                             public BigInteger rade_minus_hp;
public int dia;
    public int at_lv;
    public int kill_count;
    public int crihwac_lv;
    public int cridem_lv;
    public int dia_drop_lv;
    public int jackpot_lv;
    public int auto_lv;
    public int jackpot_hwac_lv;
    public int at_dia_lv;
    public int gold_dia_lv;
        public int bul_zin_lv;
    data datavar = new data();
public Text G_t;
public Text dia_t;
    public int bul_speed;
    public int mon_speed;

    public int stage = 0;
    public Text stage_t;

    public BigInteger my_at_val;
              public BigInteger zuc_at_val;
                      public BigInteger my_hp_val;
              public BigInteger zuc_hp_val;
                public BigInteger my_hhp_val;
              public BigInteger zuc_hhp_val;

    public BigInteger zuc_drop_G;

    public Text next_stage_count_text;


    public Text yongold_lvup_about_text;
    public Text him_lvup_about_text;


    public Text yongold_lvup_btn_text;
    public Text him_lvup_btn_text;


    public SpriteRenderer mon_img;
    public Sprite mon_img_1;
    public Sprite mon_img_2;
 public Sprite mon_img_3;
    public Sprite mon_img_4;
    public Sprite mon_img_5;
 public Sprite mon_img_6;
    public Sprite mon_img_7;
    public Sprite mon_img_8;
    public Sprite mon_img_9;
    public Sprite mon_img_10;
    public Sprite mon_img_11;
     public Sprite mon_img_12;
      public Sprite mon_img_13;
       public Sprite mon_img_14;
        public Sprite mon_img_15;
        public Sprite mon_img_16;
        public Sprite mon_img_17;
        public Sprite mon_img_18;
        public Sprite mon_img_19;
        public Sprite mon_img_20;
        public Sprite mon_img_21;
        public Sprite mon_img_22;
        public Sprite mon_img_23;
        public Sprite mon_img_24;
        public Sprite mon_img_25;
        public Sprite mon_img_26;
        public Sprite mon_img_27;
        public Sprite mon_img_28;
        public Sprite mon_img_29;

    public Image bul_img;
    public Sprite bul_img_1;
    public Sprite bul_img_2;
 public Sprite bul_img_3;
    public Sprite bul_img_4;
    public Sprite bul_img_5;
 public Sprite bul_img_6;
    public Sprite bul_img_7;
    public Sprite bul_img_8;
    public Sprite bul_img_9;
    public Sprite bul_img_10;
    public Sprite bul_img_11;
       public Sprite bul_img_12;
          public Sprite bul_img_13;
             public Sprite bul_img_14;
             public Sprite bul_img_15;
             public Sprite bul_img_16;
             public Sprite bul_img_17;
             public Sprite bul_img_18;
             public Sprite bul_img_19;
             public Sprite bul_img_20;
             public Sprite bul_img_21;
             public Sprite bul_img_22;
             public Sprite bul_img_23;
             public Sprite bul_img_24;
             public Sprite bul_img_25;

             public Sprite bul_img_26;

             public Sprite bul_img_27;
             public Sprite bul_img_28;
             public Sprite bul_img_29;

        public Text bul_name;
             public Text bul_up_btn_about;

             public Text rade1_btn_about;
                public Text rade2_btn_about;
                   public Text rade3_btn_about;

 public Text rade_ticket_text;

public Sprite rade_mob_1;
public Sprite rade_mob_2;
public Sprite rade_mob_3;

public string mode="일반";

public GameObject rade_hp_obj;
public Image rade_hp_bar;
public Text rade_hp_text;
public GameObject rade_img_obj;
public Image rade_img;
public int rade_lv=0; 
    public Text at_lv_about_text;
    public Text crihwac_lv_about_text;
    public Text cridem_lv_about_text;
    public Text dia_drop_lv_about_text;
    public Text bul_speed_lv_about_text;
    public Text jackpot_lv_about_text;
    public Text auto_lv_about_text;
    public Text jackpot_hwac_lv_about_text;
    public Text at_up_lv_about_text;
    public Text gold_up_lv_about_text;

      public TextMeshProUGUI xp_text;
      public Image xp_bar;


    public BigInteger at_lv_eff;
    public BigInteger crihwac_lv_eff;
    public BigInteger cridem_lv_eff;
    public int dia_drop_lv_eff;
    public BigInteger bul_speed_lv_eff;
    public BigInteger jackpot_lv_eff;
    public float auto_lv_eff;
    public BigInteger jackpot_hwac_lv_eff;
    public BigInteger at_up_lv_eff;
    public BigInteger gold_up_lv_eff;

    public BigInteger at_lv_udg;
    public BigInteger crihwac_lv_udg;
    public BigInteger cridem_lv_udg;
    public BigInteger dia_drop_lv_udg;
    public BigInteger bul_speed_lv_udg;
    public BigInteger jackpot_lv_udg;
    public BigInteger auto_lv_udg;
    public BigInteger jackpot_hwac_lv_udg;
    public BigInteger at_up_lv_udg;
    public BigInteger gold_up_lv_udg;

    public BigInteger zuc_drop_xp;
    public BigInteger xp;

      public BigInteger bul_zin_eff;
      public int bul_zin_udg;

    public int lv;
    public GameObject alert;
    public Text alert_text;

   public Button yeongu_btn;

   public BigInteger yeongu_udg;
   public int yeongu_udg_dia;
   public BigInteger yeongu_gold_eff;
   public BigInteger yeongu_ad_plus_eff;
   public int yeongu_get_dia_plus_eff;
   public float yeongu_lvup_hwac;
   public BigInteger yeongu_sale_eff;

    public Button him_btn;

    public BigInteger him_udg;
    public int him_udg_dia;
    public BigInteger him_at_eff;
    public float him_lvup_hwac;
    public BigInteger him_cridem_plus_eff;
public Text point_text;

public BigInteger G_plus_eff;

public Text stat_text;

public GameObject exit_btn_obj;

public Text stat_at_lv_about_text;
public Text stat_cridem_lv_about_text;
public Text stat_gold_lv_about_text;
public Text stat_xp_lv_about_text;
public BigInteger stat_at_lv_eff;
public BigInteger stat_cridem_lv_eff;
public BigInteger stat_gold_lv_eff;
public BigInteger stat_xp_lv_eff;
   public int stat;

      public int stat_at_lv;
           public int stat_cridem_lv;
             public int stat_gold_lv;
               public int stat_xp_lv;

public Image background;
public Sprite background_main;
public Sprite background_dun;
public Sprite background_rade;
public GameObject main_shop_btn;

public GameObject rade_mon_img_obj;

public Text xp_ad_about_text;
public Text gold_ad_about_text;
public Text at_ad_about_text;

public int xp_ad_time_set=180;
public int gold_ad_time_set=180;
public int at_ad_time_set=180;

public int xp_ad_eff_set=1;
public int gold_ad_eff_set=1;
public int at_ad_eff_set=1;












public void pop_up_in_monster_false_func(){
        pop_up_in_monster=false;
    }

     public void pop_up_in_monster_true_func(){
        pop_up_in_monster=true;
    }
    // Start is called before the first frame update
    void Awake(){
    my_hp_val=100;
             my_hhp_val=100;
               zuc_hp_val=100;
             zuc_hhp_val=100;
                my_at_val=15;
}

 
    void Start()
    {
    Load();
 
    
    
    
    
    


     
       my_hp_val=100;
             my_hhp_val=100;
               zuc_hp_val=100;
             zuc_hhp_val=100;
                my_at_val=15;
        stage = 1;
        mode="일반";
          stage_fan();
             txtload();
         
        StartCoroutine("xp2_coru",1);
        StartCoroutine("gold2_coru",1);
        StartCoroutine("at2_coru",1);
                StartCoroutine("rade_coru",1);
                GameObject.Find("mon").GetComponent<mon_move>().barctrl();
        
    }
public Text yeongu_btn_text;

   public void at_sound_play(){
    audioSource.Play();
 }

    // Update is called once per frame
    void Update()
    {

    }


   IEnumerator xp2_coru(float delayTime) {
     if(xp_ad_bool){
xp_ad_time--;
txtload();
     }else{

     }

      yield return new WaitForSeconds(1);
           StartCoroutine("xp2_coru",1);
   }

   
   IEnumerator gold2_coru(float delayTime) {
     if(gold_ad_bool){
gold_ad_time--;
txtload();
     }else{

     }

      yield return new WaitForSeconds(1);
           StartCoroutine("gold2_coru",1);
   }

   
   IEnumerator at2_coru(float delayTime) {
     if(at_ad_bool){
at_ad_time--;
txtload();
     }else{

     }

      yield return new WaitForSeconds(1);
           StartCoroutine("at2_coru",1);
   }

      IEnumerator rade_coru(float delayTime) {
     if(rade_bool){
rade_time--;
txtload();
     }else{

     }

      yield return new WaitForSeconds(1);
           StartCoroutine("rade_coru",1);
   }


     public void stage_fan()
    {
    
       if(mode=="일반"){
        exit_btn_obj.SetActive(false);
        rade_img_obj.SetActive(false);
        rade_hp_obj.SetActive(false);
       stage_t.text = stage + "스테이지".ToString();
        zuc_hp_val = 100;
        zuc_hhp_val = 100;
        zuc_drop_xp=10;
        if (stage == 1)
        {
            zuc_hp_val = 100;
            zuc_hhp_val = 100;
            zuc_drop_G = 10;
             zuc_drop_xp=10;
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_1;
        }else if (stage == 2)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_2;
        }else if (stage == 3)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 1; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_3;
        }
        else if (stage == 4)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 2; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_4;
        }
        else if (stage == 5)
        {
        zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 3; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_5;
        }
        else if (stage ==6)
        {
          zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 4; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_6;
        }
        else if (stage == 7)
        {
         zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 5; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_7;
        }
        else if (stage == 8)
        {
          zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 6; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_8;
        }
        else if (stage == 9)
        {
          zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 7; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_9;
        }
        else if (stage ==10)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 8; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_10;
        }
        else if (stage ==11)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 9; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_11;
        }
        else if (stage ==12)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 10; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_12;
        }else if (stage ==13)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 11; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_13;
        } else if (stage ==14)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 12; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_14;
        } else if (stage ==15)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 17; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_15;
        } else if (stage ==16)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 21; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_16;
        }else if (stage ==17)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 28; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_17;
        }else if (stage ==18)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 35; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_18;
        }else if (stage ==19)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 43; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_19;
        }else if (stage ==20)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 51; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_20;
        }else if (stage ==21)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 61; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_21;
        }else if (stage ==22)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 70; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_22;
        }else if (stage ==23)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 80; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_23;
        }else if (stage ==24)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 90; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_24;
        }else if (stage ==25)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 100; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_25;
        }else if (stage ==26)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 120; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_26;
        }else if (stage ==27)
        {
           zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
              zuc_drop_xp=20;
            for(int i = 0; i < 140; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
                  zuc_drop_xp+=  zuc_drop_xp/10*7;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_27;
        }

       

        if (stage == 0)
        {
        
            main_shop_btn.SetActive(true);
           
          background.sprite=background_main;
         
        }

        if (stage > 0)
        {
        
              
               main_shop_btn.SetActive(false);
          background.sprite=background_dun;
        }
       }else if(mode=="레이드"){
            rade_img_obj.SetActive(true);
            rade_hp_obj.SetActive(true);
        exit_btn_obj.SetActive(true);
if(rade_lv==1){
    
stage_t.text = "레이드 "+rade_lv+"lv[스프레이 드래곤]".ToString();
 

}else if(rade_lv==2){
    stage_t.text = "레이드 "+rade_lv+"lv[레드 드래곤]".ToString();


}else if(rade_lv==3){
    stage_t.text = "레이드 "+rade_lv+"lv[스파이크 드래곤]".ToString();
    
      
}


        if (rade_lv == 1)
        {
               zuc_hp_val = 1600;
        zuc_hhp_val = 1600;
        zuc_drop_xp=200;
            zuc_drop_G=200;

         for(int i = 0;i<25;i++){
              zuc_hp_val *= 7;
        zuc_hhp_val *= 7;
        zuc_drop_xp*=4;
            zuc_drop_G*=5;
         }
         if(rade_1_hhp<=0){
    rade_1_hhp=zuc_hhp_val;
}

if(rade_1_hhp<=0){
                  
            }else{
              
       
 
            }

           rade_img.sprite=rade_mob_1;
        }else if(rade_lv==2){
              zuc_hp_val = 1600;
        zuc_hhp_val = 1600;
        zuc_drop_xp=200;
            zuc_drop_G=200;

         for(int i = 0;i<80;i++){
              zuc_hp_val *= 7;
        zuc_hhp_val *= 7;
        zuc_drop_xp*=4;
            zuc_drop_G*=5;
         }
     if(rade_2_hhp<=0){
    rade_2_hhp=zuc_hhp_val;
}
if(rade_2_hhp<=0){
                  
            }else{
              
  
 
            }
           rade_img.sprite=rade_mob_2;
        }else if(rade_lv==3){
                zuc_hp_val = 1600;
        zuc_hhp_val = 1600;
        zuc_drop_xp=200;
            zuc_drop_G=200;

         for(int i = 0;i<150;i++){
              zuc_hp_val *= 7;
        zuc_hhp_val *= 7;
        zuc_drop_xp*=4;
            zuc_drop_G*=5;
         }
     if(rade_3_hhp<=0){
    rade_3_hhp=zuc_hhp_val;
}
if(rade_3_hhp<=0){
                  
            }else{
              
      
 
            }
            rade_img.sprite=rade_mob_3;
        }


      
 
               main_shop_btn.SetActive(false);
          background.sprite=background_rade;
             rade_mon_img_obj.SetActive(true);
        GameObject.Find("Rade_mon_img").GetComponent<rade_move>().barctrl();
       }
     


    }

    public void stage_back()
    {
        stage--;
        stage_fan();
    }
    public void stage_next()
    {
      if(mode=="일반"){
            for(int i =0;i<stage;i++){
        if(i*300<=kill_count){
  stage++;
   
        }else{
             stage--;
            alert_text.text="현재 스테이지에서 적을 300마리 이상 처치하세요";
            alert.SetActive(true);
        }
          }

          if(stage==0){
            stage++;
          }
          Debug.Log(stage);
       stage_fan();
      }
      
    }

public void exit(){

if(mode=="레이드"){
    rade_time=0;
    stage=0;
    mode="일반";
    rade_lv=1; 
}
   
stage_fan();
 
    txtload();
}

public void rade1_st(){

    rade_time=30;
    stage=1;
    mode="레이드";
    rade_lv=1;
stage_fan();
 
    txtload();
}

public void rade2_st(){

    rade_time=30;
    stage=1;
    mode="레이드";
    rade_lv=2;
stage_fan();
 
    txtload();
}

public void rade3_st(){

    rade_time=30;
    stage=1;
    mode="레이드";
    rade_lv=3;
stage_fan();
 
    txtload();
}

    public void txtload(){
        point_text.text=point.ToString();
        rade_ticket_text.text=rade_ticket.ToString();
          if(lv <1500){
        yeongu_btn.interactable=false;
        yeongu_btn_text.text="1500lv";
    }else{
         yeongu_btn.interactable=true;
          yeongu_btn_text.text="연구소";
    }
        G_t.text=G.ToString();
           dia_t.text=dia.ToString();
           my_at_val=10;
        at_lv_udg = 100;
        BigInteger at_bigyo = 0;
        for(int i = 1;i<at_lv;i++)
        {
            my_at_val += i;
            at_lv_udg += at_lv_udg / 100;
            at_bigyo = i+1;
        }
        at_lv_udg-=at_lv_udg/100*yeongu_sale_eff;
        at_lv_about_text.text = "공격력 증가 현재:" + my_at_val+"\n 비용:골드" + at_lv_udg.ToString();
       crihwac_lv_eff=0;
        crihwac_lv_udg = 1000;
        for (int i = 0; i < crihwac_lv; i++)
        {
            crihwac_lv_eff++;
            crihwac_lv_udg *= 2;
        }
           crihwac_lv_udg-=crihwac_lv_udg/100*yeongu_sale_eff;
        crihwac_lv_about_text.text = "치명타 확률 현재:" + crihwac_lv_eff + "\n 비용:골드" + crihwac_lv_udg.ToString();
        cridem_lv_eff = 0;
        cridem_lv_udg = 100;
        for (int i = 0; i < cridem_lv; i++)
        {
            cridem_lv_eff += i;
            cridem_lv_udg += cridem_lv_udg / 50;
        }
          cridem_lv_udg-=cridem_lv_udg/100*yeongu_sale_eff;
        cridem_lv_about_text.text = "치명타 데미지 현재:+" + cridem_lv_eff + "%\n 비용:골드" + cridem_lv_udg.ToString();

        dia_drop_lv_eff = 1;
        dia_drop_lv_udg = 100000;
        for (int i = 0; i < dia_drop_lv; i++)
        {
            dia_drop_lv_eff += i;
            dia_drop_lv_udg *= 10;
        }
         dia_drop_lv_udg-=dia_drop_lv_udg/100*yeongu_sale_eff;
        dia_drop_lv_about_text.text = "다이아 드랍시 받는 다이아 현재:+" + dia_drop_lv_eff + "개\n 비용:골드" + dia_drop_lv_udg.ToString();

        jackpot_lv_eff = 100;
        jackpot_lv_udg = 10000;
        for (int i = 0; i < jackpot_lv; i++)
        {
            jackpot_lv_eff *= 5;
            jackpot_lv_udg *= 10;
        }
         jackpot_lv_udg-=jackpot_lv_udg/100*yeongu_sale_eff;
        jackpot_lv_about_text.text = "잭팟(몬스터 처치시 대량 골드 획득) 현재:+" + jackpot_lv_eff + "배 \n 비용:골드" + jackpot_lv_udg.ToString();

        auto_lv_eff = 4f;
        auto_lv_udg = 10000;
        for (int i = 0; i < auto_lv; i++)
        {
            auto_lv_eff -= 0.04f;
            auto_lv_udg += auto_lv_udg / 100 * 20;
        }
              auto_lv_udg-=auto_lv_udg/100*yeongu_sale_eff;
        auto_lv_about_text.text = "총알 자동 발사 현재:" + auto_lv_eff + "초마다(발사) \n 비용:골드" + auto_lv_udg.ToString();

        jackpot_hwac_lv_eff = 2;
        jackpot_hwac_lv_udg = 50000;
        for (int i = 0; i < jackpot_hwac_lv; i++)
        {
            jackpot_hwac_lv_eff += 1;
            jackpot_hwac_lv_udg *= 20;
        }
          jackpot_hwac_lv_udg-=jackpot_hwac_lv_udg/100*yeongu_sale_eff;
        jackpot_hwac_lv_about_text.text = "잭팟확률 현재:" + jackpot_hwac_lv_eff + "% \n 비용:골드" + jackpot_hwac_lv_udg.ToString();

        at_up_lv_eff = 0;
        at_up_lv_udg = 1;
        for (int i = 0; i < at_dia_lv; i++)
        {
            at_up_lv_eff++;
            at_up_lv_udg++;
        }
        at_up_lv_about_text.text = "추가 공격력 현재:+" + at_up_lv_eff + "% \n 비용:다이아" + at_up_lv_udg.ToString();

        gold_up_lv_eff = 0;
        gold_up_lv_udg = 1;
        for (int i = 0; i < gold_dia_lv; i++)
        {
            gold_up_lv_eff++;
            gold_up_lv_udg++;
        }
        gold_up_lv_about_text.text = "추가 골드 획득량 현재:+" + gold_up_lv_eff + "% \n 비용:다이아" + gold_up_lv_udg.ToString();

bul_zin_eff=1;
bul_zin_udg=1000;
if(bul_zin_lv==1){
    bul_img.sprite=bul_img_1;
    bul_zin_eff=1;
    bul_zin_udg=500;
    bul_name.text="lv.1콩알탄(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==2){
        bul_img.sprite=bul_img_2;
    bul_zin_eff=2;
    bul_zin_udg=1000;
    bul_name.text="lv.2롱알탄(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==3){
        bul_img.sprite=bul_img_3;
    bul_zin_eff=3;
    bul_zin_udg=2000;
    bul_name.text="lv.3매미 자석(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==4){
        bul_img.sprite=bul_img_4;
    bul_zin_eff=4;
    bul_zin_udg=4000;
    bul_name.text="lv.4마카롱(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==5){
        bul_img.sprite=bul_img_5;
    bul_zin_eff=5;
    bul_zin_udg=6000;
    bul_name.text="lv.5햄버거(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==6){
        bul_img.sprite=bul_img_6;
    bul_zin_eff=6;
    bul_zin_udg=10000;
    bul_name.text="lv.6청새치 가시(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==7){
        bul_img.sprite=bul_img_7;
    bul_zin_eff=7;
    bul_zin_udg=15000;
    bul_name.text="lv.7강력한 청새치 가시(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==8){
        bul_img.sprite=bul_img_8;
    bul_zin_eff=8;
    bul_zin_udg=20000;
    bul_name.text="lv.8가시 핵미사일 가시(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==9){
        bul_img.sprite=bul_img_9;
    bul_zin_eff=9;
    bul_zin_udg=25000;
    bul_name.text="lv.9염산든 삼각 플라스크(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==10){
        bul_img.sprite=bul_img_10;
    bul_zin_eff=10;
    bul_zin_udg=30000;
    bul_name.text="lv.10오징어 핵미사일(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==11){
        bul_img.sprite=bul_img_11;
    bul_zin_eff=11;
    bul_zin_udg=35000;
    bul_name.text="lv.11올리브(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==12){
        bul_img.sprite=bul_img_12;
    bul_zin_eff=12;
    bul_zin_udg=40000;
    bul_name.text="lv.12양파링(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==13){
        bul_img.sprite=bul_img_13;
    bul_zin_eff=13;
    bul_zin_udg=40000;
    bul_name.text="lv.13소원 알약(현재 최종 공격력x"+bul_zin_eff+")".ToString();
}else if(bul_zin_lv==14){
        bul_img.sprite=bul_img_14;
    bul_zin_eff=14;
    bul_zin_udg=45000;
    bul_name.text="lv.14COVID-19(현재 최종 공격력x"+bul_zin_eff+")MAXLV".ToString();
}

bul_up_btn_about.text="최종 공격력 증가[탄알 강화] 다이아"+bul_zin_udg.ToString();


     



        yeongu_udg = 2500000;
        yeongu_udg_dia = 100;
        yeongu_ad_plus_eff=0;
        yeongu_get_dia_plus_eff = 0;
        yeongu_gold_eff = 0;
        yeongu_sale_eff = 0;
        yeongu_lvup_hwac = 1000;

        for(int i = 1; i < yongold_lv; i++)
        {
         
            if (yongold_lv<=9)
            {
                yeongu_lvup_hwac = 1000;
           
                yeongu_gold_eff += 250;
            

            }
            
            if(yongold_lv>=10&&yongold_lv<=19)
            {
                yeongu_lvup_hwac = 900;

           
                yeongu_gold_eff += 550;
                yeongu_sale_eff = 10; 
            }
      
            
            if (yongold_lv>=20&&yongold_lv<=29)
            {
                yeongu_lvup_hwac = 800;
             
                yeongu_gold_eff += 1550;
                yeongu_sale_eff=12;
                yeongu_get_dia_plus_eff = 1;
            }

            if (yongold_lv>=30&&yongold_lv<=39)
            {
                yeongu_lvup_hwac =700;

                yeongu_gold_eff += 2550;
                yeongu_sale_eff = 14;
                yeongu_get_dia_plus_eff = 1;
                yeongu_ad_plus_eff = 2;
            }



            if (yongold_lv>=40&&yongold_lv<=49)
            {
                yeongu_lvup_hwac = 600;

                yeongu_gold_eff +=3550;
                yeongu_sale_eff = 16;
                yeongu_get_dia_plus_eff = 1;
                yeongu_ad_plus_eff = 5;
            }

            if (yongold_lv>=50&&yongold_lv<=59)
            {
                yeongu_lvup_hwac = 500;

                yeongu_gold_eff +=5550;
                yeongu_get_dia_plus_eff = 2;
                yeongu_sale_eff = 18;
                yeongu_ad_plus_eff = 8;
            }

            if (yongold_lv>=60&&yongold_lv<=69)
            {
                yeongu_lvup_hwac = 400;

                yeongu_gold_eff += 7550;
                yeongu_get_dia_plus_eff = 2;
                yeongu_sale_eff = 20;
                yeongu_ad_plus_eff = 12;
            }

            if (yongold_lv>=70&&yongold_lv<=79)
            {
                yeongu_lvup_hwac = 300;

                yeongu_gold_eff += 9550;
                yeongu_get_dia_plus_eff = 3;
                yeongu_sale_eff = 22;
                yeongu_ad_plus_eff = 18;
            }

            if (yongold_lv>=80&&yongold_lv<=89)
            {
                yeongu_lvup_hwac = 200;

                yeongu_gold_eff += 12550;
                yeongu_sale_eff = 24;
                yeongu_get_dia_plus_eff = 3;
                yeongu_ad_plus_eff = 24;
            }

            if (yongold_lv>=90&&yongold_lv<=99)
            {
                yeongu_lvup_hwac = 100;

                yeongu_gold_eff += 15550;
yeongu_sale_eff=26;
                yeongu_ad_plus_eff = 30;
                yeongu_get_dia_plus_eff = 3;
            }

            if (yongold_lv>=100&&yongold_lv<=109)
            {
                yeongu_lvup_hwac = 50;

                yeongu_gold_eff += 35550;
                yeongu_sale_eff =28;
                yeongu_get_dia_plus_eff = 4;
                yeongu_ad_plus_eff = 35;
            }


            if (yongold_lv>=110)
            {
                yeongu_lvup_hwac =10;

                yeongu_gold_eff += 55550;

            }
        }

        for(int i = 0; i < yongold_lv*10; i+=10)
        {
            yeongu_udg *= 10;
        }
yeongu_udg-=yeongu_udg/100*yeongu_sale_eff;
        yongold_lvup_btn_text.text = "업그레이드" + yeongu_udg + "골드\n " + yeongu_udg_dia + "다이아\n성공확률"+(yeongu_lvup_hwac/10)+"%".ToString();
        yongold_lvup_about_text.text = "연금술" + yongold_lv + "lv\n추가 골드+" + yeongu_gold_eff + "%\n업글비용 할인-" + yeongu_sale_eff + "%\n광고 보상 증가+" + yeongu_ad_plus_eff + "%\n다이아 획득량+" + yeongu_get_dia_plus_eff + "개".ToString();



       him_udg = 2500000;
        him_udg_dia = 100;
        him_cridem_plus_eff = 0;
        him_at_eff = 0;
        him_lvup_hwac = 1000;
      
        for (int i = 1; i < him_lv; i++)
        {
           
            if (him_lv<=9)
            {
                him_lvup_hwac = 1000;

               him_at_eff += 250;


            }

            if (him_lv>=10&&him_lv<=19)
            {

                him_lvup_hwac = 900;

                him_cridem_plus_eff =50;
                him_at_eff += 550;
            }


            if (him_lv>=20&&him_lv<=29)
            {

                him_lvup_hwac =800;
                him_cridem_plus_eff = 550;
                him_at_eff += 1250;
            }

            if (him_lv>=30&&him_lv<=39)
            {

                him_lvup_hwac = 700;
                him_cridem_plus_eff = 1250;
                him_at_eff += 2250;
            }



            if (him_lv>=40&&him_lv<=49)
            {

                him_lvup_hwac = 600;
                him_cridem_plus_eff = 3850;
                him_at_eff += 5250;
            }

            if (him_lv>=50&&him_lv<=59)
            {

                him_lvup_hwac = 500;
                him_cridem_plus_eff = 7000;
                him_at_eff += 7250;
            }

            if (him_lv>=60&&him_lv<=69)
            {

                him_lvup_hwac = 400;
                him_cridem_plus_eff = 15000;
                him_at_eff += 10250;
            }

            if (him_lv>=70&&him_lv<=79)
            {

                him_lvup_hwac = 300;
                him_cridem_plus_eff = 30000;
                him_at_eff += 15250;
            }

            if (him_lv>=80&&him_lv<=89)
            {

                him_lvup_hwac = 200;
                him_cridem_plus_eff = 55000;
                him_at_eff +=20250;
            }

            if (him_lv>=90&&him_lv<=99)
            {

                him_lvup_hwac = 100;
                him_cridem_plus_eff = 107000;
                him_at_eff += 30250;
            }

            if (him_lv>=100&&him_lv<=109)
            {
                him_cridem_plus_eff = 227000;
                him_lvup_hwac = 50;
                him_at_eff += 40250;
            }


            if (him_lv >= 110)
            {
               him_lvup_hwac = 10;
                him_cridem_plus_eff = 347000;
                him_at_eff += 55550;

            }
        }

        for (int i = 0; i < him_lv * 10; i += 10)
        {
           him_udg *=10;
        }
him_udg-=him_udg/100*yeongu_sale_eff;
       him_lvup_btn_text.text = "업그레이드" + him_udg + "골드\n " + him_udg_dia + "다이아\n성공확률" + (him_lvup_hwac / 10) + "%".ToString();
        him_lvup_about_text.text = "힘" + him_lv + "lv\n추가 공격력+" + him_at_eff + "%\n추가치명타데미지+" + him_cridem_plus_eff + "%".ToString();

stat=lv*4-(stat_at_lv+stat_cridem_lv+stat_gold_lv+stat_xp_lv);
stat_text.text="스텟 포인트:"+stat.ToString();

stat_at_lv=0;
for(int i = 1;i<stat_at_lv;i++){
    stat_at_lv_eff+=i;
}
stat_at_lv_about_text.text="스텟 강화->공격력+"+stat_at_lv_eff+"%\n스텟 포인트1 사용".ToString();

stat_cridem_lv=0;
for(int i = 1;i<stat_cridem_lv;i++){
    stat_cridem_lv_eff+=i;
}
stat_cridem_lv_about_text.text="스텟 강화->치명타 공격력+"+stat_cridem_lv_eff+"%\n스텟 포인트1 사용".ToString();

stat_gold_lv=0;
for(int i = 1;i<stat_gold_lv;i++){
    stat_gold_lv_eff+=i*2;
}
stat_gold_lv_about_text.text="스텟 강화->추가 골드 획득량+"+stat_gold_lv_eff+"%\n스텟 포인트1 사용".ToString();

stat_xp_lv=0;
for(int i = 1;i<stat_xp_lv;i++){
    stat_xp_lv_eff+=i;
}
stat_xp_lv_about_text.text="스텟 강화->추가 경험치+"+stat_xp_lv_eff+"%\n스텟 포인트1 사용".ToString();

my_at_val+=my_at_val/100*(at_up_lv_eff+him_at_eff+stat_at_lv_eff+at_up_lv_eff)*bul_zin_eff;
cridem_lv_eff+=cridem_lv_eff/100*(him_cridem_plus_eff+stat_cridem_lv_eff);
G_plus_eff=gold_up_lv_eff+stat_gold_lv_eff+yeongu_gold_eff+gold_up_lv_eff;

 xp_ad_time_set=180;
 gold_ad_time_set=180;
at_ad_time_set=180;

 xp_ad_eff_set=2;
 gold_ad_eff_set=2;
 at_ad_eff_set=2;




if(mode=="레이드"){
    if(rade_time<=0){
rade_bool=false;
if(rade_lv==1){
rade_1_hhp=zuc_hhp_val;
}else if(rade_lv==2){
    rade_2_hhp=zuc_hhp_val;
}else if(rade_lv==3){
    rade_3_hhp=zuc_hhp_val;
}
Save();
mode="일반";
stage=1;
stage_fan();


}else{
rade_bool=true;


}
}





if(xp_ad_time<=0){
xp_ad_bool=false;

for(int i = 5;i<xp_ad_point;i+=5){
xp_ad_time_set+=60;

}

for(int i = 20;i<xp_ad_point;i+=20){
xp_ad_eff_set++;

}

    xp_ad_about_text.text="베이컨[광고]\n "+(xp_ad_point/5)+"lv"+(xp_ad_time_set/60)+"분동안 경험치 "+xp_ad_eff_set+"배 \n광고 레벨업까지 "+(xp_ad_point%5)+"번/5번".ToString();

}else{
xp_ad_bool=true;

if(xp_ad_bool){
    xp_ad_about_text.text=xp_ad_time.ToString();
    
}else{
   xp_ad_eff_set=1; 
}
}

if(gold_ad_time<=0){
gold_ad_bool=false;
for(int i = 5;i<gold_ad_point;i+=5){
gold_ad_time_set+=60;

}
for(int i = 20;i<gold_ad_point;i+=20){
gold_ad_eff_set++;

}
    gold_ad_about_text.text="삼겹살[광고]\n "+(gold_ad_point/5)+"lv"+(gold_ad_time_set/60)+"분동안 골드 "+gold_ad_eff_set+"배 \n광고 레벨업까지 "+(gold_ad_point%5)+"번/5번".ToString();

}else{
gold_ad_bool=true;
if(gold_ad_bool){
    gold_ad_about_text.text=gold_ad_time.ToString();
}else{
    gold_ad_eff_set=1;
}
}

if(at_ad_time<=0){
at_ad_bool=false;

for(int i = 5;i<at_ad_point;i+=5){
at_ad_time_set+=60;

}
for(int i = 20;i<at_ad_point;i+=20){
at_ad_eff_set++;

}
    at_ad_about_text.text="칠면조[광고]\n "+(at_ad_point/5)+"lv"+(at_ad_time_set/60)+"분동안 공격력 "+at_ad_eff_set+"배 \n광고 레벨업까지 "+(at_ad_point%5)+"번/5번".ToString();

}else{
at_ad_bool=true;
if(at_ad_bool){
    at_ad_about_text.text=at_ad_time.ToString();
}else{
    at_ad_eff_set=1;
}
}

if(mode=="일반"){
    next_stage_count_text.text="다음 스테이지 "+(kill_count%300)+"/300마리".ToString();
}else if(mode=="레이드"){
   next_stage_count_text.text="레이드 "+rade_lv+"lv "+rade_time+"초 남음".ToString();
}

if(rade_1_hhp<=0){
       zuc_hp_val = 1600;
        zuc_hhp_val = 1600;
        zuc_drop_xp=200;
            zuc_drop_G=200;

         for(int i = 0;i<12;i++){
              zuc_hp_val *= 7;
        zuc_hhp_val *= 7;
        zuc_drop_xp*=4;
            zuc_drop_G*=5;
         }
         rade_1_hhp=zuc_hhp_val;
}

if(rade_2_hhp<=0){
       zuc_hp_val = 1600;
        zuc_hhp_val = 1600;
        zuc_drop_xp=200;
            zuc_drop_G=200;

         for(int i = 0;i<24;i++){
              zuc_hp_val *= 7;
        zuc_hhp_val *= 7;
        zuc_drop_xp*=4;
            zuc_drop_G*=5;
         }
         rade_2_hhp=zuc_hhp_val;
}

if(rade_3_hhp<=0){
       zuc_hp_val = 1600;
        zuc_hhp_val = 1600;
        zuc_drop_xp=200;
            zuc_drop_G=200;

         for(int i = 0;i<50;i++){
              zuc_hp_val *= 7;
        zuc_hhp_val *= 7;
        zuc_drop_xp*=4;
            zuc_drop_G*=5;
         }
         rade_3_hhp=zuc_hhp_val;
}
rade1_btn_about.text="레이드 레벨1 티켓-1\n남은체력:"+rade_1_hhp.ToString();
rade2_btn_about.text="레이드 레벨2 티켓-1\n남은체력:"+rade_2_hhp.ToString();
rade3_btn_about.text="레이드 레벨3 티켓-1\n남은체력:"+rade_3_hhp.ToString();


}



        
    public void rade_end_func(){

    }

    
      public void bul_zin_up_func()
    {
        if(bul_zin_lv ==14){
             alert_text.text = "최고 레벨";
            alert.SetActive(true);
        }else{
             if (dia< bul_zin_udg)
        {
            alert_text.text = "다이아 부족";
            alert.SetActive(true);
        }
        else
        {
            bul_zin_lv++; 
            dia -= bul_zin_udg;
            txtload();
        }
        }
       
    }


    public void at_up_func()
    {
        if (G < at_lv_udg)
        {
            alert_text.text = "골드부족";
            alert.SetActive(true);
        }
        else
        {
            at_lv++;
            G -= at_lv_udg;
            txtload();
        }
    }


    public void crihwac_up_func()
    {
        if (G < crihwac_lv_udg)
        {
            alert_text.text = "골드부족";
            alert.SetActive(true);
        }
        else
        {
            crihwac_lv++;
            G -= crihwac_lv_udg;
            txtload();
        }
    }

    public void cridem_up_func()
    {
        if (G < cridem_lv_udg)
        {
            alert_text.text = "골드부족";
            alert.SetActive(true);
        }
        else
        {
            cridem_lv++;
            G -= cridem_lv_udg;
            txtload();
        }
    }

    public void dia_drop_up_func()
    {
        if (G < dia_drop_lv_udg)
        {
            alert_text.text = "골드부족";
            alert.SetActive(true);
        }
        else
        {
            dia_drop_lv++;
            G -= dia_drop_lv_udg;
            txtload();
        }
    }

    public void jackpot_up_func()
    {
        if (G < jackpot_lv_udg)
        {
            alert_text.text = "골드부족";
            alert.SetActive(true);
        }
        else
        {
            jackpot_lv++;
            G -= jackpot_lv_udg;
            txtload();
        }
    }

    public void jackpot_hwac_up_func()
    {
        if (G < jackpot_hwac_lv_udg)
        {
            alert_text.text = "골드부족";
            alert.SetActive(true);
        }
        else
        {
            jackpot_hwac_lv++;
            G -= jackpot_hwac_lv_udg;
            txtload();
        }
    }

    public void auto_up_func()
    {
        if (G < auto_lv_udg)
        {
            alert_text.text = "골드부족";
            alert.SetActive(true);
        }
        else
        {
            auto_lv++;
            G -= auto_lv_udg;
            txtload();
        }
    }

    public void dia_at_up_func()
    {
        if (dia<1)
        {
            alert_text.text = "다이아 부족";
            alert.SetActive(true);
        }
        else
        {
          at_dia_lv++;
            dia--;
            txtload();
        }
    }

    public void dia_gold_up_func()
    {
        if (dia < 1)
        {
            alert_text.text = "다이아 부족";
            alert.SetActive(true);
        }
        else
        {
            gold_dia_lv++;
            dia--;
            txtload();
        }
    }

public void xp_ad_func(){
        if(xp_ad_bool){
              alert_text.text = "이미 적용중";
            alert.SetActive(true);
        }else{
             GameObject.Find("all_canv").GetComponent<xp2>().Show();
        }
    }
    
    public void gold_ad_func(){
        if(gold_ad_bool){
              alert_text.text = "이미 적용중";
            alert.SetActive(true);
        }else{
            GameObject.Find("all_canv").GetComponent<gold2>().Show();
        }
    }
    
    public void at_ad_func(){
        if(at_ad_bool){
              alert_text.text = "이미 적용중";
            alert.SetActive(true);
        }else{
            GameObject.Find("all_canv").GetComponent<at2>().Show();
        }
    }
    
    public void Load(){
      
   string path = Application.persistentDataPath + "/data.Json";
if(File.Exists(path)){
    string json = File.ReadAllText(path);
 data datavar = JsonUtility.FromJson<data>(json);
     

      
    
            G = BigInteger.Parse(datavar.G); 
                     xp = BigInteger.Parse(datavar.xp); 
                 

dia=datavar.dia;

            at_lv = datavar.at_lv;
            kill_count = datavar.kill_count;
            crihwac_lv = datavar.crihwac_lv;
            cridem_lv = datavar.cridem_lv;
            dia_drop_lv = datavar.dia_drop_lv;
            jackpot_lv = datavar.jackpot_lv;
            auto_lv = datavar.auto_lv;
            jackpot_hwac_lv = datavar.jackpot_hwac_lv;
            at_dia_lv = datavar.at_dia_lv;
            gold_dia_lv = datavar.gold_dia_lv;
            kill_count = datavar.kill_count;
                   bul_zin_lv= datavar.bul_zin_lv;
           yongold_lv = datavar.yongold_lv;
            him_lv = datavar.him_lv;
                 point =datavar.point;
                  stat_at_lv = datavar.stat_at_lv;
                   stat_cridem_lv = datavar.stat_cridem_lv;
                    stat_gold_lv = datavar.stat_gold_lv;
                     stat_xp_lv = datavar.stat_xp_lv;


                          xp_ad_point=datavar.xp_ad_point;    
                      gold_ad_point=datavar.gold_ad_point;    
                       at_ad_point=datavar.at_ad_point; 

                    rade_ticket=datavar.rade_ticket;
                  rade_1_hhp=BigInteger.Parse(datavar.rade_1_hhp);
                          rade_2_hhp=BigInteger.Parse(datavar.rade_2_hhp);
                               rade_3_hhp=BigInteger.Parse(datavar.rade_3_hhp);
        }
        else{
G=0;
dia=0;
at_lv=1;
            kill_count= 0;
    crihwac_lv=0;
    cridem_lv=0;
    dia_drop_lv=0;
    jackpot_lv=0;
    auto_lv=0;
    jackpot_hwac_lv=0;
    at_dia_lv=0;
    gold_dia_lv=0;
    xp=0;
    bul_zin_lv=1;
            yongold_lv=0;
 him_lv=0;
 point=0;
    stat_at_lv=0;
         stat_cridem_lv=0;
           stat_gold_lv=0;
             stat_xp_lv=0;

              xp_ad_point=0;
                  gold_ad_point=0;
                     at_ad_point=0;
                                              
  rade_ticket=0;
               rade_1_hhp=0;
                       rade_2_hhp=0;
                        rade_3_hhp=0;
                     
         
    return;
}

}

 public void Save(){
        
      
        datavar.G = G.ToString();
            datavar.xp = xp.ToString();
                
datavar.dia=dia;
         datavar.at_lv =at_lv;
        datavar.kill_count = kill_count;
        datavar.crihwac_lv = crihwac_lv;
        datavar.cridem_lv = cridem_lv;
        datavar.dia_drop_lv = dia_drop_lv;
        datavar.jackpot_lv = jackpot_lv;
        datavar.auto_lv = auto_lv;
        datavar.jackpot_hwac_lv = jackpot_hwac_lv;
        datavar.at_dia_lv = at_dia_lv;
        datavar.gold_dia_lv = gold_dia_lv;
       datavar.kill_count= kill_count;
        datavar.bul_zin_lv= bul_zin_lv;
        datavar.yongold_lv = yongold_lv;
        datavar.him_lv = him_lv;
           datavar.point =point;
                 datavar.stat_at_lv = stat_at_lv;
                    datavar.stat_cridem_lv =stat_cridem_lv;
                    datavar.stat_gold_lv = stat_gold_lv;
                     datavar.stat_xp_lv = stat_xp_lv;  

                     datavar.xp_ad_point=xp_ad_point;    
                      datavar.gold_ad_point=gold_ad_point;    
                       datavar.at_ad_point=at_ad_point;    
                         
     datavar.rade_ticket=rade_ticket;
                  datavar.rade_1_hhp=rade_1_hhp.ToString();
                          datavar.rade_2_hhp=rade_2_hhp.ToString();
                               datavar.rade_3_hhp=rade_3_hhp.ToString();
                     
    string json = JsonUtility.ToJson(datavar);
        Debug.Log(json);
        string path = Application.persistentDataPath + "/data.Json";
        File.WriteAllText(path,json);
    }

    void OnApplicationPause(bool pauseStatus){
    if(pauseStatus){
        Save();
    }
}

void OnApplicationQuit(){

Save();
}
}