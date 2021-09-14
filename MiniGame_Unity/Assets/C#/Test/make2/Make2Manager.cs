using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Make2Manager : MonoBehaviour
{

    public static int change = 0;
    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject hide1;
    public GameObject hide2;
    public GameObject button1;
    public GameObject button2;

    public GameObject show5;
    public GameObject hide5;

    public GameObject showtext;
    public GameObject showtext1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (change == 2)
        {
            show1.SetActive(true);
            hide1.SetActive(false);

        }
        if (change == 3)
        {
            show2.SetActive(true);
            hide2.SetActive(false);
            button1.SetActive(true);
            //SceneManager.LoadScene("1");
        }

        if (change == 4)
        {
            button1.SetActive(false);
            button2.SetActive(true);
            hide5.SetActive(false);
            show5.SetActive(true);
            showtext.SetActive(true);
            showtext1.SetActive(true);
        }


    }
}