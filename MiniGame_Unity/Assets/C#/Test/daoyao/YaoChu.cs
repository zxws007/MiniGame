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

    public GameObject backButton;
    public GameObject replayButton;
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
            Score.isStarting = false;
            
        }
        if (herbNum <= 0)
        {
            showResting();
            //hint.text = "药材全部处理完毕";
            Debug.LogFormat("totalscore is {0}", Score.totalScore);
            if (Score.totalScore == 50)
            {
                hint.text = "药材炮制非常完美";
            }
            else if (Score.totalScore >= 40 && Score.totalScore < 50)
            {
                hint.text = "药材炮制精良，但是还有改进空间";
            }
            else
            {
                hint.text = "药材炮制基本完成，不过品质较差";
            }
            arrowLeft.SetActive(false);
            backButton.SetActive(true);
            replayButton.SetActive(true);
        }
        
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
            hint.text = "捣药完成，继续下一药材";
            DownTimes = 0;
            DaoYaoHerb.inCnt = 0;
            herbNum -= 1;
        }
        if (herbNum <= 0)
        {
            hint.text = "药材全部处理完毕";
            arrowLeft.SetActive(false);
            arrowRight.SetActive(false);
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
        halfBottom.SetActive(true);
        cover.GetComponent<Renderer>().enabled = true;

        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
        act.image.enabled = false;
        GameObject.Find("action/Text").GetComponent<Text>().enabled = false;
    }
}
