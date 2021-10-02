using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movekapai : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    static List<string> successList = new List<string>();
    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public GameObject yaocao1;
    public static bool isOK = false;
    public GameObject chaihu_1;
    public GameObject huagnqin_2;
    public GameObject dangshen_3;
    public GameObject renshen_4;
    public GameObject baishu_5;
    public GameObject fuling_6;
    public GameObject danggui_7;
    public GameObject dihuang_8;
    private Vector3 beginTrans;
    public static int count = 0;
    public GameObject dui;
    public GameObject cuo;
    public static bool pengzhuagn = false;
    public int liucheng = 0;
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
    public GameObject next;
    public GameObject mask;
    void Start()
    {
        if (gameObject.scene.name == "05")
        {
            liucheng = 0;
            successList.Clear();
        }
        if (gameObject.scene.name == "13")
        {
            liucheng = 1;
            successList.Clear();
        }
        if (gameObject.scene.name == "21")
        {
            liucheng = 2;
            successList.Clear();
        }
        beginTrans = gameObject.transform.position;
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        chaihu_1.SetActive(false);
        huagnqin_2.SetActive(false);
        dangshen_3.SetActive(false);
        renshen_4.SetActive(false);
        baishu_5.SetActive(false);
        fuling_6.SetActive(false);
        danggui_7.SetActive(false);
        dihuang_8.SetActive(false);
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
    void Update()
    {
        if (liucheng == 0 && add)
        {
            count = 0;
            hongdui1.SetActive(false);
            hongdui2.SetActive(false);
            hongdui3.SetActive(false);
            xiaochaihutang.SetActive(true);
            hongquan3.SetActive(true);
            if (!successList.Contains("1"))
            {
                successList.Add("1");
            }
            if (!successList.Contains("2"))
            {
                successList.Add("2");
            }
            if (!successList.Contains("3"))
            {
                successList.Add("3");
            }
            add = false;
        }
        if (liucheng == 1 && add)
        {
            // SceneManager.LoadScene(5);
            count = 0;
            hongdui1.SetActive(false);
            hongdui2.SetActive(false);
            hongdui3.SetActive(false);
            baizhusan.SetActive(true);
            hongquan3.SetActive(true);
            if (!successList.Contains("4"))
            {
                successList.Add("4");
            }
            if (!successList.Contains("5"))
            {
                successList.Add("5");
            }
            if (!successList.Contains("6"))
            {
                successList.Add("6");
            }
            add = false;
        }
        if (liucheng == 2 && add)
        {
            count = 0;
            hongdui1.SetActive(false);
            hongdui2.SetActive(false);
            hongdui3.SetActive(false);
            siwutang.SetActive(true);
            hongquan3.SetActive(false);
            hongquan2.SetActive(true);
            if (!successList.Contains("7"))
            {
                successList.Add("7");
            }
            if (!successList.Contains("8"))
            {
                successList.Add("8");
            }
            add = false;
        }
        if (successList.Count == 0 && liucheng == 0)
        {
            next.SetActive(true);
            Time.timeScale = 0;
            mask.SetActive(true);
            add = true;
        }
        if (successList.Count == 0 && liucheng == 1)
        {
            next.SetActive(true);
            Time.timeScale = 0;
            mask.SetActive(true);
            add = true;
        }
        if (successList.Count == 0 && liucheng == 2)
        {
            next.SetActive(true);
            Time.timeScale = 0;
            mask.SetActive(true);
            add = true;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().enabled = false;
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
        Kapai.tuodongfalse = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
        Kapai.tuodongfalse = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.transform.position = beginTrans;
        Kapai.tuodongfalse = true;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "shaizi")
        {
            pengzhuagn = true;
            if (gameObject.name == "1")
            {
                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(chaihu_1, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(chaihu_1, count);
                        chaihu_1.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
            if (gameObject.name == "2")
            {
                pengzhuagn = true;

                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(huagnqin_2, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(huagnqin_2, count);
                        huagnqin_2.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
            if (gameObject.name == "3")
            {
                pengzhuagn = true;

                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(dangshen_3, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(dangshen_3, count);
                        dangshen_3.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
            if (gameObject.name == "4")
            {
                pengzhuagn = true;

                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(renshen_4, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(renshen_4, count);
                        renshen_4.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
            if (gameObject.name == "5")
            {
                pengzhuagn = true;

                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(baishu_5, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(baishu_5, count);
                        baishu_5.SetActive(true);
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("fail" + index);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
            if (gameObject.name == "6")
            {
                pengzhuagn = true;

                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(fuling_6, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(fuling_6, count);
                        fuling_6.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
            if (gameObject.name == "7")
            {
                pengzhuagn = true;

                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(danggui_7, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(danggui_7, count);
                        danggui_7.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
            if (gameObject.name == "8")
            {
                pengzhuagn = true;

                if (successList.Contains(gameObject.name))
                {
                    as_dui.Play();
                    count++;
                    AddPos(dihuang_8, count);
                    int index = -1;
                    for (int i = 0; i < successList.Count; i++)
                    {
                        if (successList[i] == gameObject.name)
                        {
                            index = i;
                        }
                    }
                    successList.RemoveAt(index);
                    if (index != -1)
                    {
                        Debug.Log(successList.Count);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(dihuang_8, count);
                        dihuang_8.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    as_cuo.Play();
                    cuo.SetActive(true);
                    dui.SetActive(false);
                    gameObject.transform.position = beginTrans;
                }
            }
        }
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
}
