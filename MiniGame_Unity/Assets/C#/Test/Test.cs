using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    public Bamai myButton1;
    public Bamai myButton2;
    public Bamai myButton3;

    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    public Text text;
    public GameObject texts;
    public GameObject textzt;
    public GameObject xdt;
    public GameObject img;
    float time = .0f;
    float tishitime = .0f;
    int i = 0;
    float sucesstime = .0f;
    public GameObject tiaozhegn1;
    public GameObject tiaozhegn2;
    public GameObject tiaozhegn3;
    public Slider slider;
    public GameObject wanchegn;
    bool jieshu = false;
    public Text debug;
    public GameObject btn;
    public GameObject mask;
    void Start()
    {
        if (gameObject.scene.name == "03")
        {
            //do something
        }
        Input.multiTouchEnabled = true;
        myButton1.OnLongPress.AddListener(() =>
        {
            Debug.Log(" myButton.OnLongPress1");
            b1 = true;
        });
        myButton2.OnLongPress.AddListener(() =>
        {
            Debug.Log(" myButton.OnLongPress2");
            b2 = true;
        });
        myButton3.OnLongPress.AddListener(() =>
        {
            Debug.Log(" myButton.OnLongPress3");
            b3 = true;
        });
    }

    void Update()
    {
        debug.text = "" + Input.touchCount;
        if (!Bamai.isp)
        {
            b1 = b2 = b3 = false;
            text.enabled = true;
        }
        if (b1 && b2 && b3)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        if (b1 && b2 && b3 && (Bamai.isp && time > 2.0f))
        {
            sucesstime += Time.deltaTime;
            slider.value = sucesstime / 10f;
            xdt.SetActive(true);
            StartCoroutine(Wiat1());
            text.enabled = false;
            img.SetActive(false);
            textzt.SetActive(false);
            texts.SetActive(false);
            tiaozhegn1.SetActive(false);
            tiaozhegn2.SetActive(false);
            tiaozhegn3.SetActive(false);
            tishitime = 0;
            if (slider.value == 1)
            {
                wanchegn.SetActive(true);
                text.text = "";
                xdt.SetActive(false);
                jieshu = true;
                btn.SetActive(true);
                mask.SetActive(true);
            }
        }
        if (!b1 && !b2 && !b3 && Input.GetMouseButton(0) && !Bamai.isp && !jieshu)
        {
            StartCoroutine(CloseText());
            xdt.SetActive(false);
        }
        else if ((b1 && !b2 && !b3) && Bamai.isp)//1
        {
            tiaozhegn1.SetActive(false);
            tiaozhegn2.SetActive(true);
            tiaozhegn3.SetActive(true);

            xdt.SetActive(false);
        }
        else if ((!b1 && b2 && !b3) && Bamai.isp)//2
        {
            tiaozhegn1.SetActive(true);
            tiaozhegn2.SetActive(false);
            tiaozhegn3.SetActive(true);
        }
        else if ((!b1 && !b2 && b3) && Bamai.isp)//3
        {
            tiaozhegn1.SetActive(true);
            tiaozhegn2.SetActive(true);
            tiaozhegn3.SetActive(false);
            xdt.SetActive(false);
        }
        else if ((b1 && !b2 && b3) && Bamai.isp)//13
        {
            tiaozhegn1.SetActive(false);
            tiaozhegn2.SetActive(true);
            tiaozhegn3.SetActive(false);
            xdt.SetActive(false);
        }
        else if ((!b1 && b2 && b3) && Bamai.isp)//23
        {
            tiaozhegn1.SetActive(true);
            tiaozhegn2.SetActive(false);
            tiaozhegn3.SetActive(false);
            xdt.SetActive(false);
        }
        else if ((b1 && b2 && !b3) && Bamai.isp)//13
        {
            tiaozhegn1.SetActive(false);
            tiaozhegn2.SetActive(false);
            tiaozhegn3.SetActive(true);
            xdt.SetActive(false);
        }
        else
        {
            textzt.SetActive(false);
            tishitime += Time.deltaTime;
            if (tishitime > 10.0f)
            {
                img.SetActive(true);
                texts.SetActive(true);
            }
            tiaozhegn1.SetActive(false);
            tiaozhegn2.SetActive(false);
            tiaozhegn3.SetActive(false);
        }
        if (Bamai.isp && slider.value < 1)
        {
            text.enabled = false;
        }
    }
    IEnumerator CloseText()
    {
        yield return new WaitForSeconds(1);
        text.enabled = false;
    }
    public void XYB()
    {
        SceneManager.LoadScene("04");
    }
    public void XYB1()
    {
        SceneManager.LoadScene("12");
    }
    public void XYB2()
    {
        SceneManager.LoadScene("20");
    }
    IEnumerator Wiat1()
    {
        Handheld.Vibrate();
        yield return new WaitForSeconds(1);
    }

}
