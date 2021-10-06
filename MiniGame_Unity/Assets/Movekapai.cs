using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movekapai : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    static List<string> successList = new List<string>();
    private RawImage img;
    Vector3 offsetPos; //存储按下鼠标时的图片-鼠标位置差
    public GameObject yaocao1;
    public static bool isOK = false;
    public GameObject chaihu_1;
    public GameObject huagnqin_2;
    public GameObject dangshen_3;
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
    public int liucheng = 0;
    public GameObject xiaochaihutang;
    public GameObject baizhusan;
    public GameObject siwutang;
    bool add = true;
    public GameObject hongdui1;
    public GameObject hongdui2;
    public GameObject hongdui3;
    public GameObject hongquan3;
    public GameObject hongquan2;
    public AudioSource as_dui;
    public AudioSource as_cuo;
    public GameObject next;
    public GameObject mask;
    public GameObject anban;
    public GameObject tishi;
    public Text text;
    void Start()
    {
        if (gameObject.scene.name == "05")
        {
            liucheng = 0;
            successList.Clear();
        }
        if (gameObject.scene.name == "13")
        {
            liucheng = 1;
            successList.Clear();
        }
        if (gameObject.scene.name == "21")
        {
            liucheng = 2;
            if (!successList.Contains("7"))
            {
                successList.Add("7");

            }
            if (!successList.Contains("8"))
            {
                successList.Add("8");

            }
        }
        beginTrans = gameObject.transform.position;
        img = GetComponent<RawImage>();//获取图片，因为我们要获取他的RectTransform
        chaihu_1.SetActive(false);
        huagnqin_2.SetActive(false);
        dangshen_3.SetActive(false);
        renshen_4.SetActive(false);
        baishu_5.SetActive(false);
        fuling_6.SetActive(false);
        danggui_7.SetActive(false);
        dihuang_8.SetActive(false);
        dui.SetActive(false);
        cuo.SetActive(false);
        xiaochaihutang.SetActive(false);
        baizhusan.SetActive(false);
        siwutang.SetActive(false);
        hongquan3.SetActive(false);
        hongquan2.SetActive(false);
        hongdui1.SetActive(false);
        hongdui2.SetActive(false);
        hongdui3.SetActive(false);
    }
    void Update()
    {
        if (liucheng == 0 && add)
        {
            count = 0;
            hongdui1.SetActive(false);
            hongdui2.SetActive(false);
            hongdui3.SetActive(false);
            xiaochaihutang.SetActive(true);
            hongquan3.SetActive(true);
            if (!successList.Contains("1"))
            {
                successList.Add("1");
            }
            if (!successList.Contains("2"))
            {
                successList.Add("2");
            }
            if (!successList.Contains("3"))
            {
                successList.Add("3");
            }
            add = false;
        }

        if (liucheng == 1 && add)
        {
            // SceneManager.LoadSceneAsync(5);
            count = 0;
            hongdui1.SetActive(false);
            hongdui2.SetActive(false);
            hongdui3.SetActive(false);
            baizhusan.SetActive(true);
            hongquan3.SetActive(true);
            if (!successList.Contains("4"))
            {
                successList.Add("4");
            }
            if (!successList.Contains("5"))
            {
                successList.Add("5");
            }
            if (!successList.Contains("6"))
            {
                successList.Add("6");
            }
            add = false;
        }
        if (liucheng == 2 && add)
        {
            count = 0;
            hongdui1.SetActive(false);
            hongdui2.SetActive(false);
            hongdui3.SetActive(false);
            siwutang.SetActive(true);
            hongquan3.SetActive(false);
            hongquan2.SetActive(true);
            add = false;
        }
        if (successList.Count == 0 && liucheng == 0)
        {
            next.SetActive(true);
            Time.timeScale = 0;
            mask.SetActive(true);
            add = true;
        }
        if (successList.Count == 0 && liucheng == 1)
        {
            next.SetActive(true);
            Time.timeScale = 0;
            mask.SetActive(true);
            add = true;
        }
        if (successList.Count == 0 && liucheng == 2)
        {
            next.SetActive(true);
            Time.timeScale = 0;
            mask.SetActive(true);
            add = true;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().enabled = false;
        //将鼠标的位置坐标进行钳制，然后加上位置差再赋值给图片position
        img.rectTransform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height), 0) + offsetPos;
        //Kapai.tuodongfalse = true;
        tishi.SetActive(true);
        ChangeText(gameObject);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        offsetPos = img.rectTransform.position - Input.mousePosition;
        Kapai.tuodongfalse = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.transform.position = beginTrans;
        tishi.SetActive(false);
    }
    void ChangeText(GameObject _gameObject)
    {
        if (_gameObject.name == "1")
        {
            text.text = "用于感冒<color=#ff0000>发热</color>，<color=#ff0000>寒热往来</color>，胸胁胀痛";
        }
        if (_gameObject.name == "2")
        {
            text.text = "用于壮热烦渴，肺热咳嗽，<color=#ff0000>湿热泻痢</color>，<color=#ff0000>吐</color>、崩、<color=#ff0000>目赤肿痛</color>";
        }
        if (_gameObject.name == "3")
        {
            text.text = "用于<color=#ff0000>脾虚湿盛</color>，气短心悸，<color=#ff0000>食欲不振</color>，食少便溏，虚喘咳嗽，内热消渴";
        }
        if (_gameObject.name == "4")
        {
            text.text = "用于气短喘促，心悸健忘，口渴多汗，<color=#ff0000>食少无力</color>，一切急慢性疾病及失血后引起的<color=#ff0000>休克</color>、<color=#ff0000>虚脱</color>";
        }
        if (_gameObject.name == "5")
        {
            text.text = "用于<color=#ff0000>脾胃虚弱</color>，<color=#ff0000>不思饮食</color>，<color=#ff0000>泄泻</color>，<color=#ff0000>水肿</color>，自汗";
        }
        if (_gameObject.name == "6")
        {
            text.text = "用于水肿尿少，痰饮眩悸，<color=#ff0000>脾虚食少</color>，便溏<color=#ff0000>泄泻</color>";
        }
        if (_gameObject.name == "7")
        {
            text.text = "用于<color=#ff0000>月经不调</color>，经闭<color=#ff0000>腹痛</color>，血虚<color=#ff0000>头痛</color>，<color=#ff0000>眩晕</color>，痿痹";
        }
        if (_gameObject.name == "8")
        {
            text.text = "用于<color=#ff0000>阴虚血少</color>，<color=#ff0000>气血不足</color>，<color=#ff0000>月经不调</color>，消渴，耳聋";
        }
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //        Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //    {
    //        pengzhuagn = true;
    //        if (gameObject.name == "1")
    //        {
    //            if (successList.Contains(gameObject.name))
    //            {
    //                as_dui.Play();
    //                count++;
    //                AddPos(chaihu_1, count);
    //                int index = -1;
    //                for (int i = 0; i < successList.Count; i++)
    //                {
    //                    if (successList[i] == gameObject.name)
    //                    {
    //                        index = i;
    //                    }
    //                }
    //                successList.RemoveAt(index);
    //                if (index != -1)
    //                {
    //                    Debug.Log(successList.Count);
    //                    dui.SetActive(true);
    //                    cuo.SetActive(false);
    //                    AddPos(chaihu_1, count);
    //                    chaihu_1.SetActive(true);
    //                    gameObject.SetActive(false);
    //                }
    //            }
    //            else
    //            {
    //                as_cuo.Play();
    //                cuo.SetActive(true);
    //                dui.SetActive(false);
    //                gameObject.transform.position = beginTrans;
    //            }
    //        }
    //        else if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //            Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //        {
    //            pengzhuagn = true;
    //            if (gameObject.name == "2")
    //            {
    //                if (successList.Contains(gameObject.name))
    //                {
    //                    as_dui.Play();
    //                    count++;
    //                    AddPos(huagnqin_2, count);
    //                    int index = -1;
    //                    for (int i = 0; i < successList.Count; i++)
    //                    {
    //                        if (successList[i] == gameObject.name)
    //                        {
    //                            index = i;
    //                        }
    //                    }
    //                    successList.RemoveAt(index);
    //                    Debug.Log(index);

    //                    if (index != -1)
    //                    {
    //                        Debug.Log(successList.Count);
    //                        dui.SetActive(true);
    //                        cuo.SetActive(false);
    //                        AddPos(huagnqin_2, count);
    //                        huagnqin_2.SetActive(true);
    //                        gameObject.SetActive(false);
    //                    }
    //                }
    //                else
    //                {
    //                    as_cuo.Play();
    //                    cuo.SetActive(true);
    //                    dui.SetActive(false);
    //                    gameObject.transform.position = beginTrans;
    //                }

    //            }
    //        }
    //        else if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //            Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //        {
    //            pengzhuagn = true;
    //            if (successList.Contains(gameObject.name))
    //            {
    //                as_dui.Play();
    //                count++;
    //                AddPos(dangshen_3, count);
    //                int index = -1;
    //                for (int i = 0; i < successList.Count; i++)
    //                {
    //                    if (successList[i] == gameObject.name)
    //                    {
    //                        index = i;
    //                    }
    //                }
    //                Debug.Log(index);
    //                successList.RemoveAt(index);
    //                if (index != -1)
    //                {
    //                    Debug.Log(successList.Count);
    //                    dui.SetActive(true);
    //                    cuo.SetActive(false);
    //                    AddPos(dangshen_3, count);
    //                    dangshen_3.SetActive(true);
    //                    gameObject.SetActive(false);
    //                }
    //            }
    //            else
    //            {
    //                as_cuo.Play();
    //                cuo.SetActive(true);
    //                dui.SetActive(false);
    //                gameObject.transform.position = beginTrans;
    //            }

    //        }
    //        else if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //            Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //        {
    //            pengzhuagn = true;

    //            if (successList.Contains(gameObject.name))
    //            {
    //                as_dui.Play();
    //                count++;
    //                AddPos(renshen_4, count);
    //                int index = -1;
    //                for (int i = 0; i < successList.Count; i++)
    //                {
    //                    if (successList[i] == gameObject.name)
    //                    {
    //                        index = i;
    //                    }
    //                }
    //                successList.RemoveAt(index);
    //                if (index != -1)
    //                {
    //                    Debug.Log(successList.Count);
    //                    dui.SetActive(true);
    //                    cuo.SetActive(false);
    //                    AddPos(renshen_4, count);
    //                    renshen_4.SetActive(true);
    //                    gameObject.SetActive(false);
    //                }
    //            }
    //            else
    //            {
    //                as_cuo.Play();
    //                cuo.SetActive(true);
    //                dui.SetActive(false);
    //                gameObject.transform.position = beginTrans;
    //            }
    //        }
    //        else if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //            Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //        {
    //            pengzhuagn = true;

    //            if (successList.Contains(gameObject.name))
    //            {
    //                as_dui.Play();
    //                count++;
    //                AddPos(baishu_5, count);
    //                int index = -1;
    //                for (int i = 0; i < successList.Count; i++)
    //                {
    //                    if (successList[i] == gameObject.name)
    //                    {
    //                        index = i;
    //                    }
    //                }
    //                successList.RemoveAt(index);
    //                if (index != -1)
    //                {
    //                    Debug.Log(successList.Count);
    //                    dui.SetActive(true);
    //                    cuo.SetActive(false);
    //                    AddPos(baishu_5, count);
    //                    baishu_5.SetActive(true);
    //                    gameObject.SetActive(false);
    //                }
    //                else
    //                {
    //                    Debug.Log("fail" + index);
    //                }
    //            }
    //            else
    //            {
    //                as_cuo.Play();
    //                cuo.SetActive(true);
    //                dui.SetActive(false);
    //                gameObject.transform.position = beginTrans;
    //            }
    //        }
    //        else if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //           Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //        {
    //            pengzhuagn = true;

    //            if (successList.Contains(gameObject.name))
    //            {
    //                as_dui.Play();
    //                count++;
    //                AddPos(fuling_6, count);
    //                int index = -1;
    //                for (int i = 0; i < successList.Count; i++)
    //                {
    //                    if (successList[i] == gameObject.name)
    //                    {
    //                        index = i;
    //                    }
    //                }
    //                successList.RemoveAt(index);
    //                if (index != -1)
    //                {
    //                    Debug.Log(successList.Count);
    //                    dui.SetActive(true);
    //                    cuo.SetActive(false);
    //                    AddPos(fuling_6, count);
    //                    fuling_6.SetActive(true);
    //                    gameObject.SetActive(false);
    //                }
    //            }
    //            else
    //            {
    //                as_cuo.Play();
    //                cuo.SetActive(true);
    //                dui.SetActive(false);
    //                gameObject.transform.position = beginTrans;
    //            }
    //        }
    //        else if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //            Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //        {
    //            pengzhuagn = true;
    //            if (gameObject.name == "7")
    //            {
    //                if (successList.Contains(gameObject.name))
    //                {
    //                    as_dui.Play();
    //                    count++;
    //                    AddPos(danggui_7, count);
    //                    int index = -1;
    //                    for (int i = 0; i < successList.Count; i++)
    //                    {
    //                        if (successList[i] == gameObject.name)
    //                        {
    //                            index = i;
    //                        }
    //                    }
    //                    successList.RemoveAt(index);
    //                    if (index != -1)
    //                    {
    //                        Debug.Log(successList.Count);
    //                        dui.SetActive(true);
    //                        cuo.SetActive(false);
    //                        AddPos(danggui_7, count);
    //                        danggui_7.SetActive(true);
    //                        gameObject.SetActive(false);
    //                    }
    //                }
    //                else
    //                {
    //                    as_cuo.Play();
    //                    cuo.SetActive(true);
    //                    dui.SetActive(false);
    //                    gameObject.transform.position = beginTrans;
    //                }

    //            }

    //        }
    //        else if (Mathf.Abs(gameObject.transform.position.x - anban.transform.position.x) <= 500 &&
    //            Mathf.Abs(gameObject.transform.position.y - anban.transform.position.y) <= 200)
    //        {
    //            pengzhuagn = true;
    //            if (gameObject.name == "8")
    //            {
    //                if (successList.Contains(gameObject.name))
    //                {
    //                    as_dui.Play();
    //                    count++;
    //                    AddPos(dihuang_8, count);
    //                    int index = -1;
    //                    for (int i = 0; i < successList.Count; i++)
    //                    {
    //                        if (successList[i] == gameObject.name)
    //                        {
    //                            index = i;
    //                        }
    //                    }
    //                    successList.RemoveAt(index);
    //                    if (index != -1)
    //                    {
    //                        Debug.Log(successList.Count);
    //                        dui.SetActive(true);
    //                        cuo.SetActive(false);
    //                        AddPos(dihuang_8, count);
    //                        dihuang_8.SetActive(true);
    //                        gameObject.SetActive(false);
    //                    }
    //                }
    //                else
    //                {
    //                    as_cuo.Play();
    //                    cuo.SetActive(true);
    //                    dui.SetActive(false);
    //                    gameObject.transform.position = beginTrans;
    //                }
    //            }

    //        }
    //    }
    //}
    void AddPos(GameObject _gameObject, int index)
    {
        if (index == 1)
        {
            _gameObject.transform.localPosition = new Vector3(-325, 0, 0);
            hongdui1.SetActive(true);
        }
        else if (index == 2)
        {
            _gameObject.transform.localPosition = new Vector3(0, 0, 0);
            hongdui2.SetActive(true);
        }
        else if (index == 3)
        {
            _gameObject.transform.localPosition = new Vector3(325, 0, 0);
            hongdui3.SetActive(true);
        }
    }
}
