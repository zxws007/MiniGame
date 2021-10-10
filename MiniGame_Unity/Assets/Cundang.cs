using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cundang : MonoBehaviour {

    string scene2;
	// Use this for initialization
	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        scene2 = scene.name;
        PlayerPrefs.SetString((GlobalScore.Instance.username+"scene"), scene2);
        PlayerPrefs.SetInt((GlobalScore.Instance.username + "score1"), GlobalScore.Instance.Score1);
        PlayerPrefs.SetInt((GlobalScore.Instance.username + "score2"), GlobalScore.Instance.Score2);
        PlayerPrefs.SetInt((GlobalScore.Instance.username + "score3"), GlobalScore.Instance.Score3);
        PlayerPrefs.SetInt((GlobalScore.Instance.username + "wanmei"), GlobalScore.Instance.wanmei);
        PlayerPrefs.SetInt((GlobalScore.Instance.username + "lianghao"), GlobalScore.Instance.lianghao);
        PlayerPrefs.SetInt((GlobalScore.Instance.username + "yiban"), GlobalScore.Instance.yiban);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
