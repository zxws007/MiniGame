using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        zhizhen.speed = 0;
        anxia = false;
        begin = false;
        taiqi = false;
        totalscore = 0;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        shiji = false;
        lh = false;
        pt = false;
        if (coll.gameObject.tag == "shaizi")
        {
            shiji = true;
        }
        if (coll.gameObject.tag == "Finish")
        {
            lh = true;
        }
        if (coll.gameObject.tag == "Respawn")
        {
            pt = true;
        }
    }
    void Update()
    {
        if (anxia && Movewash.pengzhuang && !taiqi)
        {
            time += Time.deltaTime;
            zhizhen.speed = 1;
        }
        if (pt && taiqi)
        {
            totalscore += 5;
            zhizhen.speed = 0;
            putong.SetActive(true);
            StartCoroutine(Wait());
            anxia = false;
        }
        if (shiji && taiqi)
        {
            totalscore += 10;
            zhizhen.speed = 0;
            youxiu.SetActive(true);
            lss.SetActive(true);
            StartCoroutine(Wait());
            anxia = false;
        }
        if (lh && taiqi)
        {
            totalscore += 8;
            zhizhen.speed = 0;
            lianghao.SetActive(true);
            StartCoroutine(Wait());
            anxia = false;
        }
        taiqi = false;
        anxia = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        youxiu.SetActive(false);
        lianghao.SetActive(false);
        putong.SetActive(false);
    }

}
