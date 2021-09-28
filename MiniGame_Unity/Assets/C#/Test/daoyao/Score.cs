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
    public Image best;
    public Image good;
    public Image normal;
    public Button act;
    public GameObject chu;
    public AudioSource audio;


    private float cnt = 0;
    private Vector3 start = new Vector3(-3f, -4f, 0);
    private Vector3 end = new Vector3(-3f, 4f, 0);
    private Vector3 center = new Vector3(-4.3f, 0f, 0);
    private SpriteRenderer render;
    private Vector3 chuStart = new Vector3(-0.1f, 1f, 0);
    private Vector3 chuEnd = new Vector3(-0.1f, 3f, 0);
    private float chuCnt = 0;


    static public int daoyao_score = 0;
    static public bool pause = false;
    static public int pause_cnt = 0;
    static public int stop_cnt = 0;
    static public bool execPause = false;

    

    // Use this for initialization
    void Start()
    {
        act.image.enabled = true;
        act.onClick.AddListener(OnClick);
        render = GetComponent<SpriteRenderer>();
        render.sprite = Sprites[0];
        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (cnt == 100)
        {
            cnt += 1;
            showStop();
        }

        if (!pause)
        {
            cnt += 1;
            chuCnt += 1;
            transform.position = GetBezierPoint(cnt / 100, start, center, end);
            chu.transform.position = GetChuPoint(chuCnt / 100, chuStart, chuEnd);
        }
        
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "s4")
        {
            daoyao_score = 1;
            //Debug.LogFormat("trigger s4 score {0}", daoyao_score);
        }
        else if (collider.name == "s3")
        {
            daoyao_score = 2;
            //Debug.LogFormat("trigger s3 score {0}", daoyao_score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "s2")
        {
            daoyao_score = 1;
            //Debug.LogFormat("trigger s2 score {0}", daoyao_score);
        }
        else if (collider.name == "s1")
        {
            daoyao_score = 0;
            //Debug.LogFormat("trigger s1 score {0}", daoyao_score);
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
        showStop();
    }

    private void showStop()
    {
        Debug.LogFormat("daoyao score is {0}", daoyao_score);
        if (daoyao_score == 0)
        {
            normal.enabled = true;
        }
        else if (daoyao_score == 1)
        {
            good.enabled = true;
        }
        else if (daoyao_score == 2)
        {
            best.enabled = true;
        }
        daoyao_score = 0;
        render.sprite = Sprites[1];

        audio.Play();
        
        pause = true;
        chuCnt = 0;
        chu.transform.position = chuStart;
        StartCoroutine(Wait());
    }

  

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        cnt = 0;
        chuCnt = 0;
        pause = false;
        stop_cnt += 1;
        render.sprite = Sprites[0];
        best.enabled = false;
        good.enabled = false;
        normal.enabled = false;
    }
}
