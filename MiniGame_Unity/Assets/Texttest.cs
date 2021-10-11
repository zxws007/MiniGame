using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Texttest : MonoBehaviour {

    public Text text;
    public int Score1;
    public int Score2;
    public int Score3;
    public int wanmei;
    public int lianghao;
    public int yiban;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = PlayerPrefs.GetString(GlobalScore.Instance.username + "scene");
        Score1 = PlayerPrefs.GetInt(GlobalScore.Instance.username + "score1");
        Score2 = PlayerPrefs.GetInt(GlobalScore.Instance.username + "score2");
        Score3 = PlayerPrefs.GetInt(GlobalScore.Instance.username + "score3");
        wanmei = PlayerPrefs.GetInt(GlobalScore.Instance.username + "wanmei");
        yiban = PlayerPrefs.GetInt(GlobalScore.Instance.username + "yiban");
        lianghao = PlayerPrefs.GetInt(GlobalScore.Instance.username + "lianghao");

    }
}
