using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chao : MonoBehaviour {
    public Sprite[] sprites;
    public Sprite[] herbSprites;
    public Sprite[] pointerSprites;
    public GameObject chaoArrow;
    public GameObject xunArrow;
    public GameObject bar;
    public GameObject pointer;
    public GameObject chaoHerb;
    public Transform correctTrans;
    public Image best;
    public Image good;
    public Image normal;
    public Text chaoText;
    public GameObject backButton;
    public int totalTimes;

    private SpriteRenderer render;
    private Vector3 originPos;
    private Vector3 lastPos = Vector3.zero;
    private Vector3 deltaPos;
    private float cnt = 0;
    private Vector3 pStart = new Vector3(1, 3.7f, 0);
    private Vector3 pEnd = new Vector3(9, 3.7f, 0);
    private Vector3 pCenter = new Vector3(5,5,0);
    private bool pause;
    private bool wantTrigerExit;
    private bool isMove = false;
    private int downTimes = 0;
    static public bool isWorking = false;

	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
        render.sprite = sprites[0];
        originPos = transform.position;
        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
        pause = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (pause)
        {
            
        }
        else
        {
            if (isWorking && pointer.transform.position == pEnd)
            {
                isWorking = false;
                pause = true;
                ShowScore();
                StartCoroutine(Wait());
            }
            if (isWorking)
            {
                cnt++;
                if (cnt > 300)
                {
                    cnt = 0;
                }
                pointer.transform.position = GetBezierPoint(cnt / 300, pStart, pCenter, pEnd);
            }

            if (!isMove && lastPos != Vector3.zero)
            {
                //deltaPos = lastPos - transform.position;
                if (Mathf.Abs(transform.position.x - lastPos.x) >= 0.7f &&
                Mathf.Abs(transform.position.y - lastPos.y) >= 0.7f)
                {
                    wantTrigerExit = true;
                    isWorking = true;
                    chaoHerb.GetComponent<SpriteRenderer>().sprite = herbSprites[0];
                    isMove = true;
                }
            }
            if (!isMove && Mathf.Abs(transform.position.x - correctTrans.position.x) <= 1f &&
                Mathf.Abs(transform.position.y - correctTrans.position.y) <= 1f)
            {
                if (lastPos == Vector3.zero)
                {
                    lastPos = transform.position;
                }
            }

            if (totalTimes <= 0)
            {
                ShowFinish();
            }
        }
        
    }

    private void OnMouseDrag()
    {
        
        if (!pause && chaoHerb.transform.position == correctTrans.position)
        {
            render.sprite = sprites[1];
            chaoArrow.SetActive(false);
            xunArrow.SetActive(false);
            chaoText.enabled = false;
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                 Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
        else
        {
            transform.position = originPos;
        }
       
    }

    private void OnMouseUp()
    {
        if (transform.position == originPos)
        {

        }
        else if (isWorking && transform.position != originPos)
        {
            isWorking = false;
            pause = true;
            //SetBack();
            ShowScore();
            StartCoroutine(Wait());
        }
        else if (!isWorking && chaoHerb.transform.position == correctTrans.position)
        {
            Debug.Log("onmoouse debug");
            SetBack();
        }
        
    }

    void SetBack()
    {
        Debug.Log("SetBack......");
        isWorking = false;
        
        pointer.transform.position = pStart;
        render.sprite = sprites[0];
        chaoArrow.SetActive(true);
        xunArrow.SetActive(true);
        chaoText.enabled = true; 
        transform.position = originPos;
        chaoHerb.GetComponent<SpriteRenderer>().sprite = herbSprites[1];
        pointer.GetComponent<SpriteRenderer>().sprite = pointerSprites[0];
    }

    

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.name == "锅")
    //    {
    //        wantTrigerExit = true;
    //        isWorking = true;
    //        chaoHerb.GetComponent<SpriteRenderer>().sprite = herbSprites[0];
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (wantTrigerExit && collision.name == "锅")
        {
            isWorking = false;
            pause = true;
            //SetBack();
            ShowScore();
            StartCoroutine(Wait());
        }
    }

    public static Vector3 GetBezierPoint(float t, Vector3 start, Vector3 center, Vector3 end)
    {
        return (1 - t) * (1 - t) * start + 2 * t * (1 - t) * center + t * t * end;
    }

    void ShowScore()
    {
        Debug.LogFormat("score is {0}", Point.chao_score);
        pointer.GetComponent<SpriteRenderer>().sprite = pointerSprites[1];
        if (Point.chao_score == 5)
        {
            normal.enabled = true;
        }
        else if ( Point.chao_score == 8)
        {
            good.enabled = true;
        }
        else if (Point.chao_score == 10)
        {
            best.enabled = true;
        }
        Point.chao_score = 5;
        totalTimes--;
        transform.position = originPos;
        wantTrigerExit = false;
        render.sprite = sprites[0];
    }

    void ShowFinish()
    {
        transform.position = originPos;
        backButton.SetActive(true);
        chaoArrow.SetActive(false);
        xunArrow.SetActive(false);
        bar.SetActive(false);
        pointer.SetActive(false);
        chaoText.text = "<color=red>炒制完成</color>";
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
        pause = false;
        isMove = false;
        lastPos = Vector3.zero;
        cnt = 0;
        if (totalTimes > 0)
        {
            SetBack();
        }
        
    }
}
