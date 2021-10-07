using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour {

    public int scene;
    int pan;
    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    // Use this for initialization
    void Start () {
		
	}
    
	// Update is called once per frame
	void Update () {
        if (scene == 1)
        {
            pan = GlobalScore.Instance.Score1;
        }
        if (scene == 2)
        {
            pan = GlobalScore.Instance.Score2;
        }
        if (scene == 3)
        {
            pan = GlobalScore.Instance.Score3;
        }
        if (pan < 10)
        {
            show1.SetActive(true);
        }
        if (pan >= 10 && pan < 20)
        {
            show2.SetActive(true);
        }
        if (pan >= 20 && pan < 30)
        {
            show3.SetActive(true);
        }
    }
}
