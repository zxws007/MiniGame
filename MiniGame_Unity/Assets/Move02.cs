using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move02 : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    int i = 0;
    public GameObject panding;
    public GameObject panding2;
    public GameObject hide;
    public GameObject hide1;
    private Vector3 startPos;
    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    void Start()
    {
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        startPos = gameObject.transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
        //Debug.Log(gameObject.transform.position);
        //Debug.Log(panding.transform.position);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //判定1
        if (i == 0)
        {
            if( (Mathf.Abs(gameObject.transform.position.x - panding.transform.position.x) <= 50f &&
              Mathf.Abs(gameObject.transform.position.y - panding.transform.position.y) <= 50f)
              ||(Mathf.Abs(gameObject.transform.position.x - panding2.transform.position.x) <= 50f &&
              Mathf.Abs(gameObject.transform.position.y - panding2.transform.position.y) <= 50f))
            {

                gameObject.transform.position = panding.transform.position;
                i = 1;
                //hide.SetActive(false);
            }
            else
            {
                gameObject.transform.position = startPos;
                Debug.Log("1");
            }
        }

        if (i == 1)
        {
            Manager02.index++;
            hide1.SetActive(false);
            hide.SetActive(false);
        }
    }

}
