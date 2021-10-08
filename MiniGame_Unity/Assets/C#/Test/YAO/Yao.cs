using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yao : MonoBehaviour
{

    private float old_y = 0;
    private float new_y;
    private float currentDistance = 0;

    public float distance = 0.1f;
    public GameObject jingzhi;
    public GameObject huangdong;
    public GameObject huangdong1;
    public GameObject cjingzhi;
    public GameObject chuangdong;
    public static int i = 0;
    bool C = false;
    public GameObject textp;
    public static bool isshake = false;
    public GameObject textc;

    public GameObject button1;
    public GameObject button2;

    public Animator animator;
    bool b = true;
    public Text debug;
    public GameObject ljj;
    public AudioSource source;
    bool jieshu = false;
    void Start()
    {
        animator.speed = 0;
        button2.SetActive(false);
        jingzhi.SetActive(false);
        huangdong1.SetActive(false);
        huangdong.SetActive(false);
        chuangdong.SetActive(false);
        cjingzhi.SetActive(false);
        i = 0;
        C = false;
        isshake = false;
    }
    public void Move15()
    {
        SceneManager.LoadSceneAsync("15");//level1为我们要切换到的场景
    }
    public void Moveagain()
    {
        SceneManager.LoadSceneAsync(gameObject.scene.name);//level1为我们要切换到的场景
    }

    void Update()
    {
        if (Move.isOK)
        {
            new_y = Input.acceleration.y;
            currentDistance = new_y - old_y;
            old_y = new_y;
            if (currentDistance > distance)
            {
                if (!C)
                {
                    jingzhi.SetActive(false);
                    huangdong.SetActive(true);
                    i++;
                    if (!jieshu)
                    {
                        source.Play();
                    }
                }
                else
                {
                    cjingzhi.SetActive(false);
                    chuangdong.SetActive(true);
                    textp.SetActive(false);
                }
                isshake = true;
            }
            else
            {
                if (!C)
                {
                    jingzhi.SetActive(true);
                    huangdong.SetActive(false);
                    cjingzhi.SetActive(false);
                    chuangdong.SetActive(false);
                }
                else
                {
                    cjingzhi.SetActive(true);
                    chuangdong.SetActive(false);
                    jingzhi.SetActive(false);
                    huangdong.SetActive(false);
                    textp.SetActive(false);
                }
            }
            if (i >= 20)
            {
                C = true;
                textc.SetActive(true);
                huangdong.SetActive(false);
                huangdong1.SetActive(false);
                button1.SetActive(false);
                button2.SetActive(true);
                ljj.SetActive(true);
                jieshu = true;
            }
        }
        if (i != 0 && i < 100 && Move.isOK)
        {
            textp.SetActive(true);
            huangdong1.SetActive(true);
        }
        debug.text = "" + i;
    }
    public void Moni()
    {
        i += 50;
        animator.speed = 1;
        animator.Play("xvliezhen1");
    }
}
