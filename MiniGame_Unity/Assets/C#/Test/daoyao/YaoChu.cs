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

    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject hide1;
    public GameObject hide2;
    public GameObject hide3;

    public Image condition;
    public Text hint;
    public Button act;
    private float speed = 1F;
    private bool mouseDown = false;
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
        
	}
	
	// Update is called once per frame
	void Update () {
        if (DaoYaoHerb.inCnt == 0)
        {
            transform.position = Vector3.zero;
            condition.fillAmount = 0.1f;
        }
        else
        {
            if (pause && cnt > 1)
            {
                pause = false;
                cnt = 0;
                System.Threading.Thread.Sleep(1500);
            }
            transform.position += Vector3.up * speed * Time.deltaTime;
            condition.fillAmount = transform.position.y / 3.0f * 0.7f + 0.1f;
            if (transform.position.y >= 3)
            {
                SetDown();
            }
            if (pause)
            {
                cnt += 1;
            }
        }
        
        
	}

    public void OnClick()
    {
        SetDown();
    }


    // 设置为down状态
    private void SetDown()
    {
        transform.position = Vector3.zero;
        condition.fillAmount = 0.1f;
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
            hint.text = "";
            hide1.SetActive(false);
            hide2.SetActive(false);
            hide3.SetActive(false);
            show1.SetActive(true);
            show2.SetActive(true);
            show3.SetActive(true);
        }
    }
}
