using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drdc : MonoBehaviour
{
    public string scene; 
    public GameObject danchu;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Next2()
    {
        Debug.Log("1");
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
