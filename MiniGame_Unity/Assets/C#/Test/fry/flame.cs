using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour {

    [SerializeField] public bool isShow;
    private int startTime;
    
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().enabled = isShow;
        startTime = (int)Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
        int duration = (int)(Time.fixedTime - startTime);
        if (duration % 2 == 0)
        {
            setGameObjectVisible(true);
        } else
        {
            setGameObjectVisible(false);
        }
	}

    void setGameObjectVisible(bool visible)
    {
        gameObject.GetComponent<Renderer>().enabled = visible;
    }
}
