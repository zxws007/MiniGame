﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YaoChu : MonoBehaviour {
    [SerializeField] public int TimesToOver; // 拉手拉完的次数
    [SerializeField] public float herbNum; 
    [SerializeField] public Sprite[] Sprites; // 精灵图
    private int DownTimes = 0; // 捣的次数

    public GameObject backButton;
    public GameObject pointer;
    public GameObject cover;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public GameObject bar;
    public GameObject bottom;
    public GameObject halfBottom;

    public Image best;
    public Image good;
    public Image normal;

    public Text hint;
    public Button act;
    private float speed = 1F;
    private bool pause = false;
    private bool isWorking = false;
    private int cnt = 0;
    private Vector3 start = new Vector3(0f, 1f, 0);
    private Vector3 end = new Vector3(0f, 3f, 0);

    public void RegisterCallbacks()
    {
    }
	// Use this for initialization
	void Start ()
    {
        RegisterCallbacks();
        act.onClick.AddListener(OnClick);
        showResting();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (pause && cnt > 0)
        {
            pause = false;
            cnt = 0;
            
        }
        if (Score.stop_cnt >= TimesToOver)
        {
            
            hint.text = "捣药完成，继续完成下一药材";
            showResting();
            Score.stop_cnt = 0;
            Score.execPause = false;
            DaoYaoHerb.inCnt -= 1;
            herbNum -= 1;
            cnt += 1;
            
            
        }
        if (herbNum <= 0)
        {
            showResting();
            hint.text = "药材全部处理完毕";
            backButton.SetActive(true);
        }

        
        //Debug.LogFormat("cccccnnnnnnntttt {0}", cnt);
        //if (DaoYaoHerb.inCnt == 0)
        //{
        //    transform.position = Vector3.zero;
        //    pointer.transform.position = Vector3.zero + Vector3.right * 7 + Vector3.down * 1;
        //}
        //else
        //{
        //    if (pause && cnt > 1)
        //    {
        //        pause = false;
        //        cnt = 0;
        //        System.Threading.Thread.Sleep(1000);
        //    }
        //    transform.position += Vector3.up * speed * Time.deltaTime;
        //    pointer.transform.position += Vector3.up * 2 * speed * Time.deltaTime;
        //    if (transform.position.y >= 3)
        //    {
        //        SetDown();
        //    }
        //
        //    if (pause)
        //    {
        //        cnt += 1;
        //    }
        //}
        
        
	}

    public void OnClick()
    {
        //SetDown();
        //transform.position = start;
    }

    public static Vector3 GetPoint(float t, Vector3 start, Vector3 end)
    {
        return start + (end - start) * t;
    }
    

    // 设置为down状态
    private void SetDown()
    {
        Debug.LogFormat("The score is {0}", Score.daoyao_score);
        transform.position = Vector3.zero;
        pointer.transform.position = Vector3.zero + Vector3.right * 7 + Vector3.down * 1;
        pause = true;

        DownTimes++;
        if (DownTimes == TimesToOver)
        {
            Debug.Log("一种药完成");
            hint.text = "捣药完成，继续完成下一药材";
            DownTimes = 0;
            DaoYaoHerb.inCnt = 0;
            herbNum -= 1;
        }
        if (herbNum <= 0)
        {
            hint.text = "药材全部处理完毕";
        }
    }

    // 工作状态展示
    public void showWorking()
    {
        this.GetComponent<Renderer>().enabled = true;
        isWorking = true;
        bar.SetActive(true);
        pointer.SetActive(true);
        bottom.SetActive(true);

        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
        halfBottom.SetActive(false);
        cover.GetComponent<Renderer>().enabled = false;
    }

    public void showResting()
    {
        this.GetComponent<Renderer>().enabled = false;
        isWorking = false;
        bar.SetActive(false);
        pointer.SetActive(false);
        bottom.SetActive(false);

        arrowLeft.SetActive(true);
        arrowRight.SetActive(true);
        halfBottom.SetActive(true);
        cover.GetComponent<Renderer>().enabled = true;

        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
        act.image.enabled = false;
    }
}
