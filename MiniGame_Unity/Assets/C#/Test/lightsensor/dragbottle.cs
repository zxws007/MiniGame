using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dragbottle : MonoBehaviour {
    private Vector3 targetCirclePos;
    private Vector3 startpoint;
    public GameObject bottle;
    public GameObject clothwet;
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
        if (GameObject.Find("GameManager").GetComponent<RunManager>().getClothready() && Vector3.Distance(transform.position, targetCirclePos) < 1.5f)
        {
            bottle.SetActive(false);
            cloth.SetActive(false);
            clothwet.SetActive(true);
            GameObject.Find("GameManager").GetComponent<RunManager>().setBottleready(true);
            //GameObject.Find("lux").SetActive(true);
            //lux.SetActive(true);
        }
        else
        {
            transform.position = startpoint;
        }
    }
}
