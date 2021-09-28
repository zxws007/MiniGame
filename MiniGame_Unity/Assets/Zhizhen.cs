using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhizhen : MonoBehaviour
{
    public bool shiji = false;
    public bool lh = false;
    public bool pt = false;
    public static bool anxia = false;
    public Animator zhizhen;
    public static bool begin = false;
    public float time = .0f;
    public static bool taiqi = false;
    public GameObject youxiu;
    public GameObject lianghao;
    public GameObject putong;
    public GameObject lss;
    void Start()
    {
        zhizhen.speed = 0;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
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
        if (anxia && Movewash.pengzhuang)
        {
            time += Time.deltaTime;
            zhizhen.speed = 1;
        }
        if (pt && taiqi)
        {
            zhizhen.speed = 0;
            putong.SetActive(true);
            StartCoroutine(Wait());
        }
        if (shiji && taiqi)
        {
            zhizhen.speed = 0;
            youxiu.SetActive(true);
            lss.SetActive(true);
            StartCoroutine(Wait());
        }
        if (lh && taiqi)
        {
            zhizhen.speed = 0;
            lianghao.SetActive(true);
            StartCoroutine(Wait());
        }
        taiqi = false;
        anxia = false;
        shiji = false;
        lh = false;
        pt = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        youxiu.SetActive(false);
        lianghao.SetActive(false);
        putong.SetActive(false);
    }

}
