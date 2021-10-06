using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButton : MonoBehaviour {
    public InputField passwd;
    public Sprite[] sprites;
    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        if (passwd.contentType == InputField.ContentType.Password)
        {
            passwd.contentType = InputField.ContentType.Standard;
            passwd.Select();
            if (LoginManager.type == "login")
            {
                GetComponent<Image>().sprite = sprites[0];
            }
            else
            {
                GetComponent<Image>().sprite = sprites[2];
            }
        }
        else
        {
            passwd.contentType = InputField.ContentType.Password;
            passwd.Select();
            if (LoginManager.type == "login")
            {
                GetComponent<Image>().sprite = sprites[1];
            }
            else
            {
                GetComponent<Image>().sprite = sprites[3];
            }
        }
    }
}
