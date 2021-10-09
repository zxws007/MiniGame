using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public int youxiuScore;
    public int lianghaoScore;
    public int yibanScore;
    public static int totleScore = 0;
    public Text score;
    public static int qiesidao = 0;
    public Text shengyu;
    public AudioSource qie;
    public GameObject go;
    public GameObject jiesuan;
    void Awake()
    {
        jiesuan.SetActive(false);
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
        shengyu.text = "剩余切割次数: 4";
    }
    void Start()
    {
        Time.timeScale = 0;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (legnque || qiesidao == 4)
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
            g.transform.localPosition = new Vector3(1980, 650, 0);
            g.transform.parent = yao.transform;
            if (DaoPanding.success && qiesidao != 4)
            {
                qiesidao++;
                Debug.Log("ok");
                youxiu.SetActive(true);
                lianghao.SetActive(false);
                putong.SetActive(false);
                totleScore += youxiuScore;
                qie.Play();
            }
            else if (DaoPanding.lianghao && qiesidao != 4)
            {
                qiesidao++;
                Debug.Log("lh");
                youxiu.SetActive(false);
                lianghao.SetActive(true);
                putong.SetActive(false);
                totleScore += lianghaoScore;
                qie.Play();
            }
            else if (DaoPanding.yiban && qiesidao != 4)
            {
                qiesidao++;
                Debug.Log("yb");
                youxiu.SetActive(false);
                lianghao.SetActive(false);
                putong.SetActive(true);
                totleScore += yibanScore;
                qie.Play();
            }
            score.text = "分数： " + totleScore;
            shengyu.text = "剩余切割次数: " + (4 - qiesidao);
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
    public void Go()
    {
        Time.timeScale = 1;
        go.SetActive(false);
    }
    public void Move07()
    {
        GlobalScore.Instance.Score1 = GlobalScore.Instance.Score1 + totleScore;
        SceneManager.LoadSceneAsync("07");
    }
    public void Move07again()
    {
        SceneManager.LoadSceneAsync(gameObject.scene.name);
    }
}
