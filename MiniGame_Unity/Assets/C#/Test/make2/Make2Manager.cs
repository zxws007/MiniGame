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
    public GameObject button;
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
            Debug.Log(Make2Manager.change);
            show2.SetActive(true);
            show3.SetActive(true);
            hide2.SetActive(false);
            button.SetActive(true);
            //SceneManager.LoadScene("1");
        }
    }
}