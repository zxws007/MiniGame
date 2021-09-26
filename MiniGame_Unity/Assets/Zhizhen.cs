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
        if (Movewash.pengzhuang && !shiji && taiqi)
        {
            Debug.Log("no");
            zhizhen.speed = 0;
        }
        if (shiji && taiqi)
        {
            Debug.Log("ok");
            zhizhen.speed = 0;
        }
        taiqi = false;
        anxia = false;
        shiji = false;
    }
}
