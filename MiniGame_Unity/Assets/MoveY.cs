using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class MoveY : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public static bool isOK = false;
    public Vector3 positionY = Vector3.zero;
    public Vector3 beginPos = Vector3.zero;
    bool legnque = false;
    public GameObject dao;
    public GameObject daoidle;
    public GameObject texiao1;
    public GameObject texiao2;
    public GameObject mask;
    public GameObject yao;
    public GameObject pianpian;
    public GameObject youxiu;
    public GameObject lianghao;
    public GameObject putong;
    void Start()
    {
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        beginPos = gameObject.transform.localPosition;
        dao.SetActive(false);
        texiao1.SetActive(false);
        texiao2.SetActive(false);
        mask.SetActive(false);
        pianpian.SetActive(false);
        youxiu.SetActive(false);
        lianghao.SetActive(false);
        putong.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (legnque)
        {
            return;
        }
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        positionY = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
        img.rectTransform.position = new Vector3(img.rectTransform.position.x, positionY.y, 0);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.transform.localPosition = beginPos;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "shaizi")
        {
            legnque = true;
            gameObject.transform.localPosition = beginPos;
            daoidle.GetComponent<Image>().enabled = false;
            dao.SetActive(true);
            daoidle.SetActive(false);
            texiao1.SetActive(true);
            texiao2.SetActive(true);
            pianpian.SetActive(true);
            var g = Instantiate(mask, new Vector3(0, 0, 0), Quaternion.identity);
            g.SetActive(true);
            g.transform.localPosition = new Vector3(2000, 650, 0);
            g.transform.parent = yao.transform;
            if (DaoPanding.success)
            {
                Debug.Log("ok");
                youxiu.SetActive(true);
                lianghao.SetActive(false);
                putong.SetActive(false);
            }
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        legnque = false;
        daoidle.GetComponent<Image>().enabled = true;
        dao.SetActive(false);
        daoidle.SetActive(true);
        texiao1.SetActive(false);
        texiao2.SetActive(false);
        pianpian.SetActive(false);
        youxiu.SetActive(false);
        lianghao.SetActive(false);
        putong.SetActive(false);
    }
}
