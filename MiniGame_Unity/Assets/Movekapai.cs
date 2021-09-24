using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movekapai : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

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
    private int count = 0;
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
    }
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().enabled = false;
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.transform.position = beginTrans;
        Debug.Log(gameObject.transform.position);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "shaizi")
        {
            if (gameObject.name == "1")
            {
                chaihu_1.SetActive(true);
                gameObject.SetActive(false);
                count++;
                AddPos(chaihu_1, count);
            }
            if (gameObject.name == "2")
            {
                huagnqin_2.SetActive(true);
                gameObject.SetActive(false);
                count++;
                AddPos(huagnqin_2, count);
            }
            if (gameObject.name == "4")
            {
                renshen_4.SetActive(true);
                gameObject.SetActive(false);
                count++;
                AddPos(renshen_4, count);
            }
            if (gameObject.name == "5")
            {
                baishu_5.SetActive(true);
                gameObject.SetActive(false);
                count++;
                AddPos(baishu_5, count);
            }
            if (gameObject.name == "6")
            {
                fuling_6.SetActive(true);
                gameObject.SetActive(false);
                count++;
                AddPos(fuling_6, count);
            }
            if (gameObject.name == "7")
            {
                danggui_7.SetActive(true);
                gameObject.SetActive(false);
                count++;
                AddPos(danggui_7, count);
            }
            if (gameObject.name == "8")
            {
                dihuang_8.SetActive(true);
                gameObject.SetActive(false);
                count++;
                AddPos(dihuang_8, count);
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
            _gameObject.transform.position = new Vector3(0, 0, 0);
        }
        else if (index == 3)
        {
            _gameObject.transform.position = new Vector3(30, 0, 0);
        }
    }
}
