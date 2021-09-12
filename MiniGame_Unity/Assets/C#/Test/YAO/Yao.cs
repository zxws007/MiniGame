using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yao : MonoBehaviour
{

    private float old_y = 0;
    private float new_y;
    private float currentDistance = 0;

    public float distance = 1;
    public GameObject jingzhi;
    public GameObject huangdong;
    public GameObject cjingzhi;
    public GameObject chuangdong;
    public static int i = 0;
    bool C = false;
    public GameObject textp;
    public static bool isshake = false;
    public GameObject text;
    public GameObject textc;
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
            if (i >= 100)
            {
                C = true;
                textc.SetActive(true);
            }
        }
        if (i != 0 && i < 200 && Move.isOK)
        {
            textp.SetActive(true);
            text.SetActive(false);
        }
    }
}
