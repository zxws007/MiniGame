using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragcloth : MonoBehaviour {
    private Vector3 targetCirclePos;
    private Vector3 startpoint;
    public GameObject clothutil;
    public GameObject cloth;
    // Use this for initialization
    void Start () {
        startpoint = transform.position;
        targetCirclePos = GameObject.Find("Target").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDrag()
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    // Update is called once per frame
    private void OnMouseUp()
    {
        if (GameObject.Find("GameManager").GetComponent<RunManager>().getHerbready()&&Vector3.Distance(transform.position, targetCirclePos) < 1f)
        {
            clothutil.SetActive(false);
            cloth.SetActive(true);
            GameObject.Find("GameManager").GetComponent<RunManager>().setClothready(true);
        }
        else
        {
            transform.position = startpoint;
        }
    }
}
