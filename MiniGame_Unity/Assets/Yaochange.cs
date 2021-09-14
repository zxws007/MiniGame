using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Yaochange : MonoBehaviour
{
    public string scene;
    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene(scene);//level1为我们要切换到的场景
    }

    // Update is called once per frame
    void Update()
    {

    }
}
