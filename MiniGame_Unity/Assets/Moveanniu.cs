using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Moveanniu : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public bool shuili = false;
    Vector3 v1 = Vector3.zero;
    Vector3 v2 = Vector3.zero;
    void Start()
    {
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
    }
    public void OnDrag(PointerEventData eventData)
    {
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        v2 = img.rectTransform.position;
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
        v1 = img.rectTransform.position;
        if (Zhizhen.begin && Movewash.pengzhuang)
        {
            Zhizhen.anxia = true;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Zhizhen.taiqi = true;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "shaizi")
        {
            shuili = true;
        }
    }
    void Update()
    {
        if (Mathf.Abs(v1.x - v2.y) >= 5)
        {
            Zhizhen.begin = true;
        }
        else
        {
            Zhizhen.begin = false;
        }
    }
}
