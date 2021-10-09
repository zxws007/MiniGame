using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zhizhen : MonoBehaviour
{
    public static bool shiji = false;
    public static bool lh = false;
    public static bool pt = false;
    public static bool anxia = false;
    public Animator zhizhen;
    public static bool begin = false;
    public float time = .0f;
    public static bool taiqi = false;
    public GameObject youxiu;
    public GameObject lianghao;
    public GameObject putong;
    public GameObject lss;
    public static int totalscore = 0;
    bool timeb = false;
    float timef = .0f;
    public Text text;
    bool debug = false;
    void Start()
    {
        zhizhen.speed = 0;
        anxia = false;
        begin = false;
        taiqi = false;
        totalscore = 0;
        timef = 0;
        timeb = false;
        pt = false;
        shiji = false;
        lh = false;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "shaizi")
        {
            shiji = true;
            lh = false;
            pt = false;
        }
        else if (coll.gameObject.tag == "Finish")
        {
            lh = true;
            shiji = false;
            pt = false;
        }
        else if (coll.gameObject.tag == "Respawn")
        {
            pt = true;
            shiji = false;
            lh = false;
        }
        Debug.Log("yx " + shiji);
        //Debug.Log("lh " + lh);
        //Debug.Log("pt " + pt);
    }
    void Update()
    {
        if (anxia && Movewash.pengzhuang && !taiqi)
        {
            time += Time.deltaTime;
            zhizhen.speed = 1;
            timeb = true;
        }
        if (pt && taiqi)
        {
            totalscore += 5;
            zhizhen.speed = 0;
            putong.SetActive(true);
            StartCoroutine(Wait());
            anxia = false;
            pt = false;
        }
        if (shiji && taiqi)
        {
            totalscore += 10;
            zhizhen.speed = 0;
            youxiu.SetActive(true);
            lss.SetActive(true);
            StartCoroutine(Wait());
            anxia = false;
            shiji = false;
        }
        if (lh && taiqi)
        {
            totalscore += 8;
            zhizhen.speed = 0;
            lianghao.SetActive(true);
            StartCoroutine(Wait());
            anxia = false;
            lh = false;
        }
        taiqi = false;
        anxia = false;
        if (timeb)
        {
            timef += Time.deltaTime;
            if (timef > 8.8f)
            {
                Moveanniu.qzjs = true;
                debug = true;
            }
            if (!debug)
            {
                text.text = timef + "";
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        youxiu.SetActive(false);
        lianghao.SetActive(false);
        putong.SetActive(false);
    }

}
