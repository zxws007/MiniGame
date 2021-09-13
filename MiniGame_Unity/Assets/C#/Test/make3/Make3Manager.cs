using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Make3Manager : MonoBehaviour {

    public static int change = 0;
    public GameObject show1;
    public GameObject show11;
    public GameObject show12;
    public GameObject hide1;
    public GameObject hide12;

    public GameObject show2;
    public GameObject show22;
    public GameObject show23;
    public GameObject hide2;
    public GameObject hide22;
    public GameObject hide23;

    public GameObject show3;
    public GameObject show32;
    public GameObject show33;
    public GameObject hide3;
    public GameObject hide32;
    public GameObject hide33;

    public GameObject show4;
    public GameObject show42;
    public GameObject show43;
    public GameObject hide4;
    public GameObject hide42;
    public GameObject hide43;

    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    public Animator animator4;


    public GameObject button;
    // Use this for initialization
    void Start()
    {
        animator1.speed = 0;
        animator2.speed = 0;
        animator3.speed = 0;
        animator4.speed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (change == 1)
        {
            animator1.speed = 1;
            show1.SetActive(true);//切割后的药材
            show11.SetActive(true);//药材片
            
            hide1.SetActive(false);//未切割的药材
            
        }
        if (change == 2)
        {
            show12.SetActive(true);
            hide12.SetActive(false);
            animator2.speed = 1;
            show2.SetActive(true);
            show22.SetActive(true);
            hide2.SetActive(false);//旧药材片
            hide22.SetActive(false);//新药材片
            //SceneManager.LoadScene("1");
        }

        if (change == 3)
        {
            show23.SetActive(true);
            hide23.SetActive(false);
            animator3.speed = 1;
            show3.SetActive(true);
            show32.SetActive(true);
            hide3.SetActive(false);//旧药材片
            hide32.SetActive(false);//新药材片
            //SceneManager.LoadScene("1");
        }
        if (change == 4)
        {
            show33.SetActive(true);
            hide33.SetActive(false);
            animator4.speed = 1;
            show4.SetActive(true);
            show42.SetActive(true);
            hide4.SetActive(false);//旧药材片
            hide42.SetActive(false);//新药材片
            //SceneManager.LoadScene("1");
        }
    }
}
