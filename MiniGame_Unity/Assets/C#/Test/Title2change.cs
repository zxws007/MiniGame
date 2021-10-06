using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title2change : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadSceneAsync("10");//level1为我们要切换到的场景
    }

    // Update is called once per frame
    void Update()
    {

    }
}
