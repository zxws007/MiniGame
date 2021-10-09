using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jiejuchange : MonoBehaviour {


    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (GlobalScore.Instance.wanmei == 3)
        {
            SceneManager.LoadScene("jieju1");
        }
        else if (GlobalScore.Instance.yiban == 3)
        {
            SceneManager.LoadScene("jieju3");
        }
        else
        {
            SceneManager.LoadScene("jieju2");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
