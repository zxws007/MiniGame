using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kaijumanager : MonoBehaviour {

    int index;
    public GameObject show1;
    public GameObject danchu;
    public string scene;
    // Use this for initialization
    void Start () {
        index = 0;	
	}
	
	// Update is called once per frame
	void Update () {
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
            Next2Scene();
        }
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
}
