using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager02 : MonoBehaviour {

    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject show4;
    public GameObject show5;

    public GameObject hide1;
    public static int index;

    // Use this for initialization
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            show5.SetActive(true);

        }
    }

}
