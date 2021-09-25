using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movekapai : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    static List<string> successList = new List<string>() { "1", "2", "4" };
    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public GameObject yaocao1;
    public static bool isOK = false;
    public GameObject chaihu_1;
    public GameObject huagnqin_2;
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
    void Start()
    {
        beginTrans = gameObject.transform.position;
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        chaihu_1.SetActive(false);
        huagnqin_2.SetActive(false);
        renshen_4.SetActive(false);
        baishu_5.SetActive(false);
        fuling_6.SetActive(false);
        danggui_7.SetActive(false);
        dihuang_8.SetActive(false);
        dui.SetActive(false);
        cuo.SetActive(false);
    }
    void Update()
    {
        if (count == 3)
        {
            Debug.Log("结束！");
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
                        Debug.Log(index);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(chaihu_1, count);
                        chaihu_1.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
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
                        Debug.Log(index);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(huagnqin_2, count);
                        huagnqin_2.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
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
                        Debug.Log(index);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(renshen_4, count);
                        renshen_4.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
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
                        Debug.Log(index);
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
                        Debug.Log(index);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(fuling_6, count);
                        fuling_6.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
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
                        Debug.Log(index);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(danggui_7, count);
                        danggui_7.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
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
                        Debug.Log(index);
                        dui.SetActive(true);
                        cuo.SetActive(false);
                        AddPos(dihuang_8, count);
                        dihuang_8.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
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
            _gameObject.transform.localPosition = new Vector3(-30, 0, 0);
        }
        else if (index == 2)
        {
            _gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (index == 3)
        {
            _gameObject.transform.localPosition = new Vector3(30, 0, 0);
        }
    }
}
