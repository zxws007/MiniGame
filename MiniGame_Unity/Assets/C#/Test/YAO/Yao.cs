using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int i = 0;
    bool C = false;
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
                    StartCoroutine(Wait());
                    i++;
                }
                else
                {
                    cjingzhi.SetActive(false);
                    chuangdong.SetActive(true);
                    StartCoroutine(Wait());
                }
            }
            else
            {
                if (!C)
                {
                    jingzhi.SetActive(true);
                    huangdong.SetActive(false);
                }
                else
                {
                    cjingzhi.SetActive(true);
                    chuangdong.SetActive(false);
                }

            }
            if (i >= 100)
            {
                C = true;
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
