using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhizhen : MonoBehaviour
{
    public bool shiji = false;
    public static bool anxia = false;
    public Animator zhizhen;
    public static bool begin = false;
    public float time = .0f;
    public static bool taiqi = false;
    public GameObject youxiu;
    public GameObject lianghao;
    public GameObject putong;

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
    }
    void Update()
    {
        if (anxia && Movewash.pengzhuang)
        {
            time += Time.deltaTime;
            zhizhen.speed = 1;
        }
        if (!shiji && taiqi)
        {
            Debug.Log("no");
            zhizhen.speed = 0;
        }
        if (shiji && taiqi)
        {
            Debug.Log("ok");
            zhizhen.speed = 0;
            youxiu.SetActive(true);
            StartCoroutine(Wait());
        }
        taiqi = false;
        anxia = false;
        shiji = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        youxiu.SetActive(false);
        lianghao.SetActive(false);
        putong.SetActive(false);
    }

}
