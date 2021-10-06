using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Button2 : MonoBehaviour
{

    public Animator animator1;
    public Animator animator2;
    public GameObject hide;
    public GameObject hide2;


    public Text text1;

    int change = 0;
    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    void OnClick()
    {


        if (change == 0)
        {
            animator1.speed = 0;
            animator2.speed = 0;
            hide.SetActive(false);
            hide2.SetActive(false);
            change = change + 1;
            text1.text = "查看结果";
        }
        else
        {
            SceneManager.LoadSceneAsync("result2");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
