using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstManager1 : MonoBehaviour
{

    public static int change = 0;
    public GameObject show;
    public GameObject hide;
    public GameObject button;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (change == 3)
        {
            show.SetActive(true);
            button.SetActive(true);
            hide.SetActive(false);
            //SceneManager.LoadSceneAsync("1");
        }
    }
}
