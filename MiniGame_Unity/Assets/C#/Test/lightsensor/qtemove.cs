using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qtemove : MonoBehaviour {
    public GameObject wet1;
    public GameObject wet2;
    public GameObject wet3;
    public GameObject wet4;
    public GameObject wet5;
    public GameObject cloth;
    private Animator qtewet;
    public GameObject drops;
    public GameObject littlebottle;
    public GameObject common;
    public GameObject good;
    public GameObject excellent;
    public int stage = 1;
    // Use this for initialization
    void Start () {
        qtewet = GameObject.Find("QTE滑块").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.Find("GameManager").GetComponent<RunManager>().getIsover()&&Input.GetMouseButtonUp(0))
        {
            qtewet.speed = 0;
            drops.SetActive(false);
            littlebottle.SetActive(false);
            if (stage == 1 || stage == 5)
            {
                
                common.SetActive(true);
            }else if (stage == 2 || stage == 4)
            {
                good.SetActive(true);
            }
            else
            {
                excellent.SetActive(true);
            }
            GameObject.Find("GameManager").GetComponent<RunManager>().setIsover(true);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Stage1")
        {
            stage = 1;
            wet1.SetActive(true);
            wet1.transform.position = cloth.transform.position;
        }
        if(col.gameObject.tag == "Stage2")
        {
            stage = 2;
            wet1.SetActive(false);
            wet2.SetActive(true);
            wet2.transform.position = cloth.transform.position;
        }
        if(col.gameObject.tag == "Stage3")
        {
            stage = 3;
            wet2.SetActive(false);
            wet3.SetActive(true);
            wet3.transform.position = cloth.transform.position;
        }
        if (col.gameObject.tag == "Stage4")
        {
            stage = 4;
            wet3.SetActive(false);
            wet4.SetActive(true);
            wet4.transform.position = cloth.transform.position;
        }
        if (col.gameObject.tag == "Stage5")
        {
            stage = 5;
            wet4.SetActive(false);
            wet5.SetActive(true);
            wet5.transform.position = cloth.transform.position;
        }
    }
}
