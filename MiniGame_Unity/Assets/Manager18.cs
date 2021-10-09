using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager18 : MonoBehaviour {

    public GameObject bing2;

    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject show4;


    public GameObject hide1;
    public GameObject hide2;

    int index = 0;
    // Use this for initialization
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            hide1.SetActive(false);
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
            hide2.SetActive(false);
            bing2.SetActive(true);
        }
    }

}
