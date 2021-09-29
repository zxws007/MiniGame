using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dragbottle : MonoBehaviour {
    public GameObject ArrowBottle;
    public GameObject bottle2;
    public GameObject drops;
    public Text txt;
    public GameObject popbottle;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }
    private void OnMouseDrag()
    {
        if (GameObject.Find("GameManager").GetComponent<RunManager>().getClothready()&&!GameObject.Find("GameManager").GetComponent<RunManager>().getBottleready())
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
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
            ArrowBottle.SetActive(false);
            GameObject.Find("GameManager").GetComponent<RunManager>().setBottleready(true);
            GameObject.Find("bottle1").GetComponent<Renderer>().enabled = false;
            bottle2.SetActive(true);
            drops.SetActive(true);
            txt.text = "请长按水壶进行润药";
            popbottle.SetActive(true);
        }
    }

}