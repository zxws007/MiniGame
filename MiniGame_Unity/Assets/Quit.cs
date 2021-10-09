using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour {

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
