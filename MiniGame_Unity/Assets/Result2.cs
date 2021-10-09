using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result2 : MonoBehaviour {

    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    // Use this for initialization
    void Start()
    {
        if (GlobalScore.Instance.Score2 == 5)
        {
            GlobalScore.Instance.yiban++;
            show1.SetActive(true);
        }
        if (GlobalScore.Instance.Score2 == 8)
        {
            GlobalScore.Instance.lianghao++;
            show2.SetActive(true);
        }
        if (GlobalScore.Instance.Score2 == 10)
        {
            GlobalScore.Instance.wanmei++;
            show3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
