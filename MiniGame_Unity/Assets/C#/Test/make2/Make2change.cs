using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Make2change : MonoBehaviour {

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene("1");//level1为我们要切换到的场景
    }

    // Update is called once per frame
    void Update()
    {

    }
}
