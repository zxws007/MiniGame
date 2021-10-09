using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playagain : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        GlobalScore.Instance.Score1 = 0;
        GlobalScore.Instance.Score2 = 0;
        GlobalScore.Instance.Score3 = 0;
        GlobalScore.Instance.yiban = 0;
        GlobalScore.Instance.lianghao = 0;
        GlobalScore.Instance.wanmei = 0;
        SceneManager.LoadSceneAsync("01");//level1为我们要切换到的场景
    }

    // Update is called once per frame
    void Update()
    {

    }
}
