using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour {

    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    int pan;
    // Use this for initialization
    void Start () {
        pan = GlobalScore.Instance.Score1;
        if (pan < 47)
        {
            show1.SetActive(true);
            GlobalScore.Instance.yiban++;
        }
        if (pan < 64 && pan >= 47)
        {
            show2.SetActive(true);
            GlobalScore.Instance.lianghao++;
        }
        if (pan >= 64)
        {
            GlobalScore.Instance.wanmei++;
            show3.SetActive(true);
        }

    }
    
	// Update is called once per frame
	void Update () {
        
        
    }
}
