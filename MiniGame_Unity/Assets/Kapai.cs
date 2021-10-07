using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kapai : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public Animator animatorEnter;
    public Bamai myButton1;
    private bool isDown = false;
    public GameObject tishi;
    public Text text;
    public static bool tuodongfalse = false;
    public Text daixuan;
    public GameObject dui;
    public GameObject cuo;
    public void OnPointerEnter(PointerEventData eventData)
    {
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
    void Start()
    {
        Bamai.my_longPressTime = 0.1f;
        myButton1.OnLongPress.AddListener(() =>
        {
            animatorEnter.SetBool("IsUp", true);
            animatorEnter.SetBool("IsDown", false);
            isDown = true;
            tuodongfalse = false;
            tishi.SetActive(true);
            ChangeText(gameObject);
        });
        tishi.SetActive(false);
    }
    void Update()
    {
        daixuan.text = string.Format("待选({0}/3)", Movekapai.count);
        if (!Bamai.isp && isDown)
        {
            animatorEnter.SetBool("IsDown", true);
            animatorEnter.SetBool("IsUp", false);
            isDown = false;
            tishi.SetActive(false);
        }
        if (Movekapai.pengzhuagn == true)
        {
            StartCoroutine(WaitClose());
            Movekapai.pengzhuagn = false;
        }
    }
    void ChangeText(GameObject _gameObject)
    {
        if (_gameObject.name == "1")
        {
            text.text = "用于感冒<color=#E07545>发热</color>，<color=#E07545>寒热往来</color>，胸胁胀痛";
        }
        if (_gameObject.name == "2")
        {
            text.text = "用于壮热烦渴，肺热咳嗽，<color=#E07545>湿热泻痢</color>，<color=#E07545>吐</color>、崩、<color=#E07545>目赤肿痛</color>";
        }
        if (_gameObject.name == "3")
        {
            text.text = "用于<color=#E07545>脾虚湿盛</color>，气短心悸，<color=#E07545>食欲不振</color>，食少便溏，虚喘咳嗽，内热消渴";
        }
        if (_gameObject.name == "4")
        {
            text.text = "用于气短喘促，心悸健忘，口渴多汗，<color=#E07545>食少无力</color>，一切急慢性疾病及失血后引起的<color=#E07545>休克</color>、<color=#E07545>虚脱</color>";
        }
        if (_gameObject.name == "5")
        {
            text.text = "用于<color=#E07545>脾胃虚弱</color>，<color=#E07545>不思饮食</color>，<color=#E07545>泄泻</color>，<color=#E07545>水肿</color>，自汗";
        }
        if (_gameObject.name == "6")
        {
            text.text = "用于水肿尿少，痰饮眩悸，<color=#E07545>脾虚食少</color>，便溏<color=#E07545>泄泻</color>";
        }
        if (_gameObject.name == "7")
        {
            text.text = "用于<color=#E07545>月经不调</color>，经闭<color=#E07545>腹痛</color>，血虚<color=#E07545>头痛</color>，<color=#E07545>眩晕</color>，痿痹";
        }
        if (_gameObject.name == "8")
        {
            text.text = "用于<color=#E07545>阴虚血少</color>，<color=#E07545>气血不足</color>，<color=#E07545>月经不调</color>，消渴，耳聋";
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(1f);
        dui.SetActive(false);
        cuo.SetActive(false);
    }
    public void Move06()
    {
        SceneManager.LoadSceneAsync("06");
    }
    public void Move14()
    {
        SceneManager.LoadSceneAsync("14");
    }
    public void Move22()
    {
        SceneManager.LoadSceneAsync("22");
    }
}
