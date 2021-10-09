using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result3 : MonoBehaviour {

    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    // Use this for initialization
    void Start()
    {
        if (GlobalScore.Instance.Score3 <= 31)
        {
            GlobalScore.Instance.yiban++;
            show1.SetActive(true);
        }
        if (GlobalScore.Instance.Score3 > 31 && GlobalScore.Instance.Score3 < 38)
        {
            GlobalScore.Instance.lianghao++;
            show2.SetActive(true);
        }
        if (GlobalScore.Instance.Score3 >= 38)
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
