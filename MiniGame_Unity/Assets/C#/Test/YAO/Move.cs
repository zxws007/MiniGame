using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Move : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public GameObject yaocao1;
    public static bool isOK = false;
    public GameObject jiantou;
    public GameObject huagndong;
    Vector3 startPos = Vector3.zero;
    void Start()
    {
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        startPos = gameObject.transform.position;
        isOK = false;
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
        if (Mathf.Abs(gameObject.transform.position.x - yaocao1.transform.position.x) <= 100f &&
            Mathf.Abs(gameObject.transform.position.y - yaocao1.transform.position.y) <= 100f)
        {
            isOK = true;
            yaocao1.SetActive(true);
            gameObject.SetActive(false);
            jiantou.SetActive(false);
            huagndong.SetActive(true);
        }
        else
        {
            gameObject.transform.position = startPos;
            Debug.Log("1");
        }
    }
}
