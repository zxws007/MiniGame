using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerLogin : MonoBehaviour {
    public GameObject pannel;
    public GameObject user;
    public GameObject passwd;
    public GameObject hide;
    public GameObject action;
    public GameObject triggerRegiste;
    public GameObject triggerLogin;
    public GameObject pageLogin;
    public GameObject pageRegiste;
    public Text hint;

    public Sprite[] pannelSprites;
    public Sprite[] actionSprites;
    public Sprite[] hideSprites;

    public string type;

    public Color[] inputColor; 

    // Use this for initialization
    void Start () {
        pannel.SetActive(false);
        user.SetActive(false);
        passwd.SetActive(false);
        hide.SetActive(false);
        action.SetActive(false);
        pageLogin.SetActive(false);
        pageRegiste.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        LoginManager.type = type;
        triggerRegiste.SetActive(false);
        triggerLogin.SetActive(false);

        pannel.SetActive(true);
        user.SetActive(true);
        passwd.SetActive(true);
        hide.SetActive(true);
        action.SetActive(true);
        pageRegiste.SetActive(true);
        pageLogin.SetActive(true);

        pannel.GetComponent<Image>().sprite = pannelSprites[0];
        action.GetComponent<Image>().sprite = actionSprites[0];
        hide.GetComponent<Image>().sprite = hideSprites[0];
        user.GetComponent<Image>().color = inputColor[0];
        passwd.GetComponent<Image>().color = inputColor[0];
        hint.text = "";
    }
}
