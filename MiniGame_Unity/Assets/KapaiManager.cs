using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapaiManager : MonoBehaviour
{
    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;
    bool b5 = false;
    bool b6 = false;
    bool b7 = false;
    bool b8 = false;
    public GameObject chaihu_1;
    public GameObject huagnqin_2;
    public GameObject dangshen_3;
    public GameObject renshen_4;
    public GameObject baishu_5;
    public GameObject fuling_6;
    public GameObject danggui_7;
    public GameObject dihuang_8;
    public GameObject chaihu_11;
    public GameObject huagnqin_22;
    public GameObject dangshen_33;
    public GameObject renshen_44;
    public GameObject baishu_55;
    public GameObject fuling_66;
    public GameObject danggui_77;
    public GameObject dihuang_88;
    private Vector3 beginTrans1;
    private Vector3 beginTrans2;
    private Vector3 beginTrans3;
    private Vector3 beginTrans4;
    private Vector3 beginTrans5;
    private Vector3 beginTrans6;
    private Vector3 beginTrans7;
    private Vector3 beginTrans8;
    public GameObject anban;
    public int liucheng = 0;
    public GameObject dui;
    public GameObject cuo;
    public static bool pengzhuagn = false;
    public GameObject xiaochaihutang;
    public GameObject baizhusan;
    public GameObject siwutang;
    bool add = true;
    public GameObject hongdui1;
    public GameObject hongdui2;
    public GameObject hongdui3;
    public GameObject hongquan3;
    public GameObject hongquan2;
    public AudioSource as_dui;
    public AudioSource as_cuo;
    public int count = 0;
    bool do1 = false;
    bool do2 = false;
    bool do3 = false;
    bool do4 = false;
    bool do5 = false;
    bool do6 = false;
    bool do7 = false;
    bool do8 = false;
    public GameObject next;
    public GameObject mask;

    // Use this for initialization
    void Start()
    {
        if (gameObject.scene.name == "05")
        {
            liucheng = 0;
            b1 = true;
            b2 = true;
            b3 = true;
        }
        if (gameObject.scene.name == "13")
        {
            liucheng = 1;
            b4 = true;
            b5 = true;
            b6 = true;
        }
        if (gameObject.scene.name == "21")
        {
            liucheng = 2;
            b7 = true;
            b8 = true;
        }
        beginTrans1 = chaihu_1.transform.position;
        beginTrans2 = huagnqin_2.transform.position;
        beginTrans3 = dangshen_3.transform.position;
        beginTrans4 = renshen_4.transform.position;
        beginTrans5 = baishu_5.transform.position;
        beginTrans6 = fuling_6.transform.position;
        beginTrans7 = danggui_7.transform.position;
        beginTrans8 = dihuang_8.transform.position;
        chaihu_11.SetActive(false);
        huagnqin_22.SetActive(false);
        dangshen_33.SetActive(false);
        renshen_44.SetActive(false);
        baishu_55.SetActive(false);
        fuling_66.SetActive(false);
        danggui_77.SetActive(false);
        dihuang_88.SetActive(false);
        dui.SetActive(false);
        cuo.SetActive(false);
        xiaochaihutang.SetActive(false);
        baizhusan.SetActive(false);
        siwutang.SetActive(false);
        hongquan3.SetActive(false);
        hongquan2.SetActive(false);
        hongdui1.SetActive(false);
        hongdui2.SetActive(false);
        hongdui3.SetActive(false);

    }
    void AddPos(GameObject _gameObject, int index)
    {
        if (index == 1)
        {
            _gameObject.transform.localPosition = new Vector3(-325, 0, 0);
            hongdui1.SetActive(true);
        }
        else if (index == 2)
        {
            _gameObject.transform.localPosition = new Vector3(0, 0, 0);
            hongdui2.SetActive(true);
        }
        else if (index == 3)
        {
            _gameObject.transform.localPosition = new Vector3(325, 0, 0);
            hongdui3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!b1 && !b2 && !b3 && !b4 && !b5 && !b6 && !b7 && !b8)
        {
            next.SetActive(true);
            //Time.timeScale = 0;
            mask.SetActive(true);
        }
        if (Mathf.Abs(chaihu_1.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(chaihu_1.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b1 && !do1)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(chaihu_11, count);
                chaihu_11.SetActive(true);
                chaihu_1.SetActive(false);
                do1 = true;
                b1 = false;
            }
            else
            {
                if (!do1)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    chaihu_1.transform.position = beginTrans1;

                }
            }
        }
        if (Mathf.Abs(huagnqin_2.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(huagnqin_2.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b2 && !do2)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(huagnqin_22, count);
                huagnqin_22.SetActive(true);
                huagnqin_2.SetActive(false);
                do2 = true;
                b2 = false;
            }
            else
            {
                if (!do2)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    huagnqin_2.transform.position = beginTrans2;
                }
            }
        }
        if (Mathf.Abs(dangshen_3.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(dangshen_3.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b3 && !do3)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(dangshen_33, count);
                dangshen_33.SetActive(true);
                dangshen_3.SetActive(false);
                do3 = true;
                b3 = false;
            }
            else
            {
                if (!do3)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    dangshen_3.transform.position = beginTrans3;
                }
            }
        }
        if (Mathf.Abs(renshen_4.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(renshen_4.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b4 && !do4)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(renshen_44, count);
                renshen_44.SetActive(true);
                renshen_4.SetActive(false);
                do4 = true;
                b4 = false;
            }
            else
            {
                if (!do4)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    renshen_4.transform.position = beginTrans4;
                }
            }
        }
        if (Mathf.Abs(baishu_5.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(baishu_5.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b5 && !do5)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(baishu_55, count);
                baishu_55.SetActive(true);
                baishu_5.SetActive(false);
                do5 = true;
                b5 = false;
            }
            else
            {
                if (!do5)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    baishu_5.transform.position = beginTrans5;
                }
            }
        }
        if (Mathf.Abs(fuling_6.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(fuling_6.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b6 && !do6)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(fuling_66, count);
                fuling_66.SetActive(true);
                fuling_6.SetActive(false);
                do6 = true;
                b6 = false;
            }
            else
            {
                if (!do6)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    fuling_6.transform.position = beginTrans6;
                }
            }
        }
        if (Mathf.Abs(danggui_7.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(danggui_7.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b7 && !do7)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(danggui_77, count);
                danggui_77.SetActive(true);
                danggui_7.SetActive(false);
                do7 = true;
                b7 = false;
            }
            else
            {
                if (!do7)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    danggui_7.transform.position = beginTrans7;
                }
            }
        }
        if (Mathf.Abs(dihuang_8.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(dihuang_8.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (b8 && !do8)
            {
                as_dui.Play();
                count++;
                dui.SetActive(true);
                cuo.SetActive(false);
                AddPos(dihuang_88, count);
                dihuang_88.SetActive(true);
                dihuang_8.SetActive(false);
                do8 = true;
                b8 = false;
            }
            else
            {
                if (!do8)
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    dihuang_8.transform.position = beginTrans8;
                }
            }
        }
    }
}
