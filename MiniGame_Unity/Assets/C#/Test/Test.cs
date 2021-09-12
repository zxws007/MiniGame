using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Bamai myButton1;
    public Bamai myButton2;
    public Bamai myButton3;

    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    public GameObject text;
    public GameObject texts;
    public GameObject textzt;
    public GameObject xdt;
    public GameObject img;
    float time = .0f;
    float tishitime = .0f;
    int i = 0;
    float sucesstime = .0f;
    void Start()
    {
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
        if (!Bamai.isp)
        {
            b1 = b2 = b3 = false;
        }
        time += Time.deltaTime;
        if (b1 && b2 && b3 && Bamai.isp && time > 2.0f)
        {
            time = 0;
            sucesstime += Time.deltaTime;
            xdt.SetActive(true);
            Handheld.Vibrate();
            text.SetActive(false);
            img.SetActive(false);
            textzt.SetActive(false);
            texts.SetActive(false);
            tishitime = 0;
            if (sucesstime >= 10.0f)
            {
                //完成
            }
        }
        else if (!b1 && !b2 && !b3 && Input.GetMouseButton(0) && !Bamai.isp)
        {
            sucesstime = 0;
            text.SetActive(true);
            StartCoroutine(CloseText());
        }
        else if (((b1 && !b2 && !b3) || (!b1 && b2 && !b3) || (!b1 && !b2 && b3) || (b1 && b2 && !b3) || (!b1 && b2 && b3) || (b1 && !b2 && b3)) && Bamai.isp)
        {
            sucesstime = 0;
            text.SetActive(false);
            textzt.SetActive(true);
        }
        else
        {
            sucesstime = 0;
            textzt.SetActive(false);
            tishitime += Time.deltaTime;
            if (tishitime > 10.0f)
            {
                img.SetActive(true);
                texts.SetActive(true);
            }
        }
    }
    IEnumerator CloseText()
    {
        yield return new WaitForSeconds(1);
        text.SetActive(false);
    }
}
