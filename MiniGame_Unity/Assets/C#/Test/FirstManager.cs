using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstManager : MonoBehaviour
{

    public static int change = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (change == 2)
        {
            SceneManager.LoadScene("1");
        }
    }
}
