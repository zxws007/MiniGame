using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daoyaomanager : MonoBehaviour {

    public static int change = 0;
    public GameObject show1;
    public GameObject hide1;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (change == 3)
        {
            hide1.SetActive(false);
            show1.SetActive(true);
            change = change + 1;
        }
	}
}
