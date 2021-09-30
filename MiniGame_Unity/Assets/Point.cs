using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {
    public Sprite[] Sprites;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;

    static public int chao_score = 5;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "s1")
        {
            chao_score = 8;
            //Debug.Log("exit s1, score is 8");
        }
        else if (collider.name == "s2")
        {
            chao_score = 10;
            //Debug.Log("exit s2, score is 10");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "s3")
        {
            chao_score = 8;
            //Debug.Log("enter s3, score is 8");
        }
        else if (collider.name == "s4")
        {
            chao_score = 5;
            //Debug.Log("enter s4, score is 5");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "s5" || other.name == "s1")
        {
            chao_score = 5;
        }
        else if (other.name == "s4" || other.name == "s2")
        {
            chao_score = 8;
        }
        else if (other.name == "s3")
        {
            chao_score = 10;
        }
    }

}
