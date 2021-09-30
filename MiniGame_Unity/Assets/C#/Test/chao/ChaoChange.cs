using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChaoChange : MonoBehaviour
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
        GlobalScore.Instance.Score1 += Chao.totalScore;
        SceneManager.LoadScene("08");//level1为我们要切换到的场景
    }
}
