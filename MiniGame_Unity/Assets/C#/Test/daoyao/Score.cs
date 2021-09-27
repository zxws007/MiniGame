using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    public GameObject pointer;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    private float y_speed = 2F;
    private float x_speed = 0.5F;
    private bool pause = false;
    private float cnt = 0;
    private Vector3 start = new Vector3(-3f, -4f, 0);
    private Vector3 end = new Vector3(-3f, 4f, 0);
    private Vector3 center = new Vector3(-4.5f, 0f, 0);
    static public int daoyao_score = 0;
    
    public Button act;

    // Use this for initialization
    void Start()
    {
        //act.onClick.AddListener(OnClick);
    }
    // Update is called once per frame
    void Update()
    {
        cnt += 1;
        if (cnt > 300)
        {
            cnt = 1;
        }
        transform.position = GetBezierPoint(cnt/300, start, center, end);
        
        
    }



    private void OnTriggerEnter2D(Collider2D collider)
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
        else if (collider.name == "s2")
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

    //public void Move()
    //{
    //    if (transform.position.x >= x_right || transform.position.x <= x_left)
    //    {
    //        x_speed = -x_speed;
    //    }
    //    if (transform.position.y >= y_top || transform.position.y <= y_bottom)
    //    {
    //        y_speed = -y_speed;
    //    }
    //    transform.position += Vector3.right * x_speed * Time.deltaTime;
    //    //transform.position += Vector3.up * y_speed * Time.deltaTime;
    //
    //}

    public static Vector3 GetBezierPoint(float t, Vector3 start, Vector3 center, Vector3 end)
    {
        return (1 - t) * (1 - t) * start + 2 * t * (1 - t) * center + t * t * end;
    }

    public void SetBack()
    {
        transform.position = s4.transform.position + Vector3.down * 3;
        pause = true;
    }

    public void OnClick()
    {
        Debug.LogFormat("The score is {0}", daoyao_score);
        daoyao_score = 0;
        //SetBack();
    }
}
