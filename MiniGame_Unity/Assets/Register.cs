using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour {

    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    public InputField user_name;
    public InputField password;
    public InputField confirm;
    public Text hint;

	// Use this for initialization
	void Start () {
    }

    public void OnRegisteButtonClick()
    {
        if(user_name.text == "")
        {
            hint.text = "用户名不能为空";
        }
        else if (password.text == "")
        {
            hint.text = "密码不能为空";
        }
        else if (password.text != confirm.text)
        {
            hint.text = "两次输入密码不一致";
        }
        else
        {
            PlayerPrefs.SetString(user_name.text, password.text);
            hint.text = "注册成功";
            System.Threading.Thread.Sleep(1000);
            LoginPanel.SetActive(true);
            RegisterPanel.SetActive(false);
        }
    }

    public void OnBackButtomClick()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
