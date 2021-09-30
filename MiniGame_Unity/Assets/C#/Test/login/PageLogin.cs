using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageLogin : MonoBehaviour {
    public GameObject pannel;
    public GameObject user;
    public GameObject passwd;
    public GameObject hide;
    public GameObject action;

    public Sprite[] pannelSprites;
    public Sprite[] actionSprites;
    public Sprite[] hideSprites;

    public string type;

    public Color[] inputColor;

    // Use this for initialization
    void Start () {
        //pannel.SetActive(false);
        //user.SetActive(false);
        //passwd.SetActive(false);
        //hide.SetActive(true);
        //action.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {

        //pannel.SetActive(true);
        //user.SetActive(true);
        //passwd.SetActive(true);
        //hide.SetActive(true);
        //action.SetActive(true);
        LoginManager.type = type;
        pannel.GetComponent<Image>().sprite = pannelSprites[0];
        action.GetComponent<Image>().sprite = actionSprites[0];
        hide.GetComponent<Image>().sprite = hideSprites[0];
        user.GetComponent<Image>().color = inputColor[0];
        passwd.GetComponent<Image>().color = inputColor[0];
    }
}
