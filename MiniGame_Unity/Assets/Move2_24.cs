using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2_24 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        //
        GlobalScore.Instance.Score3 += Score.totalScore;
        SceneManager.LoadSceneAsync("24");//level1为我们要切换到的场景
    }

}
