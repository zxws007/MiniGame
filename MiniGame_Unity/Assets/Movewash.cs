using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Movewash : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public GameObject yaocao1;
    public GameObject dangguijinzhi;
    public static bool pengzhuang = false;
    public GameObject tishi1;
    public GameObject qipao;
    public GameObject qte;
    public GameObject qte1;
    public GameObject tishi2;
    public GameObject shui;
    public GameObject shui2;
    Vector3 beginPos;
    void Start()
    {
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        dangguijinzhi.SetActive(false);
        beginPos = gameObject.transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
        if (Mathf.Abs(gameObject.transform.position.x - shui.transform.position.x) <= 100f &&
Mathf.Abs(gameObject.transform.position.y - shui.transform.position.y) <= 100f)
        {
            pengzhuang = true;
        }
        if (pengzhuang)
        {
            tishi1.SetActive(false);
            dangguijinzhi.SetActive(true);
            gameObject.SetActive(false);
            qipao.SetActive(true);
            qte.SetActive(true);
            qte1.SetActive(true);
            tishi2.SetActive(true);
            shui.SetActive(false);
            shui2.SetActive(true);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!pengzhuang)
        {
            gameObject.transform.position = beginPos;
        }
    }
}
