using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashManager : MonoBehaviour {

    public static int change = 0;
    public GameObject show1;
    public GameObject hide1;
    public GameObject show11;
    public GameObject hide11;

    public GameObject show2;
    public GameObject hide2;
    public GameObject show21;
    public GameObject hide21;
    public GameObject show22;
    public GameObject hide22;
    public GameObject show23;
    public GameObject hide23;

    public GameObject show3;
    public GameObject hide3;
    public GameObject show31;
    public GameObject hide31;
    public GameObject hide32;
    public GameObject hide34;
    public GameObject hide35;
    public GameObject show33;
    public GameObject hide33;
    public GameObject showbutton;


    public Animator animator1;
    public Animator animator2;
    public Animator animator3;
    // Use this for initialization
    void Start()
    {
        animator1.speed = 0;
        animator2.speed = 0;
        animator3.speed = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (change == 1)
        {
            //animator1.speed = 1;
            show1.SetActive(true);
            hide1.SetActive(false);
            show11.SetActive(true);
            hide11.SetActive(false);


        }
        if (change == 2)
        {
            show2.SetActive(true);
            hide2.SetActive(false);
            show21.SetActive(true);
            hide21.SetActive(false);
            show22.SetActive(true);
            hide22.SetActive(false);
            show23.SetActive(true);
            hide23.SetActive(false);
            //SceneManager.LoadScene("1");
        }

        if (change == 3)
        {
            show3.SetActive(true);
            hide3.SetActive(false);
            show31.SetActive(true);
            hide31.SetActive(false);
            hide32.SetActive(false);
            show33.SetActive(true);
            hide33.SetActive(false);
            hide34.SetActive(false);
            hide35.SetActive(false);

            showbutton.SetActive(true);
            //animator2.speed=1;


        }


    }
}
