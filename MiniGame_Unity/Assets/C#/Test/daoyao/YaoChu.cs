using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YaoChu : MonoBehaviour {
    [SerializeField] public int TimesToOver; // 拉手拉完的次数
    [SerializeField] public float herbNum; 
    [SerializeField] public Sprite[] Sprites; // 精灵图
    private int DownTimes = 0; // 捣的次数

    
    public GameObject pointer;
    public GameObject cover;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public GameObject bar;
    public GameObject bottom;

    public Image best;
    public Image good;
    public Image normal;

    public Text hint;
    public Button act;
    private float speed = 1F;
    private bool pause = false;
    private int cnt = 0;

    public void RegisterCallbacks()
    {
    }
	// Use this for initialization
	void Start ()
    {
        RegisterCallbacks();
        act.onClick.AddListener(OnClick);
        showResting();
        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
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
        SetDown();
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
    void showWorking()
    {
        this.GetComponent<Renderer>().enabled = true;
        bar.SetActive(true);
        pointer.SetActive(true);

        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
        bottom.SetActive(false);
        cover.SetActive(false);
    }

    void showResting()
    {
        this.GetComponent<Renderer>().enabled = false;
        bar.SetActive(false);
        pointer.SetActive(false);

        arrowLeft.SetActive(true);
        arrowRight.SetActive(true);
        bottom.SetActive(true);
        cover.SetActive(true);
    }
}
