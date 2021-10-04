using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapaiManager : MonoBehaviour
{
    public List<string> successlist = new List<string>();
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
            successlist.Clear();
            successlist.Add("1");
            successlist.Add("2");
            successlist.Add("3");
        }
        if (gameObject.scene.name == "13")
        {
            liucheng = 1;
            successlist.Clear();
            successlist.Add("4");
            successlist.Add("5");
            successlist.Add("6");
        }
        if (gameObject.scene.name == "21")
        {
            liucheng = 2;
            successlist.Clear();
            successlist.Add("7");
            successlist.Add("8");
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
        if (successlist.Count==0)
        {
            next.SetActive(true);
            Time.timeScale = 0;
            mask.SetActive(true);
        }
        if (Mathf.Abs(chaihu_1.transform.position.x - anban.transform.position.x) <= 500 &&
Mathf.Abs(chaihu_1.transform.position.y - anban.transform.position.y) <= 100)
        {
            if (successlist.Contains(chaihu_1.name))
            {
                as_dui.Play();
                count++;
                AddPos(chaihu_11, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == chaihu_1.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(chaihu_11, count);
                    chaihu_11.SetActive(true);
                    chaihu_1.SetActive(false);
                }
                do1 = true;
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
            if (successlist.Contains(huagnqin_2.name))
            {
                as_dui.Play();
                count++;
                AddPos(huagnqin_22, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == huagnqin_2.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(huagnqin_22, count);
                    huagnqin_22.SetActive(true);
                    huagnqin_2.SetActive(false);
                }
                do2 = true;
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
            if (successlist.Contains(dangshen_3.name))
            {
                as_dui.Play();
                count++;
                AddPos(dangshen_33, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == dangshen_3.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(dangshen_33, count);
                    dangshen_33.SetActive(true);
                    dangshen_3.SetActive(false);
                }
                do3 = true;
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
            if (successlist.Contains(renshen_4.name))
            {
                as_dui.Play();
                count++;
                AddPos(renshen_44, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == renshen_4.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(renshen_44, count);
                    renshen_44.SetActive(true);
                    renshen_4.SetActive(false);
                }
                do4 = true;
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
            if (successlist.Contains(baishu_5.name))
            {
                as_dui.Play();
                count++;
                AddPos(baishu_55, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == baishu_5.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(baishu_55, count);
                    baishu_55.SetActive(true);
                    baishu_5.SetActive(false);
                }
                do5 = true;
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
            if (successlist.Contains(fuling_6.name))
            {
                as_dui.Play();
                count++;
                AddPos(fuling_66, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == fuling_6.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(fuling_66, count);
                    fuling_66.SetActive(true);
                    fuling_6.SetActive(false);
                }
                do6 = true;
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
            if (successlist.Contains(danggui_7.name))
            {
                as_dui.Play();
                count++;
                AddPos(danggui_77, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == danggui_7.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(danggui_77, count);
                    danggui_77.SetActive(true);
                    danggui_7.SetActive(false);
                }
                do7 = true;
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
            if (successlist.Contains(dihuang_8.name))
            {
                as_dui.Play();
                count++;
                AddPos(dihuang_88, count);
                int index = -1;
                for (int i = 0; i < successlist.Count; i++)
                {
                    if (successlist[i] == dihuang_8.name)
                    {
                        index = i;
                    }
                }
                successlist.RemoveAt(index);
                if (index != -1)
                {
                    dui.SetActive(true);
                    cuo.SetActive(false);
                    AddPos(dihuang_88, count);
                    dihuang_88.SetActive(true);
                    dihuang_8.SetActive(false);
                }
                do8 = true;
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
