using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShenghuoButton : MonoBehaviour {

	// Use this for initialization
	public string textToShow;
	private Text text;
	void Start () {
		text = transform.Find("Text").GetComponent<Text>();
		text.text = textToShow;
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void OnClick()
	{
		GlobalScore.Instance.Score1 += Bashou.totalScore;
        UnityEngine.SceneManagement.SceneManager.LoadScene("07");//level1为我们要切换到的场景
	}
}
