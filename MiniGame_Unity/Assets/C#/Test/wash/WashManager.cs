using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashManager : MonoBehaviour {

    public static int change = 0;
    public GameObject show1;
    public GameObject hide1;

    public GameObject show2;
    public GameObject hide2;

    public GameObject show3;
    public GameObject show5;
    public GameObject hide5;

    public GameObject showtext;

    public Animator animator1;
    public Animator animator2;
    // Use this for initialization
    void Start()
    {
        animator1.speed = 0;
        animator2.speed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (change == 1)
        {
            //animator1.speed = 1;
            show1.SetActive(true);
            hide1.SetActive(false);

        }
        if (change == 2)
        {
            show2.SetActive(true);
            hide2.SetActive(false);
            //SceneManager.LoadScene("1");
        }

        if (change == 3)
        {
            
            //animator2.speed=1;
            
            
        }


    }
}
