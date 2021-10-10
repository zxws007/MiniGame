using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour {
    static public string type;

    public InputField user;
    public InputField passwd;
    public Text hint;
    public string scene;
    string cundangname;
    string cundangscene;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if (type == "login")
        {
            Login();
        }
        else
        {
            Registe();
        }
    }

    public void Login()
    {
        if (user.text == "")
        {
            hint.text = "请输入用户名";
        }
        else if (passwd.text == "")
        {
            hint.text = "请输入密码";
        }
        else if (passwd.text == PlayerPrefs.GetString(user.text))
        {
            GlobalScore.Instance.username = user.text;
            if (cundangscene == "")
            {
                SceneManager.LoadSceneAsync(scene);
            }
            else
            {
                SceneManager.LoadSceneAsync("again");
            }
        }
        else
        {
            hint.text = "用户名或密码错误！";
        }
    }

    public void Registe()
    {
        if (user.text == "")
        {
            hint.text = "用户名不能为空";
        }
        else if (passwd.text == "")
        {
            hint.text = "密码不能为空";
        }
        else if (PlayerPrefs.GetString(user.text) != "")
        {
            hint.text = "用户名已存在";
        }
        else
        {
            PlayerPrefs.SetString(user.text, passwd.text);
            user.text = "";
            passwd.text = "";
            hint.text = "注册成功，请前往登录";
        }
    }
}
