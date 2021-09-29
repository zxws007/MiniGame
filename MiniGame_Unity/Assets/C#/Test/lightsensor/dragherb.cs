using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dragherb : MonoBehaviour
{
    // Use this for initialization
    private GameObject ArrowHerb;
    private GameObject PutHerb;
    public GameObject ArrowCloth;
    public GameObject PutCloth;
    public bool HerbReady = false;

    void Start()
    {
        ArrowHerb = GameObject.Find("ArrowHerb");
        PutHerb = GameObject.Find("PutHerb");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
    }
    private void OnMouseDrag()
    {
        if (GameObject.Find("GameManager").GetComponent<RunManager>().getHerbready() == false)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (cursorPos.x <= 6)
            {
                transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }
        }
    }
    private void OnMouseEnter()
    {
        transform.localScale += Vector3.one * 0.07f;
    }
    private void OnMouseExit()
    {
        transform.localScale -= Vector3.one * 0.07f;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "panzi")
        {
            // Debug.Log("OnCollisionEnter2D");
            PutHerb.SetActive(false);
            ArrowHerb.SetActive(false);
        }
    }
    void OnMouseUp()
    {
        if (GameObject.Find("GameManager").GetComponent<RunManager>().getHerbready() == false && transform.position.x > 0.7 && transform.position.y < 1.8 && transform.position.y > -1.3)
        {
            ArrowCloth.SetActive(true);
            PutCloth.SetActive(true);
            GameObject.Find("GameManager").GetComponent<RunManager>().setHerbready(true);
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "panzi")
        {
            //Debug.Log("OnCollisionEnter2D");
            PutHerb.SetActive(true);
            ArrowHerb.SetActive(true);
            //ArrowCloth.SetActive(false);
            //PutCloth.SetActive(false);
            //GameObject.Find("GameManager").GetComponent<RunManager>().setHerbready(false);
        }
    }
    public void ABC()
    {
        Debug.Log("111");
    }
}
