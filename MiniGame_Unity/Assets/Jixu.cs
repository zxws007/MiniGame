using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jixu : MonoBehaviour {
    string cundangname;
    string scene;
    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        cundangname = GlobalScore.Instance.username + "scene";
        scene = PlayerPrefs.GetString(cundangname);
        GlobalScore.Instance.Score1 = PlayerPrefs.GetInt(GlobalScore.Instance.username + "score1");
        GlobalScore.Instance.Score2 = PlayerPrefs.GetInt(GlobalScore.Instance.username + "score2");
        GlobalScore.Instance.Score3 = PlayerPrefs.GetInt(GlobalScore.Instance.username + "score3");
        GlobalScore.Instance.wanmei = PlayerPrefs.GetInt(GlobalScore.Instance.username + "wanmei");
        GlobalScore.Instance.yiban = PlayerPrefs.GetInt(GlobalScore.Instance.username + "yiban");
        GlobalScore.Instance.lianghao = PlayerPrefs.GetInt(GlobalScore.Instance.username + "lianghao");
        SceneManager.LoadSceneAsync(scene);//level1为我们要切换到的场景
    }

    // Update is called once per frame
    void Update()
    {

    }
}
