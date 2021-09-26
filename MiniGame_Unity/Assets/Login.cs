using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    public InputField user_name;
    public InputField password;
    public Text hint;
    public Toggle toggle;

    void Start()
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
        toggle.onValueChanged.AddListener(ToggleClick);
    }
    
    
    public void OnLoginButtonCLick()
    {
        if (user_name.text == "")
        {
            Debug.Log("用户名为空");
            hint.text = "请输入用户名";
        }
        else if (password.text == "")
        {
            Debug.Log("密码为空");
            hint.text = "请输入密码";
        }
        else if (password.text == PlayerPrefs.GetString(user_name.text))
        {
            Debug.Log("登录成功！");
            SceneManager.LoadScene("1");
        }
        else
        {
            Debug.Log("用户名或密码错误！");
            Debug.LogFormat("用户名：{0}, 输入密码：{1}，存储密码：{2}", user_name.text, password.text, PlayerPrefs.GetString(user_name.text));
            hint.text = "用户名或密码错误！";
        }
    }

    public void OnRegisteButtonClick()
    {
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnButtonExit()
    {
        Application.Quit();
    }

    public void ToggleClick(bool isShow)
    {
        password.contentType = isShow ? InputField.ContentType.Standard : InputField.ContentType.Password;
        password.Select();
    }
}