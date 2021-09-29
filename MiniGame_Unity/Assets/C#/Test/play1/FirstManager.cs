using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstManager : MonoBehaviour
{

    public static int change = 0;
    public GameObject show;
    public GameObject hide;
    public GameObject button;

    public GameObject bing1;
    public GameObject bing2;

    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject show4;
    public GameObject show5;
    public GameObject show6;


    int index = 0;
    // Use this for initialization
    void Start()
    {
        change = 0;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (change == 3)
        {
            show.SetActive(true);
            button.SetActive(true);
            hide.SetActive(false);
            //SceneManager.LoadScene("1");
        }
        if (Input.GetMouseButtonDown(0))
        {
            index++;
        }
        if (index == 1)
        {
            show1.SetActive(true);
        }
        if (index == 2)
        {
            show2.SetActive(true);
        }
        if (index == 3)
        {
            show3.SetActive(true);
        }
        if (index == 4)
        {
            show4.SetActive(true);
        }
        if (index == 5)
        {
            show5.SetActive(true);
        }
        if (index == 6)
        {
            show6.SetActive(true);
            bing1.SetActive(true);
            bing2.SetActive(true);
        }

    }

}
