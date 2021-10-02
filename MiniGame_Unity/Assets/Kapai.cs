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
        Bamai.my_longPressTime = 0.5f;
        myButton1.OnLongPress.AddListener(() =>
        {
            animatorEnter.SetBool("IsUp", true);
            animatorEnter.SetBool("IsDown", false);
            isDown = true;
            StartCoroutine(Wait());
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
        if (tuodongfalse)
        {
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
            text.text = "和解表里，疏肝，升阳。用于感冒发热，寒热往来，胸胁胀痛，月经不调，子官脱垂，脱肛";
        }
        if (_gameObject.name == "2")
        {
            text.text = "泻实火，除湿热，止血，安胎。治壮热烦渴，肺热咳嗽，湿热泻痢，黄疸，热淋，吐、衄、崩、漏，目赤肿痛，胎动不安，痈肿疔疮";
        }
        if (_gameObject.name == "3")
        {
            text.text = "补中益气，健脾益肺。用于脾肺虚弱，气短心悸，食少便溏，虚喘咳嗽，内热消渴";
        }
        if (_gameObject.name == "4")
        {
            text.text = "补气，固脱，生津，安神，益智。用于气短喘促，心悸健忘，口渴多汗，食少无力，一切急慢性疾病及失血后引起的休克、虚脱";
        }
        if (_gameObject.name == "5")
        {
            text.text = "补脾，益胃，燥湿，和中，安胎。治脾胃气弱，不思饮食，倦怠少气，虚胀，泄泻，痰饮，水肿，黄疸，湿痹，小便不利，头晕，自汗，胎气不安";
        }
        if (_gameObject.name == "6")
        {
            text.text = "利水渗湿，健脾宁心。用于水肿尿少，痰饮眩悸，脾虚食少，便溏泄泻，心神不安，惊悸失眠";
        }
        if (_gameObject.name == "7")
        {
            text.text = "补血和血，调经止痛，润燥滑肠。治月经不调，经闭腹痛，症瘕结聚，崩漏；血虚头痛，眩晕，痿痹；肠燥便难，赤痢后重；痈疽疮窃，跌扑损伤";
        }
        if (_gameObject.name == "8")
        {
            text.text = "滋阴，补血。治阴虚血少，腰膝痿弱，劳嗽骨蒸，遗精，崩漏，月经不调，消渴，溲数，耳聋，目昏";
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        tuodongfalse = false;
        tishi.SetActive(true);
        ChangeText(gameObject);
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
