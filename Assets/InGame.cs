using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.IO;
using System.Numerics;
   using Random = UnityEngine.Random;
using System.Text.RegularExpressions;
using Vector3 = UnityEngine.Vector3;
 [System.Serializable]
public class data{
    public string G;
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

}
public class InGame : MonoBehaviour
{

        public BigInteger G;
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
    data datavar = new data();
public Text G_t;
public Text dia_t;
    public int bul_speed;
    public int mon_speed;

    public int stage = 1;
    public Text stage_t;

    public BigInteger my_at_val;
              public BigInteger zuc_at_val;
                      public BigInteger my_hp_val;
              public BigInteger zuc_hp_val;
                public BigInteger my_hhp_val;
              public BigInteger zuc_hhp_val;

    public BigInteger zuc_drop_G;

    public Text next_stage_count_text;


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


    public GameObject alert;
    public Text alert_text;
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
        txtload();
      // barctrl();
       my_hp_val=100;
             my_hhp_val=100;
               zuc_hp_val=100;
             zuc_hhp_val=100;
                my_at_val=15;
        stage = 1;
        stage_fan();
    }
  
    // Update is called once per frame
    void Update()
    {

    }
     public void stage_fan()
    {
        stage_t.text = stage + "스테이지".ToString();
        zuc_hp_val = 100;
        zuc_hhp_val = 100;
        if (stage == 1)
        {
            zuc_hp_val = 100;
            zuc_hhp_val = 100;
            zuc_drop_G = 10;
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_1;
        }else if (stage == 2)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_2;
        }else if (stage == 3)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for(int i = 0; i < 1; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_3;
        }
        else if (stage == 4)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for (int i = 0; i < 2; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_4;
        }
        else if (stage == 5)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for (int i = 0; i <3; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_5;
        }
        else if (stage ==6)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for (int i = 0; i < 4; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_6;
        }
        else if (stage == 7)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for (int i = 0; i < 5; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_7;
        }
        else if (stage == 8)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for (int i = 0; i < 6; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_8;
        }
        else if (stage == 9)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for (int i = 0; i < 7; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_9;
        }
        else if (stage ==10)
        {
            zuc_hp_val = 300;
            zuc_hhp_val = 300;
            zuc_drop_G = 20;
            for (int i = 0; i < 8; i++)
            {
                zuc_hp_val *= 5;
                zuc_hhp_val *= 5;
                zuc_drop_G *= 3;
            }
            mon_img.GetComponent<SpriteRenderer>().sprite = mon_img_10;
        }


        zuc_drop_G += zuc_drop_G / 100 * gold_up_lv_eff;

        if (stage < 1)
        {
            stage = 1;
            stage_fan();
        }

    }

    public void stage_back()
    {
        stage--;
        stage_fan();
    }
    public void stage_next()
    {
        stage++;
        stage_fan();
    }
    public void txtload(){
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
        at_lv_about_text.text = "공격력 증가 현재:" + my_at_val+"\n 비용:골드" + at_lv_udg.ToString();
       crihwac_lv_eff=0;
        crihwac_lv_udg = 1000;
        for (int i = 0; i < crihwac_lv; i++)
        {
            crihwac_lv_eff++;
            crihwac_lv_udg *= 2;
        }
        crihwac_lv_about_text.text = "치명타 확률 현재:" + crihwac_lv_eff + "\n 비용:골드" + crihwac_lv_udg.ToString();
        cridem_lv_eff = 0;
        cridem_lv_udg = 100;
        for (int i = 0; i < cridem_lv; i++)
        {
            cridem_lv_eff += i;
            cridem_lv_udg *= cridem_lv_udg / 50;
        }
        cridem_lv_about_text.text = "치명타 데미지 현재:+" + cridem_lv_eff + "%\n 비용:골드" + cridem_lv_udg.ToString();

        dia_drop_lv_eff = 1;
        dia_drop_lv_udg = 100000;
        for (int i = 0; i < dia_drop_lv; i++)
        {
            dia_drop_lv_eff += i;
            dia_drop_lv_udg *= 10;
        }
        dia_drop_lv_about_text.text = "다이아 드랍시 받는 다이아 현재:+" + dia_drop_lv_eff + "개\n 비용:골드" + dia_drop_lv_udg.ToString();

        jackpot_lv_eff = 100;
        jackpot_lv_udg = 10000;
        for (int i = 0; i < jackpot_lv; i++)
        {
            jackpot_lv_eff *= 5;
            jackpot_lv_udg *= 10;
        }
        jackpot_lv_about_text.text = "잭팟(몬스터 처치시 대량 골드 획득) 현재:+" + jackpot_lv_eff + "배 \n 비용:골드" + jackpot_lv_udg.ToString();

        auto_lv_eff = 1f;
        auto_lv_udg = 10000;
        for (int i = 0; i < auto_lv; i++)
        {
            auto_lv_eff -= 0.02f;
            auto_lv_udg += auto_lv_udg / 100 * 20;
        }
        auto_lv_about_text.text = "총알 자동 발사 현재:" + auto_lv_eff + "초마다(발사) \n 비용:골드" + auto_lv_udg.ToString();

        jackpot_hwac_lv_eff = 2;
        jackpot_hwac_lv_udg = 50000;
        for (int i = 0; i < jackpot_hwac_lv; i++)
        {
            jackpot_hwac_lv_eff += 1;
            jackpot_hwac_lv_udg *= 20;
        }
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


        my_at_val += my_at_val / 100 * at_dia_lv;


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


    public void Load(){
      
   string path = Application.persistentDataPath + "/data.Json";
if(File.Exists(path)){
    string json = File.ReadAllText(path);
 data datavar = JsonUtility.FromJson<data>(json);
     

      
    
            G = BigInteger.Parse(datavar.G); 
                 

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
    return;
}

}

 public void Save(){
        
      
        datavar.G = G.ToString();
                
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
