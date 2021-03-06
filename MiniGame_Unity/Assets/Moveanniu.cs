using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moveanniu : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    Vector3 v1 = Vector3.zero;
    Vector3 v2 = Vector3.zero;
    public Animator shui2_anim;
    public static bool change = false;
    float b, bb = .0f;
    int index = 0;
    public GameObject jiesuan;
    public GameObject jiesuan1;
    public GameObject jiesuan2;
    public bool taiqi = false;
    public Bamai bamai;
    public bool changan = false;
    public bool jiesuanb = false;
    Vector3 beginPos;
    bool nochangan = false;
    public static bool sjd = false;
    public static bool qzjs = false;
    public GameObject tub1;
    public GameObject tub2;
    public GameObject tub3;
    void Start()
    {
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        shui2_anim.speed = 0;
        jiesuan.SetActive(false);
        change = false;
        jiesuan2.SetActive(false);
        jiesuan1.SetActive(false);
        Bamai.my_longPressTime = 0.1f;
        changan = false;
        bamai.OnLongPress.AddListener(() =>
        {
            if (!nochangan)
            {
                changan = true;
                Debug.Log("changan");
            }
        });
        beginPos = gameObject.transform.position;
        sjd = false;
        qzjs = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        v2 = img.rectTransform.position;
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
        v1 = img.rectTransform.position;
        if (Zhizhen.begin && Movewash.pengzhuang && !change && changan)
        {
            Zhizhen.anxia = true;
            shui2_anim.speed = 1;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (Movewash.pengzhuang && changan && !jiesuanb && Zhizhen.begin)
        {
            Debug.Log("go");
            Zhizhen.taiqi = true;
            change = true;
            shui2_anim.speed = 0;
            taiqi = true;
            jiesuanb = true;
        }
        gameObject.transform.position = beginPos;
        changan = false;
        nochangan = false;
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "new1" && !jiesuanb && Movewash.pengzhuang && changan && Zhizhen.begin)
        {
            Zhizhen.taiqi = true;
            change = true;
            shui2_anim.speed = 0;
            taiqi = true;
            jiesuanb = true;
        }
        nochangan = true;
    }
    void Update()
    {
        bb = b;
        b = Mathf.Abs(v1.x - v2.x);
        if (Mathf.Abs(b - bb) >= 5 && !change)
        {
            Zhizhen.begin = true;
        }
        if (taiqi)
        {
            if (Zhizhen.totalscore == 10)
            {
                jiesuan.SetActive(true);
            }
            else if (Zhizhen.totalscore == 8)
            {
                jiesuan1.SetActive(true);
            }
            else if (Zhizhen.totalscore == 5)
            {
                jiesuan2.SetActive(true);
            }

        }
        if (qzjs && !jiesuanb)
        {
            Zhizhen.taiqi = true;
            change = true;
            shui2_anim.speed = 0;
            taiqi = true;
            jiesuanb = true;
            jiesuan.SetActive(false);
            jiesuan1.SetActive(false);
            jiesuan2.SetActive(true);
        }
    }
    public void OnClick()
    {
        GlobalScore.Instance.Score3 = GlobalScore.Instance.Score3 + Zhizhen.totalscore;
        SceneManager.LoadSceneAsync("23");//level1为我们要切换到的场景
    }
    public void OnClickagain()
    {
        SceneManager.LoadSceneAsync(gameObject.scene.name);//level1为我们要切换到的场景
    }
}
