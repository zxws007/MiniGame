using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Body : MonoBehaviour {
    int i = 0;
    public GameObject show;
    public GameObject show1;

    // Use this for initialization
    void Start () {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        i++;
        if (i % 2 == 1)
        {
            show.SetActive(true);
        }
        if (i % 2 == 0)
        {
            show.SetActive(false);
        }
        if (Changmove.body == 1)
        {
            show1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
