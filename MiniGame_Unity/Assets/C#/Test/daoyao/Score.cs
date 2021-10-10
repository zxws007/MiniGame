using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] public Sprite[] Sprites; // 精灵图

    public GameObject pointer;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public Image best;
    public Image good;
    public Image normal;
    
    public Button act;
    public GameObject chu;
    public AudioSource audiosource;
    public Text hint;


    private float cnt = 0;
    private Vector3 start = new Vector3(-3.3f, -5f, 0);
    private Vector3 end = new Vector3(-3.3f, 7.8f, 0);
    private Vector3 center = new Vector3(-5f, 1.7f, 0);
    private SpriteRenderer render;
    private Vector3 chuStart = new Vector3(1.5f, 3.8f, 0);
    private Vector3 chuEnd = new Vector3(1.5f, 7f, 0);
    private float chuCnt = 0;


    static public bool isStarting = false;
    static public int daoyao_score = 5;
    static public int totalScore = 0;
    static public bool pause = false;
    static public int pause_cnt = 0;
    static public int stop_cnt = 0;
    static public bool execPause = false;

    

    // Use this for initialization
    void Start()
    {
        act.image.enabled = true;
        GameObject.Find("action/Text").GetComponent<Text>().enabled = true;
        act.onClick.AddListener(OnClick);
        render = GetComponent<SpriteRenderer>();
        render.sprite = Sprites[0];
        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
        
        totalScore = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (cnt == 300)
        {
            cnt += 1;
            showStop();
        }
        if (!isStarting)
        {
            transform.position = start;
            chu.transform.position = chuStart;
        }

        if (!pause && isStarting)
        {
            cnt += 1;
            chuCnt += 1;
            transform.position = GetBezierPoint(cnt / 300, start, center, end);
            chu.transform.position = GetChuPoint(chuCnt / 300, chuStart, chuEnd);
        }
        
    }


    //private void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (!pause && collider.name == "s4")
    //    {
    //        daoyao_score = 8;
    //        Debug.Log("exit s4");
    //    }
    //    else if (collider.name == "s3")
    //    {
    //        daoyao_score = 10;
    //        Debug.Log("exit s3");
    //    }
    //}
    //
    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.name == "s2")
    //    {
    //        daoyao_score = 8;
    //        Debug.Log("enter s2");
    //    }
    //    else if (collider.name == "s1")
    //    {
    //        daoyao_score = 5;
    //        Debug.Log("enter s1");
    //    }
    //}
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "s5" || other.name == "s1")
        {
            daoyao_score = 5;
        }
        else if (other.name == "s4" || other.name == "s2")
        {
            daoyao_score = 8;
        }
        else if (other.name == "s3")
        {
            daoyao_score = 10;
        }
    }
    

    public static Vector3 GetBezierPoint(float t, Vector3 start, Vector3 center, Vector3 end)
    {
        return (1 - t) * (1 - t) * start + 2 * t * (1 - t) * center + t * t * end;
    }

    public Vector3 GetChuPoint(float t, Vector3 start, Vector3 end)
    {
        return start + (end - start) * t;
    }

    public void OnClick()
    {
        if (isStarting)
        {
            showStop();
        }
        isStarting = true;
        
    }

    private void showStop()
    {
        Debug.LogFormat("daoyao score is {0}", daoyao_score);
        totalScore += daoyao_score;
        if (daoyao_score == 5)
        {
            normal.enabled = true;
        }
        else if (daoyao_score == 8)
        {
            good.enabled = true;
        }
        else if (daoyao_score == 10)
        {
            best.enabled = true;
        }
        daoyao_score = 5;
        render.sprite = Sprites[1];

        audiosource.Play();
        if (stop_cnt < 2)
        {
            hint.text = "再捣一次";
        }
        else
        {
            hint.text = "";
        }
        
        
        pause = true;
        chuCnt = 0;
        chu.transform.position = chuStart;
        act.interactable = false;
        StartCoroutine(Wait());
    }

  

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        cnt = 0;
        chuCnt = 0;
        pause = false;
        stop_cnt += 1;
        render.sprite = Sprites[0];
        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
        act.interactable = true;
        daoyao_score = 5;
        if (stop_cnt == 3)
        {
            hint.text = "";
        }
        else
        {
            hint.text = "点击捣按钮开始捣药";
        }
       
    }
}
