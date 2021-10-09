using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kaijumanager : MonoBehaviour {

    int index;
    public GameObject show1;
    public GameObject danchu;
    public string scene;
    int pan;
    // Use this for initialization
    void Start () {
        index = 0;
        pan = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            index++;
        }
        StartCoroutine(Wait2());
        if (index == 1)
        {
            show1.SetActive(true);
            pan++;
        }
        if (index == 2)
        {
            Next2Scene();
        }
        Debug.Log(index);
    }
    public void Next2Scene()
    {
        danchu.SetActive(true);
        StartCoroutine(Wait());
    }


    //等1.5秒后跳转，等淡出动画播完
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(scene);
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1.5f);
        show1.SetActive(true);
        if (pan == 0)
        {
            index=1;
        }
    }
}
