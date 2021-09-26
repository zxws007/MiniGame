using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Movewash : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public GameObject yaocao1;
    public GameObject dangguijinzhi;
    public static bool pengzhuang = false;
    void Start()
    {
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        dangguijinzhi.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (pengzhuang)
        {
            dangguijinzhi.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "shaizi")
        {
            pengzhuang = true;
        }
    }
}
