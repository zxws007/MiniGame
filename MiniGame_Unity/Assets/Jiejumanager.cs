using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jiejumanager : MonoBehaviour {

    int index;
    public GameObject show1;
    public GameObject show2;
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
        StartCoroutine(Wait2());
        if (index == 1)
        {
            show2.SetActive(true);
        }
    }


    //等1.5秒后跳转，等淡出动画播完
    
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1.5f);
        show2.SetActive(true);
    }
}
