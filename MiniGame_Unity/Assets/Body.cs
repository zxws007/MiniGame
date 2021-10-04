using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Body : MonoBehaviour {
    int i = 0;
    public GameObject show;

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
    }

    // Update is called once per frame
    void Update () {
		
	}
}
